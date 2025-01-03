namespace NutriApp.Views.ReportPage.Page;

[QueryProperty(nameof(FoodList), "listFood")]
[QueryProperty("FoodPlanId", "foodPlanId")]
[QueryProperty(nameof(Title), nameof(Title))]
public partial class ReportViewModel : BaseViewModel, IQueryAttributable
{
    [ObservableProperty] private List<FoodModel> _foodList;
    [ObservableProperty] private int _height;
    [ObservableProperty] private int _foodPlanId;
    [ObservableProperty] private bool _hasDisplayFood;
    [ObservableProperty] private bool _hasValueReference;
    [ObservableProperty] private NutrientsModel _nutrientsModel;
    [ObservableProperty] private bool _isFinish;
    
    public ReportPage ReportPage { get; set; }

    [ObservableProperty] private new string _title;
    
    public ValueReferenceModel ValueReferenceModel { get; set; }

    public ReportViewModel(List<FoodModel> listFood, string title = null, int foodPlanId = default)
    {
        FoodList = listFood;
        FoodPlanId = foodPlanId;
        Title = title;
        Fill();
    }
    
    public ReportViewModel()
    {
      
    }

    private async Task FetchValueReference()
    {
        if (FoodPlanId == 0) return;
        ValueReferenceModel = await new ValueReferenceDB().ConsultarWhereAsync(FoodPlanId);
        HasValueReference = ValueReferenceModel != null;
    }
    
    [RelayCommand]
    private async Task ShareReportImage(Microsoft.Maui.Controls.Page reportStackLayout)
    {
        await SharePdfUtil.CaptureAndSharePageAsPdf(reportStackLayout);
    }
    
    [RelayCommand]
    private static void Close(CommunityToolkit.Maui.Views.Popup popup)
    {
        App.NavPage.GoBackModal();
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
        if (FoodList.Count == 1)
        {
            if (FoodList[0].Id == 0)
            {
                HasDisplayFood = false;
                return;
            }
        }

        HasDisplayFood = true;
    }

    private void CalculateFood()
    {
        var food = FoodService.SumFoodNutrients(FoodList);
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
        IsFinish = true;
    }

    private void DynamicList()
    {
        Height = FoodList.Count * 40;
    }
    
    public void ApplyQueryAttributes(IDictionary<string, object> query)
    {
        FoodList = GetQueryValue<List<FoodModel>>(query, nameof(FoodList));
        FoodPlanId = GetQueryValue<int>(query, nameof(FoodPlanId));
        Title = GetQueryValue<string>(query, nameof(Title));
        Fill();
    }
    
}