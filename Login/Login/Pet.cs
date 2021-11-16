using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace Login
{
    public class Pet
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public int PetID { get; set; }
        public string PetName { get; set; }
        public string PetType { get; set; }
        public int OwnerId { get; set; }
        public string image { get; set; }
    }
}
