using System.Collections.ObjectModel;
using NutriApp.AppNutri.BancoDados;
using NutriApp.AppNutri.Model;

namespace NutriApp.AppNutri.service;

public class DataBaseService
{
    public static async Task<ObservableCollection<FoodModel>> GetFoods()
    {
        return new ObservableCollection<FoodModel>(await new FoodDB().ListarAsync());
    }

    public static async Task<ObservableCollection<FoodPlanModel>> GetPlanFoods()
    {
        return new ObservableCollection<FoodPlanModel>(await new FoodPlanDB().ListarAsync());
    }

    public static async Task<ObservableCollection<MealFoodModel>> GetMealFoodWhere(int foodPLanId)
    {
        return new ObservableCollection<MealFoodModel>(await new MealFoodDB().ListarWhereAsync(foodPLanId));
    }

    // public static async Task<ObservableCollection<PatientModel>> GetPatient()
    // {
    //     return new ObservableCollection<PatientModel>(await new PatientDB().ListarAsync());
    // }

    public static async Task<ObservableCollection<FoodModel>> GetFoodWhere(int foodPLanId)
    {
        return new ObservableCollection<FoodModel>(
            await FoodService.GetListFoodModel(await new MealFoodDB().ListarWhereAsync(foodPLanId)));
    }
}