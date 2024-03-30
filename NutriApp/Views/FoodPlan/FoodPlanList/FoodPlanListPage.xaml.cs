using NutriApp.Components.ContentPageCustomer;

namespace NutriApp.Views.FoodPlan.FoodPlanList;

public partial class FoodPlanListPage : BaseContentPage
{
    public FoodPlanListPage()
    {
        InitializeComponent();
        BindingContext = new FoodPlanListViewModel();
    }
}