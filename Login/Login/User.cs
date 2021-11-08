using SQLite;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace Login
{
    public class User : INotifyPropertyChanged
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        
        public string userName;
        [Unique]
        public string Username 
        {
            get => userName;
            set
            {
                if (value == userName)
                    return;
                userName = value;
                this.Username = value;
                OnPropertyChanged(nameof(Username));
                OnPropertyChanged(nameof(GetUserName));
            }
        }
        public string GetUserName
        {
            get => $"You entered {Username}";
        }
        public string Password
        {
            get;
            set;
        }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Type { get; set; }
        public int PermissionId { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
        void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
