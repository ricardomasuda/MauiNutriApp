using CommunityToolkit.Maui.Views;
using NutriApp.Views.FoodPlan.FoodDetail;

namespace NutriApp.Views.FoodPlan.SelectFood.SelectFoodPopup;

public partial class SelectFoodPopup : Popup
{
    public SelectFoodPopup(MealFoodDetailViewModel mealFoodDetailViewModel, FoodModel food = null)
    {
        InitializeComponent();
        BindingContext = new SelectFoodPopupViewModel(mealFoodDetailViewModel,this, food);
    }
}