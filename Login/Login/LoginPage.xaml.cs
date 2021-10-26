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
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
        }

        private async void btnLogin_Clicked(object sender, EventArgs e)
        {
            if (txtUserName.Text == null && txtPassword.Text == null)
            {
                await DisplayAlert("PLZ eneter username and password", "Fail", "OK");
                return;
            }
            if (txtUserName == null)
            {
                await DisplayAlert("PLZ eneter username", "Fail", "OK");
                return;
            }   
            if (txtPassword == null)
            {
                await DisplayAlert("PLZ eneter password", "Fail", "OK");
                return;
            }
            String userName = txtUserName.Text;
            String PassWord = txtPassword.Text;
            var user = await App.DatabaseUser.GetItemAsync(userName, PassWord);
            if (user != null)
            {
                await DisplayAlert("Login result", "Success", "OK");
                await Navigation.PushAsync(new HomePage());
            }
            else
            {
                await DisplayAlert("Unauthorized", "Failure", "OK");
                txtUserName.Text = "";
                txtPassword.Text = "";
            }
        }

        private async void btnRegister_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new RegisterPage());
        }
    }
}