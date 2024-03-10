using NutriApp.Components.ContentPageCustomer;

namespace NutriApp.Views.Evaluation.IdealWeight;

public partial class IdealWeightPage : BaseContentPage
{
    public IdealWeightPage()
    {
        InitializeComponent();
        BindingContext = new IdealWeightViewModel(this);
    }
}