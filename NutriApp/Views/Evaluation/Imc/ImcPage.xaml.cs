namespace NutriApp.Views.Evaluation.Imc;

public partial class ImcPage : ContentPage
{
    public ImcPage()
    {
        InitializeComponent();
        BindingContext = new ImcPageViewModel();
    }
}