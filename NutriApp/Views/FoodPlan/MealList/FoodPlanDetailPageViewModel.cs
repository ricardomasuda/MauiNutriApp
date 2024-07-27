using NutriApp.Views.Food.Detail;
using NutriApp.Views.FoodPlan.FoodDetail;

namespace NutriApp.Views.FoodPlan.MealList;

[QueryProperty(nameof(FoodPlanModel), nameof(FoodPlanModel))]
public partial class FoodPlanDetailPageViewModel : BaseViewModel, IQueryAttributable
{
    [ObservableProperty]
    private bool _emptyList;
    [ObservableProperty]
    private ObservableCollection<MealModel> _listMeal;
        
    public FoodPlanModel FoodPlanModel;
        
    public FoodPlanDetailPageViewModel()
    {
        Fetch();
    }

    private async Task Fetch()
    {
        ObservableCollection<MealModel> listMeal = new ();
        if(FoodPlanModel is not null) listMeal = await new MealDB().ListarMealWhere(FoodPlanModel.Id);
        foreach (var mealModel in listMeal)
        {
            var foodModel = await MealService.GetFoodModelForMeal(mealModel);
            FoodService.AddUnitMeasureToValues(FoodService.RoundMacro(foodModel));
            mealModel.Carboidratos = foodModel.Carboidratos;
            mealModel.Proteinas = foodModel.Proteinas;
            mealModel.Lipidios = foodModel.Lipidios;
            mealModel.ValorTotal = foodModel.ValorCalorico;
            mealModel.Horario = Convert.ToDateTime(mealModel.Horario).ToString("HH:mm");
        }

        ListMeal = listMeal;
        EmptyList = listMeal.Count == 0;
    }
    
    [RelayCommand]
    private void GoFoodDetail(object obj)
    {
        MealModel mealModel = (MealModel)obj;
        App.NavPage.GoToAsync( nameof(MealFoodDetailPage));
        //App.NavPage.GoToAsync( FoodDetailPage(this,mealModel));
    }
    
    [RelayCommand]
    private void AddFood()
    {
        App.NavPage.GoToAsync(nameof(MealFoodDetailPage));
        //App.NavPage.PushAsync(new FoodDetailPage(this));
    }
    
    public void ApplyQueryAttributes(IDictionary<string, object> query)
    {
        FoodPlanModel = query[nameof(FoodPlanModel)] as FoodPlanModel;
    }
}