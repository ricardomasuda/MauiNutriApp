namespace NutriApp.Views.FoodPlan.FoodDetail;

public partial class MealFoodDetailPage : ContentPage
{
    public MealFoodDetailPage()
    {
        InitializeComponent();
        BindingContext = new MealFoodDetailViewModel(); 
        //if (meal != null)
            //PIckerRefeicao.SelectedIndex = (new MealModel().SearchMealType(meal.Nome).Id - 1);
    }
}