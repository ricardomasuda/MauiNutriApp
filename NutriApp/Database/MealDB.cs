namespace NutriApp.Database;

public class MealDB
{
    public MealDB()
    {
        App.Database.CreateTableAsync<MealModel>().Wait();
    }

    public async Task<MealModel> ConsultarAsync(int id)
    {
        return await App.Database.Table<MealModel>()
            .Where(i => i.Id == id)
            .FirstOrDefaultAsync();
    }

    public async Task<List<MealModel>> ListarAsync()
    {
        return await App.Database.Table<MealModel>().ToListAsync();
    }

    public async Task<List<MealModel>> ListarAsyncWhere(int id)
    {
        return await App.Database.Table<MealModel>().Where(i => i.FoodPLanId == id).ToListAsync();
    }

    public async Task<ObservableCollection<MealModel>> ListarMealWhere(int idFoodPlan)
    {
        return new ObservableCollection<MealModel>(
            (await new MealDB().ListarAsyncWhere(idFoodPlan)).OrderBy(x => x.Horario));
    }

    public async Task<int> ExcluirTotalAsync(int id)
    {
        MealModel mealModel = await ConsultarAsync(id);
        if (mealModel != null)
        {
            return await App.Database.DeleteAsync(mealModel);
        }

        return 0;
    }

    public async Task<int> AtualizarAsync(MealModel newMeal)
    {
        try
        {
            return await App.Database.UpdateAsync(newMeal);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public async Task<bool> SalvarAsync(MealModel meal)
    {
        try
        {
            int id;
            if (meal.FoodPLanId == 0) throw new ArgumentException("Não se pode cadastrar uma refeição sem plano");

            List<FoodModel> listFood = new List<FoodModel>(meal.ListFood);
            meal.ListFood.Clear();

            if (meal.Id == 0)
            {
                id = await CadastrarAsync(meal);
            }
            else
            {
                id = await AtualizarAsync(meal);
            }

            foreach (FoodModel foodModel in listFood)
            {
                foodModel.MealId = id;
            }
            //listFood.ForEach(x => x.MealId = meal.Id);

            await new MealFoodDB().SalvarList(listFood, meal.Id);

            return id > 0;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }

    }

    public async Task<int> CadastrarAsync(MealModel meal)
    {
        return await App.Database.InsertAsync(meal);
    }
}