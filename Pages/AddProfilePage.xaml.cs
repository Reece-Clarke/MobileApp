using SQLite;
using System.IO;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MobileApp.Pages;

public partial class AddProfilePage : ContentPage
{
    Database databaseService;
    List<Employee> employee = new List<Employee>();
    SQLiteAsyncConnection _database;

    public AddProfilePage()
	{
        InitializeComponent();

        databaseService = new Database();
    }

    // Returns user to previous page without adding a profile.
    private async void CancelButton_Clicked(object sender, EventArgs e)
    {
        await Navigation.PopModalAsync();
        SemanticScreenReader.Announce(CancelButton.Text);
    }

    // Adds a profile to the database using entry fields for submitted reference, and
    // returns user to previous page afterwards.
    private async void AddEmployee_Clicked(object sender, EventArgs e)
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
        await DisplayAlert("Profile successfully added.", "Profile should now be present in View All Profiles.", "OK");
        await Navigation.PopModalAsync();
        SemanticScreenReader.Announce(AddProfileButton.Text);
    }
}