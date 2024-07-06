using CommunityToolkit.Maui.Views;

namespace NutriApp.Views.FoodPlan.FoodDetail.SelectList;

public partial class SelectListFoodPopup : Popup
{
    public SelectListFoodPopup(IEnumerable<FoodModel> listFood, MealFoodDetailViewModel mealFoodDetailViewModel)
    {
        InitializeComponent();
        BindingContext = new SelectListFoodPopupViewModel(listFood, mealFoodDetailViewModel);
    }
}