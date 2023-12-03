using SQLite;
using System.IO;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MobileApp.Pages;

// Page allows user to update a currently selected profile's details.
// The user can enter in the appropriate text fields to enter in new profile details, and
// can return to the previous page without updating the profile.
public partial class UpdateProfilePage : ContentPage
{
    Database databaseService;

    Employee singleEmployee;

    // Using an Employee class, it sets the appropriate information to each text entry field as a placeholder.
	public UpdateProfilePage(Employee employ)
	{
		InitializeComponent();

        databaseService = new Database();
        singleEmployee = employ;

        // Text entry fields as filled with currently selected profile information.
        NameEntry.Text = singleEmployee.Name;
        PhoneNoEntry.Text = singleEmployee.PhoneNo;
        DepartmentEntry.Text = singleEmployee.Department;
        StreetEntry.Text = singleEmployee.Street;
        CityEntry.Text = singleEmployee.City;
        StateEntry.Text = singleEmployee.State;
        ZipEntry.Text = singleEmployee.Zip;
        CountryEntry.Text = singleEmployee.Country;
    }

    // Returns user to previous page without updating profile details.
    private async void UpdateProfileCancelButton_Clicked(object sender, EventArgs e)
    {
        await Navigation.PopModalAsync();
        SemanticScreenReader.Announce(UpdateProfileCancelButton.Text);
    }

    // Gets and updates an Employee record in the database. NOTE: Remove Id from being allowed to be updated, as it is a primary key, and cannot be updated.
    public async void UpdateProfile_Clicked(object sender, EventArgs e)
    {
        singleEmployee.Name = NameEntry.Text;
        singleEmployee.PhoneNo = PhoneNoEntry.Text;
        singleEmployee.Department = DepartmentEntry.Text;
        singleEmployee.Street = StreetEntry.Text;
        singleEmployee.City = CityEntry.Text;
        singleEmployee.State = StateEntry.Text;
        singleEmployee.Zip = ZipEntry.Text;
        singleEmployee.Country = CountryEntry.Text;

    // Update selected Employee in database, through another function
        await databaseService.UpdateEmployeeAsync(singleEmployee);
        await DisplayAlert("Action successful", "Profile has been updated.", "OK");
        await Navigation.PopModalAsync();
    }
}