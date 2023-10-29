using NutriApp.AppNutri.View.MainPage;

namespace NutriApp;

public partial class App : Application
{
    public static NavigationPage NavPage { get; set; }
    public App()
    {
        InitializeComponent();

        NavPage = new NavigationPage(new MainPage());
        MainPage = NavPage;
    }
}