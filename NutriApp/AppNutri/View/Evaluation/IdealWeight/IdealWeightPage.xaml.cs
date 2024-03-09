using NutriApp.AppNutri.Componente.ContentPageCustomer;

namespace NutriApp.AppNutri.View.Evaluation.IdealWeight;

public partial class IdealWeightPage : BaseContentPage
{
    public IdealWeightPage()
    {
        InitializeComponent();
        BindingContext = new IdealWeightViewModel(this);
    }
}