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
    public partial class HomePage : ContentPage
    {
        private User userSelected = new User();

        public HomePage(User user)
        {
            InitializeComponent();
            userSelected = user;
            if(userSelected.Type.Equals("viewer"))
            {
                btnDisplayUsers.IsVisible = false;
                btnDisplayVets.IsVisible = false;
                btnDisplayVets.IsVisible = false;
                btnRegisterVet.IsVisible = false;
            }
            else if(userSelected.GetUserName.Equals("admin"))
            {

            }
            else if(userSelected.Type.Equals("internal"))
            {
                btnDisplayUsers.IsVisible = false;
            }
        }

        private async void btnRegisterVet_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new VetRegistrationPage());
        }

        private async void btnRegisterPet_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new PetRegistrationPage());
        }

        private async void btnDisplayVets_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new VetsDisplayPage());

        }
        private async void btnDisplayUsers_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new UserDisplayPage());

        }

        private async void btnDisplayPets_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new PetDisplayPage());

        }
        private async void btnLogout_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new LoginPage());

        }
    }
}