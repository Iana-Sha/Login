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
    public partial class VetRegistrationPage : ContentPage
    {
        private User userSelected = new User();
        public VetRegistrationPage(User user)
        {
            InitializeComponent();
            userSelected = user;

        }

        private async void btnCreate_Clicked(object sender, EventArgs e)
        {
            int vetID = int.Parse(txtVetID.Text);
            string name = txtName.Text;
            string lastName = txtLastName.Text;
            string email = txtEmail.Text;
            string phoneNumber = txtPhoneNumber.Text;
            string specialization = txtSpecialization.Text;

            await App.DatabaseVet.SaveVetAsync(new Vet
            {
                VetID = vetID,
                Name = name,
                Lastname = lastName,
                Email = email,
                PhoneNumber = phoneNumber,
                Specialization = specialization
            });

            await Navigation.PushAsync(new HomePage(userSelected));
        }
    }
}