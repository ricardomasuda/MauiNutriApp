using NutriApp.Components.ContentPageCustomer;

namespace NutriApp.Views.AnthropometricEvaluation;

public partial class AnthropometricEvaluationPage : BaseContentPage
{
    public AnthropometricEvaluationPage()
    {
        InitializeComponent();
        BindingContext = new AnthropometricEvaluationViewModel(this);
    }

    public bool ValidateViewData()
    {
        return BodyCompositionViewTeste.ValidateViewData();
    }
}