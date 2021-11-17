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
            if (userSelected.Username.Equals("admin"))         
            {
               
            }
            else if (userSelected.Type.Equals("viewer"))
            {
                btnDisplayUsers.IsVisible = false;
                btnRegisterVet.IsVisible = false;
            }
            else if(userSelected.Type.Equals("internal"))
            {
                btnDisplayUsers.IsVisible = false;
            }
            WelcomeBackUser.Text = "Welcome back " + userSelected.Username + "!";
        }

        private async void btnRegisterVet_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new VetRegistrationPage(userSelected));
        }

        private async void btnRegisterPet_Clicked(object sender, EventArgs e)
        {
            Owner owner = await App.DatabaseOwner.GetOwnerAsync(userSelected);
            List<Pet> listPet = new List<Pet>();
            if (owner != null) 
            {
                listPet = await App.DatabasePet.GetPetByOwnerIdAsync(owner);
            }
            if (owner == null)
            {
                bool answer = await DisplayAlert("Missing information", "Would you like to add information and become an owner?", "Yes", "No");
                if(answer)
                    await Navigation.PushAsync(new OwnerRegistrationPage(userSelected));
            }
            else if(listPet.Count == 2)
            {
                await DisplayAlert("Sorry you reached the limit of pets you can add", "Failure", "OK");
            }
            else
            {
                await Navigation.PushAsync(new PetRegistrationPage(userSelected));
            }
        }

        private async void btnDisplayVets_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new VetsDisplayPage(userSelected));
        }
        private async void btnDisplayUsers_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new UserDisplayPage());
        }

        private async void btnDisplayPets_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new PetDisplayPage(userSelected));
        }
        private async void btnLogout_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new LoginPage());
        }

        private async void EditToolBarItem_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new EditUserPage(userSelected));
        }
    }
}