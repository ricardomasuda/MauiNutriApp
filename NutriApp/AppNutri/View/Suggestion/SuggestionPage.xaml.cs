namespace NutriApp.AppNutri.View.Suggestion;

public partial class SuggestionPage : ContentPage
{
    public SuggestionPage()
    {
        InitializeComponent();
        BindingContext = new SuggestionViewModel();
    }
}