using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Login
{
    public class DBVet
    {
        readonly SQLiteAsyncConnection _database;

        public DBVet(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<Vet>().Wait();
        }
        public Task<List<Vet>> GetVetAsync()
        {
            return
            _database.Table<Vet>().ToListAsync();
        }

        public Task<int> SaveVetAsync(Vet vet)
        {
            return _database.InsertAsync(vet);
        }
        public Task<int> UpdateVetAsync(Vet vet)
        {
            if (vet.ID != 0)
            {
                return _database.UpdateAsync(vet);
            }
            else
            {
                return _database.InsertAsync(vet);
            }
        }
        public async Task<int> DeleteItemAsync(Vet vet)
        {
            await _database.DeleteAsync(vet);
            return vet.ID;
        }
    }
}
