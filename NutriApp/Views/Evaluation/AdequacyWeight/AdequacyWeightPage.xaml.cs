using NutriApp.Components.ContentPageCustomer;

namespace NutriApp.Views.Evaluation.AdequacyWeight;

public partial class AdequacyWeightPage : BaseContentPage
{
    public AdequacyWeightPage()
    {
        InitializeComponent();
        BindingContext = new AdequacyWeightViewModel();
    }
}