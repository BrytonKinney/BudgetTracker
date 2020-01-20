using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace ByudgetTracker.Services
{
    public class SqliteDataStore<T> : IDataStore<T> where T : new()
    {
        private SQLiteAsyncConnection _connection;
        public SqliteDataStore()
        {
            string dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "transactions.db");
            _connection = new SQLiteAsyncConnection(dbPath);
        }
        public async Task CreateTablesAsync()
        {
            await _connection.CreateTableAsync<ByudgetTracker.Entities.Transaction>();
        }
        public async Task<int> AddAsync(T item)
        {
            return await _connection.InsertOrReplaceAsync(item);
        }

        public async Task<int> DeleteAsync(int id)
        {
            return await _connection.DeleteAsync<T>(id);
        }

        public async Task<T> GetAsync(int id)
        {
            return await _connection.GetAsync<T>(id);
        }

        public async Task<IList<T>> GetAsync(bool forceRefresh = false)
        {
            return await _connection.Table<T>().ToListAsync();
        }

        public async Task<int> UpdateAsync(T item)
        {
            return await _connection.UpdateAsync(item);
        }
    }
}
