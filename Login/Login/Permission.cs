using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
using System.ComponentModel;

namespace Login
{
    public class Permission
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public bool? modify { get; set; }
        public bool? see { get; set; }
        public bool? delete { get; set; }

        public Permission(bool modify, bool see, bool delete)
        {
            this.modify = modify;
            this.see = see;
            this.delete = delete;
        }

        public Permission()
        {
        }

        public Permission(int permissionId, bool modify, bool see, bool delete)
        {
            Id = permissionId;
            this.modify = modify;
            this.see = see;
            this.delete = delete;
        }
    }
}
