namespace NutriApp.AppNutri.View.Food.Detail;


public partial class FoodDetailPage : ContentPage
{
    private FoodDetailViewModel FoodDetailViewModel { get; set; }
    public FoodDetailPage()
    {
        InitializeComponent();
        //BindingContext = new FoodDetailViewModel(this);
    }
    protected override void OnAppearing()
    {
        base.OnAppearing();
      
    }

    // private void InputView_OnTextChanged(object sender, TextChangedEventArgs e)
    // {
    //     bool isNull = string.IsNullOrEmpty(e.NewTextValue);
    //     FoodDetailViewModel.ChangeMeasure(isNull);
    // }
}