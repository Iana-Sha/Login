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

        public Task<int> SavePermissionAsync(Permission permission)
        {
            return _database.InsertAsync(permission);

        }


        public Task<Permission> GetPermissionAsync(int permissionId)
        {
           
            return _database.Table<Permission>().Where(permission => permission.PermissionId == permissionId).FirstOrDefaultAsync();
        }


        public Task<int> UpdatePermissionAsync(Permission permission)
        {
            if (permission.PermissionId != 0)
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
        
        public Task<Permission> getLastInseted()
        {
            return _database.Table<Permission>().OrderByDescending(o => o.PermissionId).FirstOrDefaultAsync();
        }
    }
}
