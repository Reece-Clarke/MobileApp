namespace MobileApp.Pages;

public partial class AddProfilePage : ContentPage
{
	public AddProfilePage()
	{
		InitializeComponent();
	}

    // Returns user to previous page without adding a profile.
    private async void CancelButton_Clicked(object sender, EventArgs e)
    {
        await Navigation.PopModalAsync();
        SemanticScreenReader.Announce(CancelButton.Text);
    }

    // Adds a profile to the database using entry fields for submitted reference, and
    // returns user to previous page afterwards.
    private async void AddProfileButton_Clicked(object sender, EventArgs e)
    {
        string name = NameEntry.Text;
        string id = IdEntry.Text;
        string phoneNo = PhoneNoEntry.Text;
        string department = DepartmentEntry.Text;
        string street = StreetEntry.Text;
        string city = CityEntry.Text;
        string state = StateEntry.Text;
        string zip = ZipEntry.Text;
        string country = CountryEntry.Text;

        // PLACEHOLDER CODE, only returns user to previous page
        await DisplayAlert("Profile successfully added.", "Profile should now be present in View All Profiles.", "OK");
        await Navigation.PopModalAsync();
        SemanticScreenReader.Announce(AddProfileButton.Text);
    }
}