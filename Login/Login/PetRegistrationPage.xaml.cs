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
    public partial class PetRegistrationPage : ContentPage
    {
        public PetRegistrationPage()
        {
            InitializeComponent();
        }

        private async void btnCreate_Clicked(object sender, EventArgs e)
        {
            int petID = int.Parse(txtPetID.Text);
            string petName = txtPetName.Text;
            string petType = txtPetType.Text;
            string ownerName = txtOwnerName.Text;
            string phoneNumber = txtPhoneNumber.Text;

            await App.DatabasePet.SavePetAsync(new Pet
            {
                PetID = petID,
                PetName = petName,
                PetType = petType,
                OwnerName = ownerName,
                PhoneNumber = phoneNumber,
            });

            await Navigation.PushAsync(new HomePage());
        }
    }
}