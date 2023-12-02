using SQLite;
using System.IO;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MobileApp.Pages;

// Page is for viewing the details of one specific profile from the database.
// From the page, the user can either return to the previous page, or
// navigate to the UpdateProfile page to change details in the profile and
// update the database with that information.
public partial class ViewOneProfilePage : ContentPage
{
    Employee singleEmployee = new Employee();

    // Constructor requires an employee record to be used and set.
    public ViewOneProfilePage(Employee employ)
	{
		InitializeComponent();

        singleEmployee = employ;

        // Concatenated spaces are for formatting purposes.
        IdDetail.Text = " " + singleEmployee.Id;
        NameDetail.Text = " " + singleEmployee.Name;
        PhoneNoDetail.Text = " " + singleEmployee.PhoneNo;
        DepartmentDetail.Text = " " + singleEmployee.Department;
        StreetDetail.Text = " " + singleEmployee.Street;
        CityDetail.Text = " " + singleEmployee.City;
        StateDetail.Text = " " + singleEmployee.State;
        ZipDetail.Text = " " + singleEmployee.Zip;
        CountryDetail.Text = " " + singleEmployee.Country;
    }

    // Returns user to previous page.
    private async void NavigateBackButton_Clicked(object sender, EventArgs e)
    {
        await Navigation.PopModalAsync();
        SemanticScreenReader.Announce(NavigateBackButton.Text);
    }

    // Sends user to UpdateProfile page, using the current profile's details as information
    private async void NavigateUpdateProfileButton_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushModalAsync(new UpdateProfilePage(singleEmployee));
        SemanticScreenReader.Announce(NavigateUpdateProfileButton.Text);
    }
}