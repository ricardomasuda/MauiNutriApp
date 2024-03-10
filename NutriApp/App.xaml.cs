using MauiLib1.Navigation;
using NutriApp.Database.Configuration;
using NutriApp.Views;
using SQLite;

namespace NutriApp;

public partial class App : Application
{
    public static INavigationService NavPage { get; set; }
    public static SQLiteAsyncConnection Database;
    public App()
    {
        Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("Ngo9BigBOggjHTQxAR8/V1NHaF5cWWdCf1FpRmJGdld5fUVHYVZUTXxaS00DNHVRdkdnWXxedXVURWZdVUFxWUI=");
        InitializeComponent();

        
        MainPage = new AppShell();
        // NavPage = new NavigationPage(new MainPage());
        // MainPage = NavPage;
        Database = new BancoContext().Connection();
    }
}