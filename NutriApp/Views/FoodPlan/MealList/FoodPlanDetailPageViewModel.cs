using NutriApp.Views.Food.Detail;
using NutriApp.Views.FoodPlan.FoodDetail;

namespace NutriApp.Views.FoodPlan.MealList;

[QueryProperty(nameof(FoodPlanModel), nameof(FoodPlanModel))]
public partial class FoodPlanDetailPageViewModel : BaseViewModel, IQueryAttributable
{
    [ObservableProperty] private bool _emptyList;
    [ObservableProperty] private ObservableCollection<MealModel> _listMeal;
    [ObservableProperty] private ObservableCollection<MealModel> _listMealAux;

    public FoodPlanModel FoodPlanModel;

    public FoodPlanDetailPageViewModel()
    {
        Fetch();
    }

    private async Task Fetch()
    {
        ObservableCollection<MealModel> listMealAux = new ();
        if (FoodPlanModel is not null)
        {
            listMealAux = await new MealDB().ListarMealWhere(FoodPlanModel.Id);
            foreach (var mealModel in listMealAux)
            {
                var foodModel = await MealService.GetFoodModelForMeal(mealModel);
                FoodService.AddUnitMeasureToValues(FoodService.RoundMacro(foodModel));
                mealModel.Carboidratos = foodModel.Carboidratos;
                mealModel.Proteinas = foodModel.Proteinas;
                mealModel.Lipidios = foodModel.Lipidios;
                mealModel.ValorTotal = foodModel.ValorCalorico;
                mealModel.Horario = Convert.ToDateTime(mealModel.Horario).ToString("HH:mm");
            }
        }
        if(listMealAux.Count == 0) return;
        
        ListMeal = new ObservableCollection<MealModel>(listMealAux);
        EmptyList = listMealAux.Count == 0;
    }

    [RelayCommand]
    private void GoFoodDetail(object obj)
    {
        MealModel mealModel = (MealModel)obj;
        ShellNavigationQueryParameters navigationParameter = new()
        {
            { nameof(MealModel), mealModel },
            { nameof(FoodPlanDetailPageViewModel), this }
        };
        App.NavPage.GoToAsync(nameof(MealFoodDetailPage), navigationParameter);
        //App.NavPage.GoToAsync( FoodDetailPage(this,mealModel));
    }

    [RelayCommand]
    private void AddFood()
    {
        ShellNavigationQueryParameters navigationParameter = new()
        {
            { nameof(FoodPlanDetailPageViewModel), this }
        };
        App.NavPage.GoToAsync(nameof(MealFoodDetailPage), navigationParameter);
        //App.NavPage.PushAsync(new FoodDetailPage(this));
    }

    public async void ApplyQueryAttributes(IDictionary<string, object> query)
    {
        FoodPlanModel = GetQueryValue<FoodPlanModel>(query, nameof(FoodPlanModel));
        await Fetch();
    }
}