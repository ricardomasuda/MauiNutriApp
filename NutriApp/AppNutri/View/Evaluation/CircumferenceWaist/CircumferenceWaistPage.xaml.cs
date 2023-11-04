namespace NutriApp.AppNutri.View.Evaluation.CircumferenceWaist;

public partial class CircumferenceWaistPage : ContentPage
{
    public CircumferenceWaistPage()
    {
        InitializeComponent();
        BindingContext = new CircumferenceWaistViewModel(this);
    }
}