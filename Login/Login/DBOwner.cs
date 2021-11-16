using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Login
{
    public class DBOwner
    {
        readonly SQLiteAsyncConnection _database;

        public DBOwner(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<Owner>().Wait();
        }

        public Task<List<Owner>> GetOwnersAsync()
        {
            return
            _database.Table<Owner>().ToListAsync();
        }

        public Task<int> SaveOwnerAsync(Owner owner)
        {
            return _database.InsertAsync(owner);

        }


        public Task<Owner> GetOwnerAsync(User user)
        {
            return _database.Table<Owner>().Where(owner => owner.UserID == user.ID).FirstOrDefaultAsync();
        }


        public Task<int> UpdateOwnerAsync(Owner owner)
        {
            if (owner.ID != 0)
            {
                return _database.UpdateAsync(owner);
            }
            else
            {
                return _database.InsertAsync(owner);
            }
        }


        public async Task<int> DeleteItemAsync(Owner owner)
        {
            Permission permission = await App.DatabasePermission.GetPermissionAsync(owner.ID);
            await App.DatabasePermission.DeleteItemAsync(permission);
            await _database.DeleteAsync(owner);
            return owner.ID;
        }

    }
}
