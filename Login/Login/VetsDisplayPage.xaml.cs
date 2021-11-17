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
    public partial class VetsDisplayPage : ContentPage
    {
        private Vet vetSelected = null;
        private User userSelected;
        public VetsDisplayPage(User user)
        {
            InitializeComponent();
            userSelected = user;
            buttonsByPermission();
            DisplayVets();
        }
        public async void DisplayVets()
        {
            var x = await App.DatabaseVet.GetVetAsync();
            if (x.Count == 0)
            {
                await DisplayAlert("Alert", "Databse is empty", "OK");
            }
            else
            {
                collectionView.ItemsSource = await App.DatabaseVet.GetVetAsync();
            }
        }

        private async void Update_Clicked(object sender, EventArgs e)
        {
            if (vetSelected != null)
                await Navigation.PushAsync(new EditVetPage(vetSelected, userSelected));
            else
                await DisplayAlert("Alert", "Please select a vet", "OK");
        }

        private void collectionView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            vetSelected = (Vet)e.CurrentSelection[0];
        }

        private async void Delete_Clicked(object sender, EventArgs e)
        {
            if (vetSelected != null)
            {
                await App.DatabaseVet.DeleteItemAsync(vetSelected);
                await Navigation.PushAsync(new VetsDisplayPage(userSelected));
            }
            else
                await DisplayAlert("Alert", "Please select a vet to delete", "OK");
        }
        private async void buttonsByPermission()
        {
            Permission permission = await App.DatabasePermission.GetPermissionAsync(userSelected.PermissionId);

            if ((userSelected.Type.Equals("internal") && permission.modify == true) || userSelected.Username.Equals("admin"))
                Update.IsVisible = true;
            else
                Update.IsVisible = false;

            if ((userSelected.Type.Equals("internal") && permission.delete == true) || userSelected.Username.Equals("admin"))
                Delete.IsVisible = true;
            else
                Delete.IsVisible = false;
        }
    }
}