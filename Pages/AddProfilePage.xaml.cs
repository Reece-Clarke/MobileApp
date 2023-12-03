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
    int biggestIdNumber;
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
        // Id is assigned by finding the biggest id value found in the database, and
        // adding one to it.
        // Depending on how a database may handle Ids, old or new, this may not be
        // suitable, but is a simple placeholder that can be better modified later.
        List<Employee> findIdList = await databaseService.RetrieveEmployees();
        foreach (Employee employ in findIdList)
        {
            biggestIdNumber = 0;
            int currentId = int.Parse(employ.Id);

            if (currentId > biggestIdNumber)
            {
                biggestIdNumber = currentId + 1;
            }
        }

        // Create new Employee object to be added a record to the database
        var employee = new Employee
        {
            Id = biggestIdNumber.ToString(),
            Name = NameEntry.Text,
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