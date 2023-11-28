namespace MobileApp.Pages;

public partial class AddProfilePage : ContentPage
{
	public AddProfilePage()
	{
		InitializeComponent();
	}

    // Returns user to previous page without adding a profile
    private async void CancelButton_Clicked(object sender, EventArgs e)
    {
        await Navigation.PopModalAsync();
        SemanticScreenReader.Announce(CancelButton.Text);
    }

    // Adds a profile to the database and returns user to previous page afterwards
    private async void AddProfileButton_Clicked(object sender, EventArgs e)
    {
        // PLACEHOLDER CODE, only returns user to previous page
        await Navigation.PopModalAsync();
        SemanticScreenReader.Announce(AddProfileButton.Text);
    }
}