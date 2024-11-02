using NutriApp.Views.FoodPlan.FoodPlanList.NewFoodPlan;
using NutriApp.Views.FoodPlan.MealList;

namespace NutriApp.Views.FoodPlan.FoodPlanList;

public partial class FoodPlanListViewModel : BaseViewModel, IQueryAttributable
{
    [ObservableProperty] private ObservableCollection<FoodPlanModel> _listFoodPlan;

    public FoodPlanListViewModel()
    {
        //Fetch();
    }

    public async void Fetch()
    {
        var listFoodPlanAux = await DataBaseService.GetPlanFoods();
        foreach (var foodPlanModel in listFoodPlanAux)
        {
            FoodModel superFood = await MealService.GetMealListFood(foodPlanModel);
            FoodService.AddUnitMeasureToValues(FoodService.RoundMacro(superFood));

            foodPlanModel.Carboidratos = superFood.Carboidratos;
            foodPlanModel.Proteinas = superFood.Proteinas;
            foodPlanModel.Lipidios = superFood.Lipidios;
            foodPlanModel.ValorTotal = superFood.ValorCalorico;
            if (superFood.Carboidratos != "0g" || superFood.Proteinas != "0g" || superFood.Lipidios != "0g")
            {
                MacronutrientModel macronutrientModel =
                    FoodPlanService.CalculateMacronutrientPercentage(FoodPlanService.BuildMacronutrient(superFood));
                foodPlanModel.CarboidratosPorcentagem = $"({macronutrientModel.Carb}%)";
                foodPlanModel.ProteinasPorcentagem = $"({macronutrientModel.Protein}%)";
                foodPlanModel.LipidiosPorcentagem = $"({macronutrientModel.Lipid}%)";
            }
        }

        ListFoodPlan = listFoodPlanAux;
    }

    [RelayCommand]
    private async Task EditFoodPlan(object obj)
    {
        var foodPlan = (FoodPlanModel)obj;
        await App.NavPage.GoToModalAsync(new FoodPlanPopup(this, foodPlan));
    }

    [RelayCommand]
    private async Task AddFoodPlan()
    {
        // if (ListFoodPlan.Count >= 3)
        // {
        //     await Shell.Current.DisplayAlert("Só é possível criar três Planos",
        //         "Por enquanto só é possível criar três planos", "Ok");
        // }
        // else
        // {
            await App.NavPage.GoToModalAsync(new FoodPlanPopup(this));
        //}
    }

    [RelayCommand]
    private void GoToFoodPlanDetail(object obj)
    {
        FoodPlanModel foodPlan = (FoodPlanModel)obj;
        ShellNavigationQueryParameters navigationParameter = new()
        {
            { nameof(FoodPlanModel), foodPlan }
        };
        App.NavPage.GoToAsync(nameof(FoodPlanDetailPage), navigationParameter);
    }

    [RelayCommand]
    private async Task GoToReport(object obj)
    {
        var foodPlan = (FoodPlanModel)obj;

        var superFood = await MealService.GetMealListFood(foodPlan);

        if (Convert.ToDouble(superFood.ValorCalorico) == 0)
        {
            await Shell.Current.DisplayAlert("Nenhum alimento adicionado",
                "Adicione um alimento para poder gerar relatório", "Ok");
            return;
        }
        List<FoodModel> listFood = new() { superFood };
        ShellNavigationQueryParameters navigationParameter = new() {
            { "FoodList", listFood },
            { "FoodPlanId", foodPlan.Id},
            { "Title", foodPlan.Nome}
        };
        await App.NavPage.GoToAsync(nameof(ReportPage), navigationParameter);
    }

    public void ApplyQueryAttributes(IDictionary<string, object> query)
    {
        Fetch();
    }
}