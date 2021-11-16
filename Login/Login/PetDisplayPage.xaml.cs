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
        private Pet petSelected = new Pet();
        public PetDisplayPage(User user)
        {
            InitializeComponent();
            userSelected = user;
            DisplayPets();
        }
        public async void DisplayPets()
        {
            Owner owner = new Owner();
            try
            {
                owner = await App.DatabaseOwner.GetOwnerAsync(userSelected);
            }
            catch (Exception e)
            {

            }
            if (owner != null)
            {
                List<Pet> petList = await App.DatabasePet.GetPetByOwnerIdAsync(owner);

                if (petList.Count == 0)
                {
                    await DisplayAlert("Alert", "Databse is empty", "OK");
                }
                else
                {
                    collectionView.ItemsSource = petList;
                }
            }
            else
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
        private async void Update_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new EditPetPage(petSelected,userSelected));

        }

        private void collectionView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
             petSelected = (Pet)e.CurrentSelection[0];
        }
    }

}
