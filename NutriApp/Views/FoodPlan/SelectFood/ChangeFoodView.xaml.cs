using NutriApp.AppNutri.View.FoodPlan.SelectFood.SelectFoodPopup;

namespace NutriApp.AppNutri.View.FoodPlan.SelectFood;

public partial class ChangeFoodView : ContentPage
{
    public SelectFoodPopupViewModel SelectFoodViewModel { get; set; }
    private ChangeFoodViewModel ChangeFoodViewModel { get; set; }

    public ChangeFoodView(SelectFoodPopupViewModel foodDetailViewModel)
    {
        InitializeComponent();
        ChangeFoodViewModel = new ChangeFoodViewModel(foodDetailViewModel);
        BindingContext = ChangeFoodViewModel;
    }

}