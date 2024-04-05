using CommunityToolkit.Maui.Views;
using MauiLib1.View;

namespace MauiLib1.Navigation;

public class NavigationService : INavigationService
{
    private bool _isNavigationInProgress;
    private bool _isPopupDisplayed;
    public async Task GoToAsync(ShellNavigationState state)
    {
        if (_isNavigationInProgress) return; 
        _isNavigationInProgress = true; 
        
        try
        { 
            var loadingPage = new LoadPage();
            Shell.Current.CurrentPage.ShowPopup(loadingPage);
            await Shell.Current.GoToAsync(state);
            loadingPage.HidePopupPage();
            if (DeviceInfo.Current.Platform == DevicePlatform.iOS)
                loadingPage.HidePopupPage();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
        }
        finally
        {
            _isNavigationInProgress = false; 
        }
    }
    
    public async Task ShowPopup(Popup popup)
    {
        if (_isPopupDisplayed) return; 
        _isPopupDisplayed = true; 
        
        try
        {
            await Shell.Current.CurrentPage.ShowPopupAsync(popup);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
        }
        finally
        {
            _isPopupDisplayed = false; 
        }
    }
    public Task GoToAsync(ShellNavigationState state, bool animate) => Shell.Current.GoToAsync(state, animate);
    public Task GoToAsync(ShellNavigationState state, IDictionary<string, object> parameters) => Shell.Current.GoToAsync(state, parameters);
    public Task GoToAsync(ShellNavigationState state, bool animate, IDictionary<string, object> parameters) => Shell.Current.GoToAsync(state, animate, parameters);
    public Task GoToAsync(ShellNavigationState state, ShellNavigationQueryParameters shellNavigationQueryParameters) => Shell.Current.GoToAsync(state, shellNavigationQueryParameters);
    public Task GoToAsync(ShellNavigationState state, bool animate, ShellNavigationQueryParameters shellNavigationQueryParameters) => Shell.Current.GoToAsync(state, animate, shellNavigationQueryParameters);

   
    public Task GoBackAsync() => Shell.Current.GoToAsync("..");
}