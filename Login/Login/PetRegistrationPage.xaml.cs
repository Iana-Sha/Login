using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Login
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PetRegistrationPage : ContentPage
    {
        private User userSelected = new User();
        public PetRegistrationPage(User user)
        {
            InitializeComponent();
            userSelected = user;
        }

        private async void btnCreate_Clicked(object sender, EventArgs e)
        {
            int petID = int.Parse(txtPetID.Text);
            string petName = txtPetName.Text;
            string petType = txtPetType.Text;
            Owner owner = await App.DatabaseOwner.GetOwnerAsync(userSelected);
            int ownerId = owner.ID;

            await App.DatabasePet.SavePetAsync(new Pet
            {
                PetID = petID,
                PetName = petName,
                PetType = petType,
                OwnerId = ownerId
            });

            await Navigation.PushAsync(new HomePage(userSelected));
        }
        private async void btnUpload_Clicked(object sender, EventArgs e)
        {
           
        }
    }
}