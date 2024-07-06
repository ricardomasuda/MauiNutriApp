using CommunityToolkit.Maui.Views;
using NutriApp.Views.FoodPlan.SelectFood.SelectFoodPopup;

namespace NutriApp.Views.FoodPlan.FoodDetail.SelectList;

public partial class SelectListFoodPopupViewModel : BaseViewModel
{
    [ObservableProperty]
    private ObservableCollection<FoodModel> _listFood;
    private MealFoodDetailViewModel MealFoodDetailViewModel { get; set; }

    public SelectListFoodPopupViewModel(IEnumerable<FoodModel> listFood, MealFoodDetailViewModel mealFoodDetailViewModel)
    {
        ListFood = new ObservableCollection<FoodModel>(listFood);
        MealFoodDetailViewModel = mealFoodDetailViewModel;
    }

    [RelayCommand]
    private async Task EditFood(object obj)
    {
        FoodModel food = (FoodModel)obj;
        await App.NavPage.GoToAsync( nameof(SelectFoodPopup));
        //await App.NavPage.ShowPopup(new SelectFoodPopup(MealFoodDetailViewModel, food));
    }
    
    [RelayCommand]
    private static void Close(Popup popup)
    {
        popup.Close();
    }
}