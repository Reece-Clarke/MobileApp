using SQLite;
using System.IO;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MobileApp.Pages;

public partial class ViewAllProfilesPage : ContentPage
{
    // Initialize Database Services
    Database databaseService;
    List<Employee> employees = new List<Employee>();
    SQLiteAsyncConnection _database;

    public ViewAllProfilesPage()
	{
        InitializeComponent();

        // Database functions and list assigned
        databaseService = new Database();
        RefreshEmployeeList();

        //var someone = new List<Someone>()
        //{   new Someone { id = "1", name = "Smith" },
        //    new Someone { id = "2", name = "Black" }};

        //// Uses DatabaseList[PH] to be viewed as a list in-page
        //AllProfileListView.ItemsSource = someone;

    }

    // Returns user to previous page.
    private async void BackButton1_Clicked(object sender, EventArgs e)
    {
        await Navigation.PopModalAsync();
        SemanticScreenReader.Announce(BackButton1.Text);
    }

    // Sends user to profile details page for selected profile from list
    //private async void ProfileDetailButton_Clicked(object sender, EventArgs e)
    //{
    //    // If a profile has been selected from the list
    //    if (AllProfileListView.SelectedItem != null)
    //    {
    //        var selectedEmployee = (Employee)AllProfileListView.SelectedItem;
    //        await Navigation.PushModalAsync(new ViewOneProfilePage());
    //    }
    //}

    // When a item is tapped or clicked on, navigate to its profile details page
    private async void AllProfileListView_ItemTapped(object sender, ItemTappedEventArgs e)
    {
        if (AllProfileListView.SelectedItem != null)
        {
            var selectedEmployee = (Employee)AllProfileListView.SelectedItem;
            await Navigation.PushModalAsync(new ViewOneProfilePage(selectedEmployee));
        }
    }

    /////////////////////////
    // Database Interactions
    //
    // Retrieves and assigns Employee records to AllProfileListView.
    private async void RefreshEmployeeList()
    {
        AllProfileListView.ItemsSource = await databaseService.RetrieveEmployees();
    }


    // Gets and updates an Employee record in the database based on list selection  CORRECT
    public async void UpdatePersons_Clicked(object sender, EventArgs e)
    {
        if (AllProfileListView.SelectedItem != null)
        {
            //Get and set selected Employee
            var selectedEmployee = (Employee)AllProfileListView.SelectedItem;

            // Update parts of the selected Employee object
            selectedEmployee.Name = "1";

            // Update selected Employee in database, through another function
            await databaseService.UpdateEmployeeAsync(selectedEmployee);
            RefreshEmployeeList();

        }

        //return databaseService.Update(person);
    }

    // Delete a selected Employee record from the database using another function CORRECT
    public async void DeletePersons(object sender, EventArgs e)
    {
        if (AllProfileListView.SelectedItem != null)
        {
            //Get and set selected Employee
            var selectedEmployee = (Employee)AllProfileListView.SelectedItem;

            // Update selected Employee in database
            await databaseService.DeleteEmployeeAsync(selectedEmployee);
            RefreshEmployeeList();
        }

    }


}



//public class Someone
//{
//    public string id { get; set; }
//    public string name { get; set; }
//}

