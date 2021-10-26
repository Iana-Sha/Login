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
    public partial class RegisterPage : ContentPage
    {
        public RegisterPage()
        {
            InitializeComponent();
        }

        private async void btnCreate_Clicked(object sender, EventArgs e)
        {
            
            if( txtPassword.Text == null || txtPassword.Text.Length < 10)
            {
                await DisplayAlert("Password has to be longer than 10 charcters", "Failure", "OK");
                return;
            }
            string username = txtUserName.Text;
            string password = txtPassword.Text;
            string firstName = txtUserName.Text;
            string lastName = txtPassword.Text;
            string phoneNumber = txtUserName.Text;
            string email = txtUserName.Text;

            await App.DatabaseUser.SaveUserAsync(new User
            {
                Username = username,
                Password = password,
                FirstName = firstName,
                LastName = lastName,
                PhoneNumber = phoneNumber,
                Email = email
            }) ;

            await Navigation.PushAsync(new LoginPage());
        }
    }
}