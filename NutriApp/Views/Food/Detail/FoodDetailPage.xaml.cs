using NutriApp.Models;

namespace NutriApp.Views.Food.Detail;

public partial class FoodDetailPage : ContentPage
{
    private readonly FoodModel _food;
    private FoodDetailViewModel FoodDetailViewModel { get; set; }
    public FoodDetailPage(FoodModel food)
    {
        _food = food;
        InitializeComponent();
    }
    protected override void OnAppearing()
    {
        base.OnAppearing();
        FoodDetailViewModel = new FoodDetailViewModel(this, _food);
        BindingContext = FoodDetailViewModel;
    }

    private void InputView_OnTextChanged(object sender, TextChangedEventArgs e)
    {
        bool isNull = string.IsNullOrEmpty(e.NewTextValue);
        FoodDetailViewModel.ChangeMeasure(isNull);
    }
}