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
        public VetsDisplayPage()
        {
            InitializeComponent();
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
    }
}