namespace MobileApp.Pages;

public partial class ViewAllProfilesPage : ContentPage
{
	public ViewAllProfilesPage()
	{
            InitializeComponent();
        }

    private async void BackButton1_Clicked(object sender, EventArgs e)
    {
        await Navigation.PopModalAsync();
        SemanticScreenReader.Announce(BackButton1.Text);
    }
}