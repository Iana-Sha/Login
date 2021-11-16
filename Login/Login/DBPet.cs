using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Login
{
    public class DBPet
    {
        readonly SQLiteAsyncConnection _database;

        public DBPet(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<Pet>().Wait();
        }
        public Task<List<Pet>> GetPetAsync()
        {
            return _database.Table<Pet>().ToListAsync();
        }
        
        public Task<List<Pet>> GetPetByOwnerIdAsync(Owner owner)
        {
            return _database.Table<Pet>().Where(pet => pet.OwnerId == owner.ID).ToListAsync();
        }

        public Task<int> SavePetAsync(Pet pet)
        {
            return _database.InsertAsync(pet);
        }
        public Task<int> UpdatePetAsync(Pet pet)
        {
            if (pet.ID != 0)
            {
                return _database.UpdateAsync(pet);
            }
            else
            {
                return _database.InsertAsync(pet);
            }
        }
    }
}
