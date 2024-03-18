namespace NutriApp.Database;

public class FoodDb {
    public FoodDb() {
        App.Database.CreateTableAsync<FoodModel>().Wait();
    }

    public async Task<IEnumerable<FoodModel>> FoodListAsync() {
        return await App.Database.Table<FoodModel>().OrderBy(food => food.Nome).ToListAsync();
    }

    public async Task<int> CadastrarListaAsync(FoodModel foodModel) {
        return await App.Database.InsertAsync(foodModel);
    }

    public async Task<int> AtualizarAsync(FoodModel foodModel) {
        return await App.Database.UpdateAsync(foodModel);
    }

    public async Task<int> DeleteTotalAsync(int id) {
        // Delete a note.
        var foodModel = await ConsultarAsync(id);
        if (foodModel != null) return await App.Database.DeleteAsync(foodModel);

        return 0;
    }

    public async Task<FoodModel> ConsultarAsync(int id) {
        return await App.Database.Table<FoodModel>()
            .Where(i => i.Id == id)
            .FirstOrDefaultAsync();
    }

    public async Task<bool> UpdateListAsync(ObservableCollection<FoodModel> listFood) {
        foreach (var outsideFood in listFood) {
            var food = await ConsultarAsync(outsideFood.Id);
            if (food == null)
                await CadastrarListaAsync(outsideFood);
            else
                await AtualizarAsync(outsideFood);
        }

        return true;
    }
}