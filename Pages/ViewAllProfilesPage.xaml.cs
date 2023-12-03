using SQLite;
using System.IO;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MobileApp.Pages;

// This page is used to view a list of selectable profiles, generated from a database.
// When a profile is selected, it brings the user to a new details page based off that profile.
// The user can also refresh the page and delete profiles from the page and database.
public partial class ViewAllProfilesPage : ContentPage
{
    // Initialize Database Services
    Database databaseService;

    // Used for a double-click function
    int click = 1;
    Employee currentEmployee;

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

    // When a item is double-tapped or doubled-clicked on, navigate to its profile details page
    private async void AllProfileListView_ItemTapped(object sender, ItemTappedEventArgs e)
    {
        // Assign selected item in profile listview if empty.
        if (currentEmployee == null)
        {
            currentEmployee = (Employee)AllProfileListView.SelectedItem;
        }

        // If the currently assigned employee matches the selected employee in list view.
        if (currentEmployee == AllProfileListView.SelectedItem)
        {
            // If double clicked.
            if (click == 2)
            {
                // Reset clicks on double-click.
                click = 1;
                await Navigation.PushModalAsync(new ViewOneProfilePage(currentEmployee));
            }
            // Increase clicks to expect a double-click.
            else
            {
                currentEmployee = (Employee)AllProfileListView.SelectedItem;
                click++;
            }
        }
        // Else Assign the currently selected employee to be the selected employee in list view
        else
        {
            // Resets click in odd cases
            click = 1;
            currentEmployee = (Employee)AllProfileListView.SelectedItem;
            click++;
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

    // Retrieves and assigns Employee records to AllProfileListView.
    public async void RefreshEmployeeList()
    {
        AllProfileListView.ItemsSource = await databaseService.RetrieveEmployees();
    }

}
