using NutriApp.Views.FoodPlan.SelectFood.SelectFoodPopup;
using FlyoutPage = MauiLib1.Components.ModalFlyout.FlyoutPage;

namespace NutriApp.Views.FoodPlan.SelectFood;

public partial class ChangeFoodPopup : FlyoutPage
{
    public SelectFoodPopupViewModel SelectFoodViewModel { get; set; }
    private ChangeFoodPopupViewModel ChangeFoodPopupViewModel { get; set; }

    public ChangeFoodPopup(SelectFoodPopupViewModel foodDetailViewModel)
    {
        InitializeComponent();
        ChangeFoodPopupViewModel = new ChangeFoodPopupViewModel(foodDetailViewModel, this);
        BindingContext = ChangeFoodPopupViewModel;
    }

}