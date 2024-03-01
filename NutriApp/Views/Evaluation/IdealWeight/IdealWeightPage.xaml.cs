namespace NutriApp.AppNutri.View.Evaluation.IdealWeight;

public partial class IdealWeightPage : ContentPage
{
    public IdealWeightPage()
    {
        InitializeComponent();
        BindingContext = new IdealWeightViewModel();
    }
}