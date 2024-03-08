namespace NutriApp.Views.Evaluation.AdequacyWeight;

public partial class AdequacyWeightPage : ContentPage
{
    public AdequacyWeightPage()
    {
        InitializeComponent();
        BindingContext = new AdequacyWeightViewModel();
    }
}