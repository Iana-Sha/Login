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
        private string imageName;
        private User userSelected = new User();
        public PetRegistrationPage(User user)
        {
            InitializeComponent();
            if (ChoseImagePage.imageSender != null)
            {
                imageName = ChoseImagePage.imageSender.Source.ToString();
                imageName = imageName.Replace("File: ", "");
                ImageName.Text = "Image: " + imageName;
            }
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
                OwnerId = ownerId,
                image = imageName
            });

            await Navigation.PushAsync(new HomePage(userSelected));
        }
        private async void btnUpload_Clicked(object sender, EventArgs e)
        {
            Pet pet = null;
            await Navigation.PushAsync(new ChoseImagePage(userSelected, pet));
        }
    }
}