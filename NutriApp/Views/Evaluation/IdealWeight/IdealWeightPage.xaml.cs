namespace NutriApp.Views.Evaluation.IdealWeight;

public partial class IdealWeightPage : ContentPage
{
    public IdealWeightPage()
    {
        InitializeComponent();
        BindingContext = new IdealWeightViewModel();
    }
}