using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace Login
{
    public class Vet
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public int VetID { get; set; }
        public string Name { get; set; }
        public string Lastname { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Specialization{ get; set; }
    }
}
