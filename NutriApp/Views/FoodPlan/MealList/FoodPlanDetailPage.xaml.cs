namespace NutriApp.Views.FoodPlan.MealList;

public partial class FoodPlanDetailPage : ContentPage
{
    // TODO - MUDAR NOME DA CLASSE PAGE E VIEWMODEL
    public FoodPlanDetailPage()
    {
        InitializeComponent();
        BindingContext = new FoodPlanDetailPageViewModel();
    }
}