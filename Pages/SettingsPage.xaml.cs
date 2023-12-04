using Microsoft.Maui.Graphics.Text;

namespace MobileApp.Pages;

// Page handles some data bindings to change features of the app
public partial class SettingsPage : ContentPage
{
    SettingsViewModel currentSetting;
	public SettingsPage(SettingsViewModel setting)
	{
		InitializeComponent();
        currentSetting = setting;
    }

    // Returns user to MainPage
    private async void SettingsBackButton_Clicked(object sender, EventArgs e)
    {
        await Navigation.PopModalAsync();
        SemanticScreenReader.Announce(SettingsBackButton.Text);
    }

    // Changes MainPage background according to the switch toggle
    private void DarkBackgroundSwitch_Toggled(object sender, ToggledEventArgs e)
    {
        if (DarkBackgroundSwitch.IsToggled == true)
        {
            currentSetting.background = "black_texture_image.png";
            SemanticScreenReader.Announce("Dark backgrounds on");
        }
        else
        {
            currentSetting.background = "roi_pattern_3.png";
            SemanticScreenReader.Announce("Dark backgrounds off");
        }
    }
}