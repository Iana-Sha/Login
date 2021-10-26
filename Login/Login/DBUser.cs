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
        public Task<List<User>> GetUserAsync()
        {
            return
            _database.Table<User>().ToListAsync();
        }

        public Task<int> SaveUserAsync(User user)
        {
            return _database.InsertAsync(user);
        }
        public Task<User> GetItemAsync(string username, string password)
        {
            return _database.Table<User>().Where(user => user.Username == username && user.Password == password).FirstOrDefaultAsync();
        }
    }
}
