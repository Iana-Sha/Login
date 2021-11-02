using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Login
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class UserUpdatePage : ContentPage
    {
        private User userSelected;
        private Permission permission = new Permission();
        public UserUpdatePage(User user)
        {
            InitializeComponent();
           
            userSelected = user;
            getPermissions();
            if (userSelected.Type.Equals("internal"))
            {
                internalCB.IsChecked = true;
                if (permission.modify == true) modifyCB.IsChecked = true;
                if (permission.see == true) seeCB.IsChecked = true;
                if (permission.delete == true) deleteCB.IsChecked = true;
            }
            else if(userSelected.Type.Equals("viewer"))
            {
                modifyCB.IsEnabled = false;
                seeCB.IsEnabled = false;
                deleteCB.IsEnabled = false;
            }
        }

        private async void Update_Clicked(object sender, EventArgs e)
        {
            if(internalCB.IsChecked)
            {
                userSelected.Type = "internal";
                permission.modify = modifyCB.IsChecked;
                permission.see = seeCB.IsChecked;
                permission.delete = deleteCB.IsChecked;
            }
            else
            {
                userSelected.Type = "viewer";
                permission.modify = false;
                permission.see = false;
                permission.delete = false;
            }

            await App.DatabaseUser.UpdateUserAsync(userSelected);
            await App.DatabasePermission.UpdatePermissionAsync(permission);
            await Navigation.PushAsync(new UserDisplayPage());
        }
        private async void getPermissions()
        {
            Permission temp = await App.DatabasePermission.GetPermissionAsync(userSelected.PermissionId);
            permission.PermissionId = temp.PermissionId;
            permission.modify = temp.modify;
            permission.see = temp.see;
            permission.delete = temp.delete;
        }

        private void internalCB_CheckedChanged(object sender, CheckedChangedEventArgs e)
        {
            if (internalCB.IsChecked)
            {
                modifyCB.IsEnabled = true;
                seeCB.IsEnabled = true;
                deleteCB.IsEnabled = true;
            }
            else
            {
                modifyCB.IsEnabled = false;
                seeCB.IsEnabled = false;
                deleteCB.IsEnabled = false;
                modifyCB.IsEnabled = false;
                seeCB.IsEnabled = false;
                deleteCB.IsEnabled = false;
            }
        }
    }
}