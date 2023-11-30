using SQLite;
using System.IO;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MobileApp.Pages;

public partial class UpdateProfilePage : ContentPage
{
    Database databaseService;
    List<Employee> employees = new List<Employee>();
    SQLiteAsyncConnection _database;

    Employee singleEmployee;
	public UpdateProfilePage(Employee employ)
	{
		InitializeComponent();

        databaseService = new Database();

        singleEmployee = employ;

        IdEntry.Text = singleEmployee.Id;
        NameEntry.Text = singleEmployee.Name;
        PhoneNoEntry.Text = singleEmployee.PhoneNo;
        DepartmentEntry.Text = singleEmployee.Department;
        StreetEntry.Text = singleEmployee.Street;
        CityEntry.Text = singleEmployee.City;
        StateEntry.Text = singleEmployee.State;
        ZipEntry.Text = singleEmployee.Zip;
        CountryEntry.Text = singleEmployee.Country;
    }

    private async void UpdateProfileBack(object sender, EventArgs e)
    {
        await Navigation.PopModalAsync();
        SemanticScreenReader.Announce(CancelButton3.Text);
    }

    // Gets and updates an Employee record in the database. NOTE: Remove Id from being allowed to be updated, as it is a primary key, and cannot be updated.
    public async void UpdateEmployeeRecord_Clicked(object sender, EventArgs e)
    {
            singleEmployee.Id = IdEntry.Text;
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
            await Navigation.PopModalAsync();
    }
}