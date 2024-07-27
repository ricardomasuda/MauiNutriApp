using MauiLib1.Components.ModalFlyout;
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

    private void BindableObject_OnPropertyChanged(object sender, PropertyChangedEventArgs e)
    {
        throw new NotImplementedException();
    }
}