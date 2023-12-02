using SQLite;
using System.IO;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MobileApp.Pages;

// Page can either return to the previous page (MainPage), or
// have details entered and submitted as a new profile for the database.
public partial class AddProfilePage : ContentPage
{
    Database databaseService;

    public AddProfilePage()
	{
        InitializeComponent();

        databaseService = new Database();
    }

    // Returns user to previous page without adding a profile.
    private async void AddProfileCancelButton_Clicked(object sender, EventArgs e)
    {
        await Navigation.PopModalAsync();
        SemanticScreenReader.Announce(AddProfileCancelButton.Text);
    }

    // Adds a profile to the database using entry fields for submitted reference, and
    // returns user to previous page afterwards.
    private async void AddNewProfileButton_Clicked(object sender, EventArgs e)
    {
        // Create new Employee object to be added a record to the database
        var employee = new Employee
        {
            Name = NameEntry.Text,
            Id = IdEntry.Text,
            PhoneNo = PhoneNoEntry.Text,
            Department = DepartmentEntry.Text,
            Street = StreetEntry.Text,
            City = CityEntry.Text,
            State = StateEntry.Text,
            Zip = ZipEntry.Text,
            Country = CountryEntry.Text
        };

        await databaseService.AddEmployeeAsync(employee);

        // PLACEHOLDER CODE, only returns user to previous page
        await DisplayAlert("Profile successfully added.", "Profile should now be present in when viewing all profiles.", "OK");
        await Navigation.PopModalAsync();
        SemanticScreenReader.Announce(AddNewProfileButton.Text);
    }
}