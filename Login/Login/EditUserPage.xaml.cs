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
    public partial class EditUserPage : ContentPage
    {
        private User userSelected;
        private Owner ownerSelected;
        public EditUserPage(User user)
        {
            InitializeComponent();
            userSelected = user;
            Initializer();
        }
        public async void Initializer()
        {
            ownerSelected = await App.DatabaseOwner.GetOwnerAsync(userSelected);
            Username.Text = userSelected.Username;
            Password.Text = userSelected.Password;
            FirstName.Text = userSelected.FirstName;
            LastName.Text = userSelected.LastName;
            Email.Text = userSelected.Email;
            if (ownerSelected != null)
            {
                Address.Text = ownerSelected.Address;
                PhoneNumber.Text = ownerSelected.PhoneNumber;
            }
        }

        private async void btnUpdate_Clicked(object sender, EventArgs e)
        {
            
                string username = Username.Text;
                string password = Password.Text;
                string firstName = FirstName.Text;
                string lastName = LastName.Text;
                string email = Email.Text;
                string address = "";
                string phonenumber = "";
            if (ownerSelected != null)
            {
                address = Address.Text;
                phonenumber = PhoneNumber.Text;
            }
                User userUpd = new User 
                {
                    ID = userSelected.ID,
                    Username = username,
                    Password = password,
                    FirstName = firstName,
                    LastName = lastName,
                    Email = email,
                    PermissionId = userSelected.PermissionId,
                    Type = userSelected.Type
                };
            if (ownerSelected != null)
            {
                Owner ownerUpd = new Owner
                {
                    ID = ownerSelected.ID,
                    Address = address,
                    PhoneNumber = phonenumber,
                    FirstName = firstName,
                    LastName = lastName,
                    UserID = userSelected.ID
                };
                await App.DatabaseOwner.UpdateOwnerAsync(ownerUpd);
            }
                await App.DatabaseUser.UpdateUserAsync(userUpd);
            
            User userFound = await App.DatabaseUser.GetUserAsync(username, password);
            await Navigation.PushAsync(new HomePage(userFound));
        }
    }
}