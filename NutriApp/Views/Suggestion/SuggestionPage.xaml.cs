using NutriApp.Components.ContentPageCustomer;

namespace NutriApp.Views.Suggestion;

public partial class SuggestionPage : BaseContentPage
{
    public SuggestionPage()
    {
        InitializeComponent();
        BindingContext = new SuggestionViewModel();
    }
}