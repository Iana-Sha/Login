using System;
using System.Collections.Generic;
using System.IO;
using System.IO.IsolatedStorage;
using System.Linq;
using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration;
using Xamarin.Forms.Xaml;

namespace Login
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ChoseImagePage : ContentPage
    {
        public IList<privImages> ImageNames { get; set; }
        public static Image imageSender;
        private User userSelected = new User();
        private Pet petSelected;
        public privImages image { get; set; }
        public ChoseImagePage(User user, Pet pet)
        {
            InitializeComponent();
            imageSender = new Image();
            userSelected = user;
            petSelected = pet;
            Initializer();
            BindingContext = this;

        }
        public void Initializer()
        {
            ImageNames = new List<privImages>();
            ImageNames.Add(new privImages { ImageName = "cat.jpg" });
            ImageNames.Add(new privImages { ImageName = "dog.jpg" });
            ImageNames.Add(new privImages { ImageName = "monkey.jpg" });
            ImageNames.Add(new privImages { ImageName = "pig.jpg" });
        }

        async void OnTapGestureRecognizerTapped(object sender, EventArgs args)
        {
            Image myImage = (Image)sender;
            {
                try
                {
                    imageSender = new Image { Source = myImage.Source };
                    if (petSelected != null)
                    {
                        await Navigation.PushAsync(new EditPetPage(petSelected, userSelected));
                    }
                    else
                    {
                        await Navigation.PushAsync(new PetRegistrationPage(userSelected));
                    }
                }
                catch (Exception e)
                {
                    await DisplayAlert("Lol", "Fail", "OK");
                }
            }
        }

        private void collectionView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            image = (privImages)e.CurrentSelection[0];
        }

        private async void GoBack_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new PetRegistrationPage(userSelected));

        }
    }
    public class privImages
    {
        public string ImageName { get; set; }
    }
}