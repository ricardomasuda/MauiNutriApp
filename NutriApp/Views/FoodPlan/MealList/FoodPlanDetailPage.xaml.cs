using NutriApp.Components.ContentPageCustomer;

namespace NutriApp.Views.FoodPlan.MealList;

public partial class FoodPlanDetailPage : BaseContentPage
{
    // TODO - MUDAR NOME DA CLASSE PAGE E VIEWMODEL
    public FoodPlanDetailPage()
    {
        InitializeComponent();
        BindingContext = new FoodPlanDetailPageViewModel();
    }
}