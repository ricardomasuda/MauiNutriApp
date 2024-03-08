namespace NutriApp.Views.Evaluation.BodyComposition;

public partial class BodyCompositionPage : ContentPage
{
    public BodyCompositionPage()
    {
        InitializeComponent();
        BindingContext = new BodyCompositionPageViewModel();
    }
}