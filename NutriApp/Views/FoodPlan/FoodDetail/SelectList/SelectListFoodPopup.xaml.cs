namespace NutriApp.Views.FoodPlan.FoodDetail.SelectList;

public partial class SelectListFoodPopup 
{
    public SelectListFoodPopup(MealFoodDetailViewModel mealFoodDetailViewModel)
    {
        InitializeComponent();
        BindingContext = new SelectListFoodPopupViewModel(mealFoodDetailViewModel);
    }
}