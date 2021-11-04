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
    public partial class PetDisplayPage : ContentPage
    {
        private User userSelected = new User();
        public PetDisplayPage(User user)
        {
            InitializeComponent();
            userSelected = user;
            DisplayPets();
        }
        public async void DisplayPets()
        {

            var x = await App.DatabasePet.GetPetAsync();
            if (x.Count == 0)
            {
                await DisplayAlert("Alert", "Databse is empty", "OK");
            }
            else
            {
                 collectionView.ItemsSource = await App.DatabasePet.GetPetAsync();                   
            }
        }

    }

}
