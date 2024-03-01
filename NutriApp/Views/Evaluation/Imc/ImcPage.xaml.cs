namespace NutriApp.AppNutri.View.Evaluation.Imc;

public partial class ImcPage : ContentPage
{
    public ImcPage()
    {
        InitializeComponent();
        BindingContext = new ImcPageViewModel();
    }
}