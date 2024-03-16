using NutriApp.Components.ContentPageCustomer;

namespace NutriApp.Views.Evaluation.CircumferenceWaist;

public partial class CircumferenceWaistPage : BaseContentPage
{
    public CircumferenceWaistPage()
    {
        InitializeComponent();
        BindingContext = new CircumferenceWaistViewModel();
    }
}