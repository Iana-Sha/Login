using System;
using System.IO;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Login
{
    public partial class App : Application
    {
        static DBUser databaseUser;
        public static DBUser DatabaseUser
        {
            get
            {
                if (databaseUser == null)
                {
                    databaseUser = new DBUser
                        (Path.Combine(Environment.GetFolderPath
                        (Environment.SpecialFolder.LocalApplicationData), "user.db3"));
                }
                return databaseUser;
            }
        }
        static DBPet databasePet;
        public static DBPet DatabasePet
        {
            get
            {
                if (databasePet == null)
                {
                    databasePet = new DBPet
                        (Path.Combine(Environment.GetFolderPath
                        (Environment.SpecialFolder.LocalApplicationData), "pet.db3"));
                }
                return databasePet;
            }
        }
        static DBVet databaseVet;
        public static DBVet DatabaseVet
        {
            get
            {
                if (databaseVet == null)
                {
                    databaseVet = new DBVet
                        (Path.Combine(Environment.GetFolderPath
                        (Environment.SpecialFolder.LocalApplicationData), "vet.db3"));
                }
                return databaseVet;
            }
        }
        static DBPermission databasePermission;
        public static DBPermission DatabasePermission
        {
            get
            {
                if (databasePermission == null)
                {
                    databasePermission = new DBPermission
                        (Path.Combine(Environment.GetFolderPath
                        (Environment.SpecialFolder.LocalApplicationData), "permission.db3"));
                }
                return databasePermission;
            }
        }
        static DBOwner databaseOwner;
        public static DBOwner DatabaseOwner
        {
            get
            {
                if (databaseOwner == null)
                {
                    databaseOwner = new DBOwner
                        (Path.Combine(Environment.GetFolderPath
                        (Environment.SpecialFolder.LocalApplicationData), "owner.db3"));
                }
                return databaseOwner;
            }
        }

        public App()
        {
            InitializeComponent();

            //MainPage = new LoginPage();
            MainPage = new NavigationPage(new LoginPage());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
