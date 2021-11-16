using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace Login
{
    public class DBUser
    {
        readonly SQLiteAsyncConnection _database;

        public DBUser(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<User>().Wait();
        }

        public Task<List<User>> GetUsersAsync()
        {
            return
            _database.Table<User>().ToListAsync();
        }

        public Task<int> SaveUserAsync(User user)
        {
            return _database.InsertAsync(user);

        }


        public Task<User> GetUserAsync(string username, string password)
        {
            return _database.Table<User>().Where(user => user.Username == username && user.Password == password).FirstOrDefaultAsync();
        }


        public Task<int> UpdateUserAsync(User user)
        {
            if (user.ID != 0)
            {
                return _database.UpdateAsync(user);
            }
            else
            {
                return _database.InsertAsync(user);
            }
        }


        public async Task<int> DeleteItemAsync(User user)
        {
            Permission permission = await App.DatabasePermission.GetPermissionAsync(user.ID);
            await App.DatabasePermission.DeleteItemAsync(permission);
            await _database.DeleteAsync(user);
            return user.ID;
        }

    }
}
