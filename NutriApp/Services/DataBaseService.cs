namespace NutriApp.Services;

public class DataBaseService {
    public static async Task<ObservableCollection<FoodModel>> ListFoods() {
        return new(await new FoodDb().FoodListAsync());
    }

    public static async Task<ObservableCollection<FoodPlanModel>> GetPlanFoods() {
        return new ObservableCollection<FoodPlanModel>(await new FoodPlanDB().ListarAsync());
    }

    public static async Task<ObservableCollection<MealFoodModel>> GetMealFoodWhere(int foodPLanId) {
        return new ObservableCollection<MealFoodModel>(await new MealFoodDB().ListarWhereAsync(foodPLanId));
    }

    // public static async Task<ObservableCollection<PatientModel>> GetPatient()
    // {
    //     return new ObservableCollection<PatientModel>(await new PatientDB().ListarAsync());
    // }

    public static async Task<ObservableCollection<FoodModel>> GetFoodWhere(int foodPLanId) {
        return new ObservableCollection<FoodModel>(
            await FoodService.GetListFoodModel(await new MealFoodDB().ListarWhereAsync(foodPLanId)));
    }
}