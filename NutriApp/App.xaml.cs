using NutriApp.AppNutri.View.MainPage;

namespace NutriApp;

public partial class App : Application
{
    public static NavigationPage NavPage { get; set; }
    public App()
    {
        Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("Mjk2MjY4MkAzMjMzMmUzMDJlMzBFMnRySklPRjR4cGlWZ0U4WDFRR3NGOWkwUzF1VEZVd0tHRm1oUkwyUU5NPQ==");
        InitializeComponent();

        NavPage = new NavigationPage(new MainPage());
        MainPage = NavPage;
    }
}