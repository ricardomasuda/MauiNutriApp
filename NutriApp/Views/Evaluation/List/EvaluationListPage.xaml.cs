namespace NutriApp.AppNutri.View.Evaluation.List;

public partial class EvaluationListPage : ContentPage
{
    public EvaluationListPage()
    {
        InitializeComponent();
        BindingContext = new EvaluationListPageViewModel();
    }
}