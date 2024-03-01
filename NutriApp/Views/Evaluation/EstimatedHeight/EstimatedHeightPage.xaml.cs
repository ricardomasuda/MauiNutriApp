namespace NutriApp.AppNutri.View.Evaluation.EstimatedHeight;

public partial class EstimatedHeightPage : ContentPage
{
    public EstimatedHeightPage()
    {
        InitializeComponent();
        BindingContext = new EstimatedHeightPageViewModel();
    }
}