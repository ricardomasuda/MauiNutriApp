using NutriApp.Components.Titles.View;

namespace NutriApp.Views.Food.List;

public partial class FoodListPage {
    private readonly FoodListViewModel _viewModel = new();

    public FoodListPage() {
        InitializeComponent();
        BindingContext = _viewModel;
    }


    // private void SearchBar_TextChanged(object sender, TextChangedEventArgs e)
    // {
    //     ListFood.ItemsSource = string.IsNullOrEmpty(e.NewTextValue) ? FoodViewModel.ListFood : FoodViewModel.ListFood.Where(x => x.Nome.ToUpper().Contains(e.NewTextValue.ToUpper()));
    // } 

    protected override bool OnBackButtonPressed() {
        App.NavPage.PopAsync();
        return base.OnBackButtonPressed();
    }

    private void OnSizeChanged(object sender, EventArgs e) {
        if (sender is SearchTitleView searchTitleView) _viewModel.SearchTitleHeight = searchTitleView.Height;
        if (sender is VerticalStackLayout verticalStackLayout) _viewModel.CollectionViewCellHeight = verticalStackLayout.Height;
    }
}