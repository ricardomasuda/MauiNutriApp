using System.Collections.ObjectModel;
using NutriApp.AppNutri.Model;

namespace NutriApp.AppNutri.BancoDados;

public class FoodDb
{
    public FoodDb()
    {
        App.Database.CreateTableAsync<FoodModel>().Wait();
    }
    public async Task<IOrderedEnumerable<FoodModel>> ListarAsync()
    {
        var foodListResult = new List<FoodModel>();
        var foodList = await App.Database.Table<FoodModel>().ToListAsync();
        foreach (var foodModel in foodList)
        {
            foodModel.Nome = foodModel.Nome.Replace("-Não se aplica", "");
            foodListResult.Add(foodModel);
        }
        //TODO - ARRUMAR LISTAGEM
        //return foodListResult.OrderBy(food => food.Nome);
        return foodListResult.Take(500).OrderBy(food => food.Nome);
    }

    public async Task<int> CadastrarListaAsync(FoodModel foodModel)
    {
        return await App.Database.InsertAsync(foodModel);
    }
        
    public async Task<int> AtualizarAsync(FoodModel foodModel)
    {
        return await App.Database.UpdateAsync(foodModel);
    }

    public async Task<int> DeleteTotalAsync(int id)
    {
        // Delete a note.
        var foodModel = await ConsultarAsync(id);
        if (foodModel != null)
        {
            return await App.Database.DeleteAsync(foodModel);
        }

        return 0;
    }

    public async Task<FoodModel> ConsultarAsync(int id)
    {
        return await App.Database.Table<FoodModel>()
            .Where(i => i.Id == id)
            .FirstOrDefaultAsync();
    }
    public async Task<bool> UpdateListAsync(ObservableCollection<FoodModel> listFood)
    {
        foreach (var outsideFood in listFood)
        {
            var food = await ConsultarAsync(outsideFood.Id);
            if (food == null)
            {
                await CadastrarListaAsync(outsideFood);
            }
            else
            {
                await AtualizarAsync(outsideFood);
            }
        }
        return true;
    }
}