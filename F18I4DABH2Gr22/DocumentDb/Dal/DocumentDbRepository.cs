using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.Azure.Documents;
using Microsoft.Azure.Documents.Client;
using Microsoft.Azure.Documents.Linq;

namespace DocumentDb.Dal
{
    public class DocumentDbRepository<T> : IDocumentDbRepository<T> where T : class
    {
        protected string NewDatabaseId;
        protected string NewCollectionId;

        protected static DocumentClient DocumentClient;

        protected static string AuthenticationKey = "C2y6yDjf5/R+ob0N8A7Cgv30VRDJIWEHLM+4QDU5DE2nQ9nDuVTqobD4b8mGGyPMbIZnqyMsEcaGQy67XIw/Jw==";
        protected static string ServiceEndpoint = "https://localhost:8081";

        protected DocumentDbRepository(string databaseId, string collectionId)
        {
            NewDatabaseId = databaseId ?? throw new ArgumentNullException(nameof(databaseId));
            NewCollectionId = collectionId ?? throw new ArgumentNullException(nameof(collectionId));

            if (DocumentClient == null)
            {
                DocumentClient = new DocumentClient(new Uri(ServiceEndpoint), AuthenticationKey);
            }

            CreateDatabaseIfNotExists();
            CreateCollectionIfNotExists();
        }

        public async Task<T> GetItemAsync(string id)
        {
            try
            {
                Document document = await DocumentClient.ReadDocumentAsync(UriFactory.CreateDocumentUri(NewDatabaseId, NewCollectionId, id));

                return (T) (dynamic) document;
            }
            catch (DocumentClientException e)
            {
                if (e.StatusCode == System.Net.HttpStatusCode.NotFound)
                {
                    return null;
                }
                else
                {
                    throw;
                }
            }
        }

        public T GetItem(string id)
        {
            var task = GetItemAsync(id);
            task.Wait();
            return task.Result;
        }

        public async Task<IEnumerable<T>> GetItemsAsync(Expression<Func<T, bool>> predicate)
        {
            IDocumentQuery<T> query = DocumentClient.CreateDocumentQuery<T>(
                    UriFactory.CreateDocumentCollectionUri(NewDatabaseId, NewCollectionId),
                    new FeedOptions { MaxItemCount = -1 })
                .Where(predicate)
                .AsDocumentQuery();

            List<T> results = new List<T>();
            while (query.HasMoreResults)
            {
                results.AddRange(await query.ExecuteNextAsync<T>());
            }

            return results;
        }

        public IEnumerable<T> GetItems(Expression<Func<T, bool>> predicate)
        {
            var task = GetItemsAsync(predicate);
            task.Wait();
            return task.Result;
        }

        public T UpdateItem(string id, T item)
        {
            var task = UpdateItemAsync(id, item);
            task.Wait();
            return task.Result;
        }

        public async Task<T> CreateItemAsync(T item)
        {
            Document doc = await DocumentClient.CreateDocumentAsync(UriFactory.CreateDocumentCollectionUri(NewDatabaseId, NewCollectionId), item);
            return (T) (dynamic) doc;
        }

        public T CreateItem(T item)
        {
            var task = CreateItemAsync(item);
            task.Wait();
            return task.Result;
        }

        public async Task<T> UpdateItemAsync(string id, T item)
        {
            try
            {
                Document doc = await DocumentClient.ReplaceDocumentAsync(UriFactory.CreateDocumentUri(NewDatabaseId, NewCollectionId, id), item);
                return (T)(dynamic)doc;
            }catch(Exception)
            {
                return null;
            }

        }


        public async Task DeleteItemAsync(string id)
        {
            await DocumentClient.DeleteDocumentAsync(UriFactory.CreateDocumentUri(NewDatabaseId, NewCollectionId, id));
        }

        public void DeleteItem(string id)
        {
            DeleteItemAsync(id).Wait();
        }

        #region Creation

        private void CreateDatabaseIfNotExists()
        {
            try
            {
                DocumentClient.ReadDatabaseAsync(UriFactory.CreateDatabaseUri(NewDatabaseId)).Wait();
            }
            catch (DocumentClientException e)
            {
                if (e.StatusCode == System.Net.HttpStatusCode.NotFound)
                {
                    DocumentClient.CreateDatabaseAsync(new Database { Id = NewDatabaseId }).Wait();
                }
                else
                {
                    throw;
                }
            }
        }

        private void CreateCollectionIfNotExists()
        {
            try
            {
                Uri documentCollectionLink = UriFactory.CreateDocumentCollectionUri(NewDatabaseId, NewCollectionId);
                DocumentClient.ReadDocumentCollectionAsync(documentCollectionLink).Wait();
            }
            catch (DocumentClientException e)
            {
                if (e.StatusCode == System.Net.HttpStatusCode.NotFound)
                {
                    DocumentClient.CreateDocumentCollectionAsync(
                        UriFactory.CreateDatabaseUri(NewDatabaseId),
                        new DocumentCollection { Id = NewCollectionId },
                        new RequestOptions { OfferThroughput = 400 }).Wait();
                }
                else
                {
                    throw;
                }
            }
        }

        #endregion


    }
}