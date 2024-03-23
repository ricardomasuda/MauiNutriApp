using NutriApp.Components.ContentPageCustomer;

namespace NutriApp.Views.Evaluation.BodyComposition;

public partial class BodyCompositionPage : BaseContentPage
{
    public BodyCompositionPage()
    {
        InitializeComponent();
        BindingContext = new BodyCompositionPageViewModel();
    }
}