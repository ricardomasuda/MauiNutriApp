using CommunityToolkit.Maui.Views;
using MauiLib1.View;

namespace MauiLib1.Navigation;

public class NavigationService : INavigationService
{
    public async Task GoToAsync(ShellNavigationState state)
    {
        try
        { 
            var loadingPage = new LoadPage();
            Shell.Current.CurrentPage.ShowPopup(loadingPage);
            await Shell.Current.GoToAsync(state);
            loadingPage.HidePopupPage();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
        }
    }
    
    public async Task ShowPopup(Popup popup)
    {
        try
        {
            var loadingPage = new LoadPage();
            Shell.Current.CurrentPage.ShowPopup(loadingPage);
            Shell.Current.CurrentPage.ShowPopup(popup);
            loadingPage.HidePopupPage();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
        }
        
    }
    public Task GoToAsync(ShellNavigationState state, bool animate) => Shell.Current.GoToAsync(state, animate);
    public Task GoToAsync(ShellNavigationState state, IDictionary<string, object> parameters) => Shell.Current.GoToAsync(state, parameters);
    public Task GoToAsync(ShellNavigationState state, bool animate, IDictionary<string, object> parameters) => Shell.Current.GoToAsync(state, animate, parameters);
    public Task GoToAsync(ShellNavigationState state, ShellNavigationQueryParameters shellNavigationQueryParameters) => Shell.Current.GoToAsync(state, shellNavigationQueryParameters);
    public Task GoToAsync(ShellNavigationState state, bool animate, ShellNavigationQueryParameters shellNavigationQueryParameters) => Shell.Current.GoToAsync(state, animate, shellNavigationQueryParameters);

   
    public Task GoBackAsync() => Shell.Current.GoToAsync("..");
}