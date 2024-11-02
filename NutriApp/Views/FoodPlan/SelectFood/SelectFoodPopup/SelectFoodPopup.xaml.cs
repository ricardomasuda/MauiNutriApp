using NutriApp.Views.FoodPlan.FoodDetail;
using FlyoutPage = MauiLib1.Components.ModalFlyout.FlyoutPage;

namespace NutriApp.Views.FoodPlan.SelectFood.SelectFoodPopup;

public partial class SelectFoodPopup : FlyoutPage
{
    public SelectFoodPopup(MealFoodDetailViewModel mealFoodDetailViewModel, FoodModel food = null)
    {
        InitializeComponent();
        BindingContext = new SelectFoodPopupViewModel(mealFoodDetailViewModel,this, food);
    }
    
}