namespace NutriApp.Views.Suggestion;

public partial class SuggestionPage : ContentPage
{
    public SuggestionPage()
    {
        InitializeComponent();
        BindingContext = new SuggestionViewModel();
    }
}