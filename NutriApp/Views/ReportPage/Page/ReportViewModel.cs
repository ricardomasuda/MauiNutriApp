namespace NutriApp.Views.ReportPage.Page;

[QueryProperty("listFood", "listFood")]
[QueryProperty("foodPlanId", "foodPlanId")]
[QueryProperty(nameof(Title), nameof(Title))]
public partial class ReportViewModel : BaseViewModel, IQueryAttributable
{
    [ObservableProperty] private List<FoodModel> _listFood;
    [ObservableProperty] private int _height;
    [ObservableProperty] private int _foodPlanId;
    [ObservableProperty] private bool _hasDisplayFood;
    [ObservableProperty] private bool _hasValueReference;
    
    public ReportPage ReportPage { get; set; }

    public new string Title { get; set; }
    public NutrientsModel NutrientsModel { get; set; }
    public ValueReferenceModel ValueReferenceModel { get; set; }

    public ReportViewModel(List<FoodModel> listFood, string title = null, int foodPlanId = default)
    {
    }

    private async Task FetchValueReference()
    {
        if (FoodPlanId == 0) return;
        ValueReferenceModel = await new ValueReferenceDB().ConsultarWhereAsync(FoodPlanId);
        HasValueReference = ValueReferenceModel != null;
    }
    
    [RelayCommand]
    private async Task ShareReportImage()
    {
        //await ReportPage.ShareReport();
    }
    
    [RelayCommand]
    private static void Close(CommunityToolkit.Maui.Views.Popup popup)
    {
        popup.Close();
    }

    private void Fill()
    {
        NutrientsModel = new NutrientsModel();
        FetchValueReference();
        CalculateFood();
        DynamicList();
        HasFood();
    }

    private void HasFood()
    {
        if (ListFood.Count == 1)
        {
            if (ListFood[0].Id == 0)
            {
                HasDisplayFood = false;
                return;
            }
        }

        HasDisplayFood = true;
    }

    private void CalculateFood()
    {
        var food = FoodService.SumFoodNutrients(ListFood);
        NutrientsModel.Carboidratos = food.Carboidratos;
        NutrientsModel.Proteina = food.Proteinas;
        NutrientsModel.Lipidio = food.Lipidios;
        NutrientsModel.Sodio = food.Sodio;
        NutrientsModel.FibraAlimentar = food.FibraAlimentar;
        NutrientsModel.ValorCalorico = food.ValorCalorico;
        NutrientsModel.Medida = food.Medida;
        NutrientsModel.Calcio = food.Calcio;
        NutrientsModel.Magnesio = food.Magnesio;
        NutrientsModel.Manganes = food.Manganes;
        NutrientsModel.Fosforo = food.Fosforo;
        NutrientsModel.Ferro = food.Ferro;
        NutrientsModel.Potassio = food.Potassio;
        NutrientsModel.Cobre = food.Cobre;
        NutrientsModel.Zinco = food.Zinco;
        NutrientsModel.VitaminaA = food.VitaminaA;
        NutrientsModel.VitaminaB1 = food.VitaminaB1;
        NutrientsModel.VitaminaB2 = food.VitaminaB2;
        NutrientsModel.VitaminaB3 = food.VitaminaB3;
        NutrientsModel.VitaminaB6 = food.VitaminaB6;
        NutrientsModel.VitaminaC = food.VitaminaC;
    }

    private void DynamicList()
    {
        Height = ListFood.Count * 40;
    }
    
    public void ApplyQueryAttributes(IDictionary<string, object> query)
    {
        ListFood = query["listFood"] as List<FoodModel>;
        FoodPlanId = query["foodPlanId"] is int ? (int)query["foodPlanId"] : 0;
        Title = query[nameof(Title)] as string;
        Fill();
    }
    
}