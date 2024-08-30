using CommunityToolkit.Maui;
using MauiLib1;
using MauiLib1.Components.Entries;
using MauiLib1.Navigation;
using Microsoft.Extensions.Logging;

namespace NutriApp;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();

        builder.Services.AddSingleton<INavigationService, NavigationService>();
        
        builder
            .UseMauiApp<App>()
            .UseMauiCommunityToolkit()
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                fonts.AddFont("Font Awesome 6 Free-Regular-400.otf", "FontAwesomeRegular");
                fonts.AddFont("Font Awesome 6 Free-Solid-900.otf", "FontAwesomeBold");
            }).ConfigureMauiHandlers(handlers =>
            {
#if IOS
                handlers.AddHandler(typeof(BorderlessEntry), typeof(BorderlessEntryHandler));
                handlers.AddHandler(typeof(CustomSearchBar), typeof(CustomSearchBarHandler));
#endif
            });
            
            ;

#if DEBUG
        builder.Logging.AddDebug();
#endif

        return builder.Build();
    }
}