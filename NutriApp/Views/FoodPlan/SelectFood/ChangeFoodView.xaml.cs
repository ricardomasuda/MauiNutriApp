using NutriApp.Views.FoodPlan.SelectFood.SelectFoodPopup;

namespace NutriApp.Views.FoodPlan.SelectFood;

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