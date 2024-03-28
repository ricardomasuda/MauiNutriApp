using NutriApp.Components.ContentPageCustomer;

namespace NutriApp.Views.Evaluation.EstimatedWeight;

public partial class EstimatedWeightPage : BaseContentPage
{
    public EstimatedWeightPage()
    {
        InitializeComponent();
        BindingContext = new EstimatedWeightPageViewModel();
    }
}