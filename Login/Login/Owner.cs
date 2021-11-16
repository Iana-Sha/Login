using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace Login
{
    public class Owner
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public int UserID { get; set; }
    }
}
