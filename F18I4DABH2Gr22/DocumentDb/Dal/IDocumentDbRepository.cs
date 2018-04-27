using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.Azure.Documents;

namespace DocumentDb.Dal
{
    public interface IDocumentDbRepository<T> where T : class
    {
        void Initialize();
        Task<T> GetItemAsync(string id);
        T GetItem(string id);
        Task<IEnumerable<T>> GetItemsAsync(Expression<Func<T, bool>> predicate);
        IEnumerable<T> GetItems(Expression<Func<T, bool>> predicate);
        Task<T> UpdateItemAsync(string id, T item);
        T UpdateItem(string id, T item);
        Task<T> CreateItemAsync(T item);
        T CreateItem(T item);
        Task DeleteItemAsync(string id);
        void DeleteItem(string id);
    }
}