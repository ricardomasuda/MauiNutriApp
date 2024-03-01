namespace NutriApp.AppNutri.View.Evaluation.AdequacyWeight;

public partial class AdequacyWeightPage : ContentPage
{
    public AdequacyWeightPage()
    {
        InitializeComponent();
        BindingContext = new AdequacyWeightViewModel();
    }
}