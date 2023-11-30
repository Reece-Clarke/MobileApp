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
    //List<Employee> employees = new List<Employee>();
    //SQLiteAsyncConnection _database;

    public ViewAllProfilesPage()
	{
        InitializeComponent();

        // Database functions and list assigned
        databaseService = new Database();
        RefreshEmployeeList();
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

    private void RefreshListButton_Clicked(object sender, EventArgs e)
    {
        RefreshEmployeeList();
    }

    // Delete a selected Employee record from the database
    private async void DeleteProfileButton_Clicked(object sender, EventArgs e)
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

    /////////////////////////
    // Database Interactions
    //
    // Retrieves and assigns Employee records to AllProfileListView.
    public async void RefreshEmployeeList()
    {
        AllProfileListView.ItemsSource = await databaseService.RetrieveEmployees();
    }

}
