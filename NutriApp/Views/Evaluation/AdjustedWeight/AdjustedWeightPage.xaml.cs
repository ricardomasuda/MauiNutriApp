using NutriApp.Components.ContentPageCustomer;

namespace NutriApp.Views.Evaluation.AdjustedWeight;

public partial class AdjustedWeightPage : BaseContentPage
{
    public AdjustedWeightPage()
    {
        InitializeComponent();
        BindingContext = new AdjustedWeightPageViewModel();
    }
}