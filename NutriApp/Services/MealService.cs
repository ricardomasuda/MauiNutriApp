namespace NutriApp.Services;

public static class MealService
{
    public static async Task<FoodModel> GetFoodModelForMeal(MealModel mealModel)
    {
        var foodModel = await DataBaseService.GetFoodWhere(mealModel.Id);
        return FoodService.SumFoodNutrients(foodModel.ToList()); 
    }

    public static async Task<FoodModel> GetMealListFood(FoodPlanModel foodPlanModel)
    {
        var listMeal = await new MealDB().ListarMealWhere(foodPlanModel.Id);
                
        var listFoodModel = new List<FoodModel>();
        foreach (var mealModel in listMeal)
        {
            var foodModel = await GetFoodModelForMeal(mealModel);
            listFoodModel.Add(foodModel);
        }
        return FoodService.SumFoodNutrients(listFoodModel);
    }
}