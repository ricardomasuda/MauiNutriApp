namespace NutriApp.Views.Evaluation.List;

public partial class EvaluationListPage : ContentPage
{
    public EvaluationListPage()
    {
        InitializeComponent();
        BindingContext = new EvaluationListPageViewModel();
    }
}