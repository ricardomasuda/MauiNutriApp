namespace NutriApp.Views.Food.Detail;

public partial class FoodDetailPage {
    public FoodDetailPage() {
        InitializeComponent();
        BindingContext = new FoodDetailViewModel();
    }

    // private void InputView_OnTextChanged(object sender, TextChangedEventArgs e)
    // {
    //     bool isNull = string.IsNullOrEmpty(e.NewTextValue);
    //     FoodDetailViewModel.ChangeMeasure(isNull);
    // }
}