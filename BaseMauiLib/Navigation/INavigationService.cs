using CommunityToolkit.Maui.Views;

namespace MauiLib1.Navigation;

public interface INavigationService {
    Task ShowPopup(Popup popup);
    Task GoToAsync(ShellNavigationState state);
    Task GoToAsync(ShellNavigationState state, bool animate);
    Task GoToAsync(ShellNavigationState state, IDictionary<string, object> parameters);
    Task GoToAsync(ShellNavigationState state, bool animate, IDictionary<string, object> parameters);
    Task GoToAsync(ShellNavigationState state, ShellNavigationQueryParameters shellNavigationQueryParameters);
    Task GoToAsync(ShellNavigationState state, bool animate, ShellNavigationQueryParameters shellNavigationQueryParameters);
    Task GoToModalAsync(Page page);
    Task GoBackModal();
    Task GoBackAsync();
}