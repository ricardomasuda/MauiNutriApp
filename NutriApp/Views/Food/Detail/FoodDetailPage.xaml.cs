using NutriApp.Components.ContentPageCustomer;

namespace NutriApp.Views.Food.Detail;

public partial class FoodDetailPage : BaseContentPage
{
    private FoodDetailPageViewModel FoodDetailPageViewModel { get; set; }
    public FoodDetailPage()
    {
        InitializeComponent();
        FoodDetailPageViewModel= new FoodDetailPageViewModel();
        BindingContext = FoodDetailPageViewModel;
    }
    
    //TODO - Em um proximo PR alterar essa logica 
    private void InputView_OnTextChanged(object sender, TextChangedEventArgs e)
    {
        bool isNull = string.IsNullOrEmpty(e.NewTextValue);
        FoodDetailPageViewModel.ChangeMeasure(isNull);
    }
}