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
	public partial class EditVetPage : ContentPage
	{
		private User userSelected;
		private Vet vetSelected;
		public EditVetPage (Vet vet, User user)
		{
			InitializeComponent ();
			userSelected = user;
			vetSelected = vet;
            Initializer();

        }

        private async void btnUpdate_Clicked(object sender, EventArgs e)
        {
            int vetId = int.Parse(txtVetID.Text);
            string vetName = txtName.Text;
            string vetLastName = txtLastName.Text;
            string vetEmail = txtEmail.Text;
            string vetPhoneNumber = txtPhoneNumber.Text;
            string vetSpecialization = txtSpecialization.Text;

            Vet vetUpd = new Vet
            {
                ID = vetSelected.ID,
                Email = vetEmail,
                Name = vetName,
                Lastname = vetLastName,
                PhoneNumber = vetPhoneNumber,
                Specialization = vetSpecialization,
                VetID = vetId
            };
            await App.DatabaseVet.UpdateVetAsync(vetUpd);
            await Navigation.PushAsync(new VetsDisplayPage(userSelected));
        }
        public void Initializer()
        {
            txtVetID.Text = vetSelected.VetID.ToString();
            txtName.Text = vetSelected.Name;
            txtLastName.Text = vetSelected.Lastname;
            txtEmail.Text = vetSelected.Email;
            txtPhoneNumber.Text = vetSelected.PhoneNumber;
            txtSpecialization.Text = vetSelected.Specialization;   
        }
    }
}