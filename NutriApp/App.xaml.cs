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
       InitializeComponent();

        
        MainPage = new AppShell();
        // NavPage = new NavigationPage(new MainPage());
        // MainPage = NavPage;
        Database = new BancoContext().Connection();
    }
}