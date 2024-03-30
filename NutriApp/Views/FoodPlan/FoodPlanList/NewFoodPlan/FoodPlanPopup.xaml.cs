using CommunityToolkit.Maui.Views;

namespace NutriApp.Views.FoodPlan.FoodPlanList.NewFoodPlan;

public partial class FoodPlanPopup : Popup
{
    private FoodPlanPopupViewModel FoodPlanPopupViewModel { get; set; }
    public FoodPlanPopup(FoodPlanListViewModel foodPlanListViewModel, FoodPlanModel foodPlanList = null)
    {
        InitializeComponent();
        FoodPlanPopupViewModel = new FoodPlanPopupViewModel(foodPlanListViewModel, foodPlanList);
        FoodPlanPopupViewModel.FoodPlanPopup = this;
        BindingContext = FoodPlanPopupViewModel;
    }

    public void Close()
    {
        this.Close();
    }
}