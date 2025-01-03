namespace NutriApp.Database;

public class ValueReferenceDB
{
    public ValueReferenceDB()
    {
        App.Database.CreateTableAsync<ValueReferenceModel>().Wait();
    }

    public async Task<List<ValueReferenceModel>> ListarWhereAsync(int foodId)
    {
        return await App.Database.Table<ValueReferenceModel>().Where(x => x.FoodPlanId == foodId).ToListAsync();
    }

    public async Task<int> CadastrarAsync(ValueReferenceModel valueReference)
    {
        if (valueReference.FoodPlanId == 0) throw new ArgumentException("Não se pode cadastrar um valor de referencia sem plano");

        await ExcluirWhereAsync(valueReference.FoodPlanId);

        return await App.Database.InsertAsync(valueReference);
    }

    public async Task<bool> ExcluirWhereAsync(int foodId)
    {
        List<ValueReferenceModel> list = await ListarWhereAsync(foodId);
        if (list.Count == 0) return false;
        foreach (var valueReferenceModel in list)
        {
            await ExcluirTotalAsync(valueReferenceModel.Id);
        }

        return true;
    }

    public async Task<int> ExcluirTotalAsync(int id)
    {
        ValueReferenceModel valueReference = await ConsultarAsync(id);
        return await App.Database.DeleteAsync(valueReference);
    }

    public async Task<ValueReferenceModel> ConsultarWhereAsync(int foodPlanId)
    {
        try
        {
            return await App.Database.Table<ValueReferenceModel>()
                .Where(i => i.FoodPlanId == foodPlanId)
                .FirstOrDefaultAsync();
        }
        catch (Exception e)
        {
            return null;
        }
    }

    public async Task<ValueReferenceModel> ConsultarAsync(int id)
    {
        return await App.Database.Table<ValueReferenceModel>()
            .Where(i => i.Id == id)
            .FirstOrDefaultAsync();
    }
}