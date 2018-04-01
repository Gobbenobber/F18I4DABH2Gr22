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
        private static readonly string DatabaseId = "ContactDb";
        private static readonly string CollectionId = "ContactCollection";
        private static DocumentClient _documentClient;

        public static void Initialize()
        {
            Uri serviceEndpoint = new Uri(@"https://localhost:8081");
            string authKey = "C2y6yDjf5/R+ob0N8A7Cgv30VRDJIWEHLM+4QDU5DE2nQ9nDuVTqobD4b8mGGyPMbIZnqyMsEcaGQy67XIw/Jw==";

            _documentClient = new DocumentClient(serviceEndpoint, authKey);
            CreateDatabaseIfNotExistsAsync().Wait();
            CreateCollectionIfNotExistsAsync().Wait();
        }

        void IDocumentDbRepository<T>.Initialize()
        {
            DocumentDbRepository<T>.Initialize();
        }
     
        public static async Task<T> GetItemAsync(string id)
        {
            try
            {
                Document document = await _documentClient.ReadDocumentAsync(UriFactory.CreateDocumentUri(DatabaseId, CollectionId, id));

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

        async Task<T> IDocumentDbRepository<T>.GetItemAsync(string id)
        {
            return await DocumentDbRepository<T>.GetItemAsync(id);
        }

        public static async Task<IEnumerable<T>> GetItemsAsync(Expression<Func<T, bool>> predicate)
        {
            IDocumentQuery<T> query = _documentClient.CreateDocumentQuery<T>(
                    UriFactory.CreateDocumentCollectionUri(DatabaseId, CollectionId),
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

        async Task<IEnumerable<T>> IDocumentDbRepository<T>.GetItemsAsync(Expression<Func<T, bool>> predicate)
        {
            return await DocumentDbRepository<T>.GetItemsAsync(predicate);
        }

        public static async Task<Document> CreateItemAsync(T item)
        {
            return await _documentClient.CreateDocumentAsync(UriFactory.CreateDocumentCollectionUri(DatabaseId, CollectionId), item);
        }

        async Task<Document> IDocumentDbRepository<T>.CreateitemAsync(T item)
        {
            return await DocumentDbRepository<T>.CreateItemAsync(item);
        }

        public static async Task<Document> UpdateItemAsync(string id, T item)
        {
            return await _documentClient.ReplaceDocumentAsync(UriFactory.CreateDocumentUri(DatabaseId, CollectionId, id), item);
        }

        async Task<Document> IDocumentDbRepository<T>.UpdateItemAsync(string id, T item)
        {
            return await DocumentDbRepository<T>.UpdateItemAsync(id, item);
        }

        public static async Task DeleteItemAsync(string id)
        {
            await _documentClient.DeleteDocumentAsync(UriFactory.CreateDocumentUri(DatabaseId, CollectionId, id));
        }

        async Task IDocumentDbRepository<T>.DeleteItemAsync(string id)
        {
            await DocumentDbRepository<T>.DeleteItemAsync(id);
        }

        #region Creation

        private static async Task CreateDatabaseIfNotExistsAsync()
        {
            try
            {
                await _documentClient.ReadDatabaseAsync(UriFactory.CreateDatabaseUri(DatabaseId));
            }
            catch (DocumentClientException e)
            {
                if (e.StatusCode == System.Net.HttpStatusCode.NotFound)
                {
                    await _documentClient.CreateDatabaseAsync(new Database { Id = DatabaseId });
                }
                else
                {
                    throw;
                }
            }
        }

        private static async Task CreateCollectionIfNotExistsAsync()
        {
            try
            {
                Uri documentCollectionLink = UriFactory.CreateDocumentCollectionUri(DatabaseId, CollectionId);
                await _documentClient.ReadDocumentCollectionAsync(documentCollectionLink);
            }
            catch (DocumentClientException e)
            {
                if (e.StatusCode == System.Net.HttpStatusCode.NotFound)
                {
                    await _documentClient.CreateDocumentCollectionAsync(
                        UriFactory.CreateDatabaseUri(DatabaseId),
                        new DocumentCollection { Id = CollectionId },
                        new RequestOptions { OfferThroughput = 400 });
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