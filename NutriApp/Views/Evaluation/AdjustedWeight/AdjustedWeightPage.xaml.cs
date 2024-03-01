namespace NutriApp.AppNutri.View.Evaluation.AdjustedWeight;

public partial class AdjustedWeightPage : ContentPage
{
    public AdjustedWeightPage()
    {
        InitializeComponent();
        BindingContext = new AdjustedWeightPageViewModel();
    }
}