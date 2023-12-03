using SQLite;
using System.IO;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using System.Text;

namespace MobileApp.Pages;

// Page is for viewing the details of one specific profile from the database.
// From the page, the user can either return to the previous page, or
// navigate to the UpdateProfile page to change details in the profile and
// update the database with that information.
public partial class ViewOneProfilePage : ContentPage
{
    Employee singleEmployee = new Employee();
    Database databaseService = new Database();

    // Constructor requires an employee record to be used and set.
    public ViewOneProfilePage(Employee employ)
	{
		InitializeComponent();

        singleEmployee = employ;
    }

    // When this page appears (push or pop), refresh details to meet updated standards
    protected async override void OnAppearing()
    {
        List<Employee> employeeList = await databaseService.RetrieveEmployees();
        foreach (Employee e in employeeList)
        {
            if (e.Id == singleEmployee.Id)
            {
                singleEmployee = e;

                IdDetail.Text = singleEmployee.Id;
                NameDetail.Text = singleEmployee.Name;
                PhoneNoDetail.Text = singleEmployee.PhoneNo;
                DepartmentDetail.Text = singleEmployee.Department;
                StreetDetail.Text = singleEmployee.Street;
                CityDetail.Text = singleEmployee.City;
                StateDetail.Text = singleEmployee.State;
                ZipDetail.Text = singleEmployee.Zip;
                CountryDetail.Text = singleEmployee.Country;
                break;
            }
        }
    }

    // Returns user to previous page.
    private async void NavigateBackButton_Clicked(object sender, EventArgs e)
    {
        await Navigation.PopModalAsync();
        SemanticScreenReader.Announce("Returning to View All Profiles Page");
    }

    // Sends user to UpdateProfile page, using the current profile's details as information
    private async void NavigateUpdateProfileButton_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushModalAsync(new UpdateProfilePage(singleEmployee));
        SemanticScreenReader.Announce("Heading to Update Profile Page.");
    }
}