using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Login
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class OwnerRegistrationPage : ContentPage
    {
        private User userSelected;
        public OwnerRegistrationPage(User user)
        {
            InitializeComponent();
            userSelected = user;
        }

        private async void btnCreate_Clicked(object sender, System.EventArgs e)
        {
            
            string address = txtAddress.Text;
            string phoneNumber = txtPhoneNumber.Text;
            string firstName = userSelected.FirstName;
            string lastName = userSelected.LastName;
            int userId = userSelected.ID;
            await App.DatabaseOwner.SaveOwnerAsync(new Owner
            {
                FirstName = firstName,
                LastName = lastName,
                PhoneNumber = phoneNumber,
                Address = address,
                UserID = userId
            });
            await Navigation.PushAsync(new PetRegistrationPage(userSelected));
        }
    }
}