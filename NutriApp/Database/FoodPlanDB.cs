using NutriApp.Models;

namespace NutriApp.Database;

public class FoodPlanDB
{
    public FoodPlanDB()
    {
        try
        {
            App.Database.CreateTableAsync<FoodPlanModel>().Wait();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
        
    public async Task<FoodPlanModel> ConsultarAsync(int id)
    {
        return await App.Database.Table<FoodPlanModel>()
            .Where(i => i.Id == id)
            .FirstOrDefaultAsync();
    }

    public async Task<List<FoodPlanModel>> ListarAsync()
    {
        return await App.Database.Table<FoodPlanModel>().ToListAsync();
    }
        
    public async Task<int> AtualizarAsync(FoodPlanModel foodModel)
    {
        return await App.Database.UpdateAsync(foodModel);
    }

    public async Task<int> ExcluirTotalAsync(int id)
    {
        FoodPlanModel foodPlanModel = await ConsultarAsync(id);
            
        MealDB meal = new MealDB();
            
        var listMeal = await meal.ListarMealWhere(foodPlanModel.Id);
        foreach (var mealModel in listMeal)
        {
            await meal.ExcluirTotalAsync(mealModel.Id);
        }

        return await App.Database.DeleteAsync(foodPlanModel);
    }

    public async Task<int> CadastrarAsync(FoodPlanModel foodPLan)
    {
        await App.Database.InsertAsync(foodPLan);
        return (await App.Database.Table<FoodPlanModel>().ToListAsync()).LastOrDefault()!.Id;
    }
}