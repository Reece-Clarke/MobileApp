﻿using MobileApp.Pages;

namespace MobileApp;

// Represents initial page on application start.
// Can navigate to the AddProfile, ViewAllProfiles, and Settings page.
public partial class MainPage : ContentPage
{
    SettingsViewModel setting;

    public MainPage()
    {
        setting = new SettingsViewModel();
        BindingContext = setting;
        InitializeComponent();
    }

    // Navigates to the AddProfile page when clicked.
    private async void NavigateAddProfileButton_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushModalAsync(new AddProfilePage());
        SemanticScreenReader.Announce(NavigateAddProfileButton.Text);
    }

    // Navigates to the ViewAllProfiles page when clicked.
    private async void NavigateAllProfilesButton_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushModalAsync(new ViewAllProfilesPage());
        SemanticScreenReader.Announce(NavigateAddProfileButton.Text);
    }

    // Navigates to the Settings page when clicked.
    private async void NavigateSettingsButton_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushModalAsync(new SettingsPage(setting));
        SemanticScreenReader.Announce(NavigateSettingsButton.Text);
    }
}
