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
    public partial class UserDisplayPage : ContentPage
    {
        private User user;
        public UserDisplayPage()
        {
            InitializeComponent();
            DisplayUsers();
            BindingContext = this;
        }
        public async void DisplayUsers()
        {
            var x = await App.DatabaseUser.GetUsersAsync();
            if (x.Count == 0)
            {
                await DisplayAlert("Alert", "Databse is empty", "OK");
            }
            else
            {
                collectionView.ItemsSource = await App.DatabaseUser.GetUsersAsync();
            }
        }

        private async void updateBtn_Clicked(object sender, EventArgs e)
        {
            if(user != null)
            {
                await Navigation.PushAsync(new UserUpdatePage(user));
            }
            else
            {
                await DisplayAlert("Alert", "Select a user you want to update", "OK");
            }
            
        }

        private void collectionView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            user = (User)e.CurrentSelection[0];
        }

        private async void deleteBtn_Clicked(object sender, EventArgs e)
        {
            bool answer = await DisplayAlert("Attentions!", "Are you sure you want to delete user: " + user.Username, "Yes", "No");
            if(answer)
            {
                await App.DatabaseUser.DeleteItemAsync(user);
                await Navigation.PushAsync(new UserDisplayPage());
            }
            else
            {
                return;
            }
        }
    }
}