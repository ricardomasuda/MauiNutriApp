namespace NutriApp.AppNutri.View.Food.List;

public partial class FoodListPage : ContentPage
{
    public FoodListViewModel FoodViewModel { get; set; }
    public FoodListPage()
    {
        InitializeComponent();
        //BindingContext = new FoodListViewModel();
    }
    
    protected override void OnAppearing()
    {
        base.OnAppearing();
        BindingContext = new FoodListViewModel();
    }
    
    // private void SearchBar_TextChanged(object sender, TextChangedEventArgs e)
    // {
    //     ListFood.ItemsSource = string.IsNullOrEmpty(e.NewTextValue) ? FoodViewModel.ListFood : FoodViewModel.ListFood.Where(x => x.Nome.ToUpper().Contains(e.NewTextValue.ToUpper()));
    // } 
    
    protected override bool OnBackButtonPressed()
    {
        App.NavPage.PopAsync();
        return base.OnBackButtonPressed();
    }
}