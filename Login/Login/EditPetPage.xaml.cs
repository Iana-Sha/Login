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
    public partial class EditPetPage : ContentPage
    {
        private User userSelected;
        private Pet petSelected;
        private string imageName;


        public EditPetPage(Pet pet, User user)
        {
            InitializeComponent();
            userSelected = user;
            petSelected = pet;
            Initializer();
        }

        public void Initializer()
        {
            txtPetID.Text = petSelected.PetID.ToString();
            txtPetName.Text = petSelected.PetName;
            txtPetType.Text = petSelected.PetType;
            if (ChoseImagePage.imageSender != null)
            {
                imageName = ChoseImagePage.imageSender.Source.ToString();
                imageName = imageName.Replace("File: ", "");
                ImageName.Text = "Image: " + imageName;
            }
            else ImageName.Text = petSelected.image;
        }
        private async void btnUpdate_Clicked(object sender, EventArgs e)
        {
            int petId = int.Parse(txtPetID.Text);
            string petName = txtPetName.Text;
            string petType = txtPetType.Text;
            string petImage = imageName;
            
            Pet petUpd = new Pet
            {
                ID = petSelected.ID,
                PetName = petName,
                PetType = petType,
                PetID = petId,
                OwnerId = petSelected.OwnerId,
                image = petImage
            };
           
            await App.DatabasePet.UpdatePetAsync(petUpd);

            User userFound = await App.DatabaseUser.GetUserAsync(userSelected.Username, userSelected.Password);
            await Navigation.PushAsync(new HomePage(userFound));
        }
        private async void btnUpload_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ChoseImagePage(userSelected, petSelected));
        }
    }
}