namespace NutriApp.Database;

public class MealFoodDB
{
    public MealFoodDB()
    {
        App.Database.CreateTableAsync<MealFoodModel>().Wait();
    }

    public async Task<List<MealFoodModel>> ListarWhereAsync(int mealId)
    {
        return await App.Database.Table<MealFoodModel>().Where(x => x.MealId == mealId).ToListAsync();
    }

    public async Task<MealFoodModel> ConsultarAsync(int id)
    {
        return await App.Database.Table<MealFoodModel>()
            .Where(i => i.Id == id)
            .FirstOrDefaultAsync();
    }

    public async Task SalvarList(List<FoodModel> listFood, int mealId)
    {
        foreach (var food in listFood)
        {
            var mealFoodModel = new MealFoodModel()
            {
                Id = food.MealFoodId, FoodId = food.Id,
                Medida = Convert.ToDouble(Utils.RemoveUnityMeasure(food.Medida)), MealId = mealId
            };
            await SalvarAsync(mealFoodModel);
        }
    }

    private async Task SalvarAsync(MealFoodModel food)
    {
        if (food.MealId == 0) throw new ArgumentException("Não se pode cadastrar um alimento sem refeição");
        if (food.Id == 0)
            await CadastrarAsync(food);
        else
            await AtualizarAsync(food);
    }

    public async Task<int> CadastrarAsync(MealFoodModel mealFoodModel)
    {
        return await App.Database.InsertAsync(mealFoodModel);
    }

    private async Task<int> AtualizarAsync(MealFoodModel newMealFoodModel)
    {
        try
        {
            MealFoodModel oldMealFoodModel = await ConsultarAsync(newMealFoodModel.Id);
            await ExcluirAsync(oldMealFoodModel.Id);
            return await CadastrarAsync(newMealFoodModel);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public async Task<int> ExcluirAsync(int mealFoodId)
    {
        MealFoodModel mealFoodModel = await ConsultarAsync(mealFoodId);
        if (mealFoodModel != null)
        {
            return await App.Database.DeleteAsync(mealFoodModel);
        }

        return 0;
    }
}