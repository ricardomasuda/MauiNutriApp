using Foundation;
using Microsoft.Maui.Handlers;
using UIKit;
using MauiLib1.Components.Entries;
using Microsoft.Maui.Controls.PlatformConfiguration.iOSSpecific;
using SearchBar = Microsoft.Maui.Controls.SearchBar;
using UISearchBarStyle = UIKit.UISearchBarStyle;

public class CustomSearchBarHandler : SearchBarHandler
{
    public CustomSearchBarHandler() : base(PropertyMapper, CommandMapper)
    {
    }

    public static IPropertyMapper<CustomSearchBar, CustomSearchBarHandler> PropertyMapper =
        new PropertyMapper<CustomSearchBar, CustomSearchBarHandler>(SearchBarHandler.Mapper)
        {
            [nameof(SearchBar.BackgroundColor)] = MapBackgroundColor
        };

    public static CommandMapper<CustomSearchBar, CustomSearchBarHandler> CommandMapper =
        new CommandMapper<CustomSearchBar, CustomSearchBarHandler>(SearchBarHandler.CommandMapper);

    public static void MapBackgroundColor(CustomSearchBarHandler handler, CustomSearchBar searchBar)
    {
        handler.PlatformView.BackgroundImage = new UIImage();
        handler.PlatformView.BackgroundColor = UIColor.Clear;

        var searchTextField = handler.PlatformView.ValueForKey(new NSString("_searchField")) as UITextField;
        if (searchTextField != null)
        {
            searchTextField.BackgroundColor = UIColor.Clear;
            searchTextField.BorderStyle = UITextBorderStyle.None;
            searchTextField.Layer.BorderColor = UIColor.Clear.CGColor;
            searchTextField.LeftViewMode = UITextFieldViewMode.Always; // Garante que o ícone da lupa sempre esteja visível
        }

        // Remove bordas e outros elementos visuais indesejados
        handler.PlatformView.SearchBarStyle = UISearchBarStyle.Minimal;
    }
}