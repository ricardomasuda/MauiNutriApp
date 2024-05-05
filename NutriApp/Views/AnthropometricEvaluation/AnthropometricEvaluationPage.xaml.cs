namespace NutriApp.Views.AnthropometricEvaluation;

public partial class AnthropometricEvaluationPage : ContentPage
{
    public AnthropometricEvaluationPage()
    {
        InitializeComponent();
        BindingContext = new AnthropometricEvaluationViewModel();
    }
}