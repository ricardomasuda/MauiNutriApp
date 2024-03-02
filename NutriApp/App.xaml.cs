﻿using NutriApp.AppNutri.BancoDados.Config;
using NutriApp.AppNutri.View;
using NutriApp.AppNutri.View.MainPage;
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

        MainPage = new AppShell();
        // NavPage = new NavigationPage(new MainPage());
        // MainPage = NavPage;
        Database = new BancoContext().Connection();
    }
}