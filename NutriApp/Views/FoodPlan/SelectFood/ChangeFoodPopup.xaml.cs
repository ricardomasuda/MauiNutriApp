using CommunityToolkit.Maui.Views;
using NutriApp.Components.Titles.View;
using NutriApp.Views.FoodPlan.SelectFood.SelectFoodPopup;

namespace NutriApp.Views.FoodPlan.SelectFood;

public partial class ChangeFoodPopup : Popup
{
    public SelectFoodPopupViewModel SelectFoodViewModel { get; set; }
    private ChangeFoodPopupViewModel ChangeFoodPopupViewModel { get; set; }

    public ChangeFoodPopup(SelectFoodPopupViewModel foodDetailViewModel)
    {
        InitializeComponent();
        ChangeFoodPopupViewModel = new ChangeFoodPopupViewModel(foodDetailViewModel, this);
        BindingContext = ChangeFoodPopupViewModel;
    }
    
    private void OnSizeChanged(object sender, EventArgs e) {
        if (sender is SearchTitleView searchTitleView) ChangeFoodPopupViewModel.SearchTitleHeight = searchTitleView.Height;
        if (sender is VerticalStackLayout verticalStackLayout) ChangeFoodPopupViewModel.CollectionViewCellHeight = verticalStackLayout.Height;
    }

}