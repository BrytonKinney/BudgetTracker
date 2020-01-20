using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ByudgetTracker.Services
{
    public interface IDataStore<T>
    {
        Task CreateTablesAsync();
        Task<int> AddAsync(T item);
        Task<int> UpdateAsync(T item);
        Task<int> DeleteAsync(int id);
        Task<T> GetAsync(int id);
        Task<IList<T>> GetAsync(bool forceRefresh = false);
    }
}
