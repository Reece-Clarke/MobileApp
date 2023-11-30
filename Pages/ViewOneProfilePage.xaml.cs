using SQLite;
using System.IO;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MobileApp.Pages;

public partial class ViewOneProfilePage : ContentPage
{
    // Initialize Database Services
    Database databaseService;
    List<Employee> employees = new List<Employee>();
    SQLiteAsyncConnection _database;

    Employee singleEmployee = new Employee();

    // Constructor requires an employee record to be used and set.
    public ViewOneProfilePage(Employee employ)
	{
		InitializeComponent();
        databaseService = new Database();

        singleEmployee = employ;

        IdDetail.Text = singleEmployee.Id;
        NameDetail.Text = singleEmployee.Name;
        PhoneNoDetail.Text = singleEmployee.PhoneNo;
        DepartmentDetail.Text = singleEmployee.Department;
        StreetDetail.Text = singleEmployee.Street;
        CityDetail.Text = singleEmployee.City;
        StateDetail.Text = singleEmployee.State;
        ZipDetail.Text = singleEmployee.Zip;
        CountryDetail.Text = singleEmployee.Country;
    }

    private async void BackButton2_Clicked(object sender, EventArgs e)
    {
        await Navigation.PopModalAsync();
        SemanticScreenReader.Announce(BackButton2.Text);
    }

    private async void GoToUpdateProfileButton_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushModalAsync(new UpdateProfilePage());
        SemanticScreenReader.Announce(GoToUpdateProfileButton.Text);
    }
}