namespace NutriApp.Views.FoodPlan.FoodDetail;

public partial class MealFoodDetailPage : ContentPage
{
    public MealFoodDetailPage()
    {
        InitializeComponent();
        BindingContext = new MealFoodDetailViewModel(this);
        
    }

    public void OnItemSelected(string name)
    {
        if (!string.IsNullOrEmpty(name))
            PIckerRefeicao.SelectedIndex = (new MealModel().SearchMealType(name).Id - 1);
    }
}