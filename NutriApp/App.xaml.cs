using NutriApp.Database.Configuration;
using NutriApp.Views.MainPage;
using SQLite;

namespace NutriApp;

public partial class App : Application
{
    public static NavigationPage NavPage { get; set; }
    public static SQLiteAsyncConnection Database;
    public App()
    {
        Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("Mjk2MjY4MkAzMjMzMmUzMDJlMzBFMnRySklPRjR4cGlWZ0U4WDFRR3NGOWkwUzF1VEZVd0tHRm1oUkwyUU5NPQ==");
        InitializeComponent();
        
        NavPage = new NavigationPage(new MainPage());
        MainPage = NavPage;
        Database = new BancoContext().Connection();
    }
}