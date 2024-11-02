using CommunityToolkit.Maui.Views;
using NutriApp.Views.FoodPlan.SelectFood.SelectFoodPopup;

namespace NutriApp.Views.FoodPlan.FoodDetail.SelectList;

public partial class SelectListFoodPopupViewModel : BaseViewModel
{
    public MealFoodDetailViewModel MealFoodDetailViewModel { get; set; }

    public SelectListFoodPopupViewModel( MealFoodDetailViewModel mealFoodDetailViewModel)
    {
        MealFoodDetailViewModel = mealFoodDetailViewModel;
    }

    [RelayCommand]
    private async Task EditFood(object obj)
    {
        FoodModel food = (FoodModel)obj;
        await App.NavPage.GoToModalAsync( new SelectFoodPopup(MealFoodDetailViewModel, food));
    }
    
    [RelayCommand]
    private static void Close(Popup popup)
    {
        App.NavPage.GoBackModal();
    }
}