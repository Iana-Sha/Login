using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace Login
{
    public class DBPermission
    { 
        readonly SQLiteAsyncConnection _database;

        public DBPermission(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<Permission>().Wait();
        }

        public Task<List<Permission>> GetPermissionsAsync()
        {
            return
            _database.Table<Permission>().ToListAsync();
        }

        public async Task<Permission> SavePermissionAsync(Permission permission)
        {
            await _database.InsertAsync(permission);
            return permission;
        }


        public Task<Permission> GetPermissionAsync(int permissionId)
        {
           
            return _database.Table<Permission>().Where(permission => permission.Id == permissionId).FirstOrDefaultAsync();
        }


        public Task<int> UpdatePermissionAsync(Permission permission)
        {
            if (permission.Id != 0)
            {
                return _database.UpdateAsync(permission);
            }
            else
            {
                return _database.InsertAsync(permission);
            }
        }


        public Task<int> DeleteItemAsync(Permission permission)
        {
            return _database.DeleteAsync(permission);
        }
       
    }
}
