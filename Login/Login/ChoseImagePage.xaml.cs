using System;
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
        public ChoseImagePage()
        {
            InitializeComponent();
        }
        public void Initializer()
        {
            string[] filePaths = Directory.GetFiles("drawable/", "*.jpg");

        }

        //void OnTapGestureRecognizerTapped(object sender, EventArgs args)
        //{
        //    var imageSender = (Image)sender;
        //    // watch the monkey go from color to black&white!

             
        //        imageSender.Source = "tapped_bw.jpg";
        //}
    }
}