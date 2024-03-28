using NutriApp.Components.ContentPageCustomer;

namespace NutriApp.Views.Evaluation.CircumferenceCalf;

public partial class CircumferenceCalfPage : BaseContentPage
{
    public CircumferenceCalfPage()
    {
        InitializeComponent();
        BindingContext = new CircumferenceCalfViewModel();
    }
}