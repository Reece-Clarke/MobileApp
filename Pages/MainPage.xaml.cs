using MobileApp.Pages;

namespace MobileApp
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private async void ViewAllProfilesButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new ViewAllProfilesPage());
            SemanticScreenReader.Announce(ViewAllProfilesButton.Text);
        }

        private async void AddProfileButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new AddProfilePage());
            SemanticScreenReader.Announce(AddProfileButton.Text);
        }
    }

}
