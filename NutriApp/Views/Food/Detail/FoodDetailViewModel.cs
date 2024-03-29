namespace NutriApp.Views.Food.Detail;

[QueryProperty(nameof(Food), "food")]
public class FoodDetailViewModel : BaseViewModel, IQueryAttributable
{
    private double _measure;
    public double Measure
    {
        get => _measure;
        set
        {
            _measure = value;
            OnPropertyChanged();
        }
    }

    private string _carbohydrates;

    public string Carbohydrates
    {
        get => _carbohydrates;
        set
        {
            _carbohydrates = value;
            OnPropertyChanged();
        }
    }

    private string _proteins;

    public string Proteins
    {
        get => _proteins;
        set
        {
            _proteins = value;
            OnPropertyChanged();
        }
    }

    private string _lipids;

    public string Lipids
    {
        get => _lipids;
        set
        {
            _lipids = value;
            OnPropertyChanged();
        }
    }

    private string _sodium;
    public string Sodium
    {
        get => _sodium;
        set
        {
            _sodium = value;
            OnPropertyChanged();
        }
    }

    private string _dietaryFiber;

    public string DietaryFiber
    {
        get => _dietaryFiber;
        set
        {
            _dietaryFiber = value;
            OnPropertyChanged();
        }
    }

    private string _calorificValue;
    public string CalorificValue
    {
        get => _calorificValue;
        set
        {
            _calorificValue = value;
            OnPropertyChanged();
        }
    }
    
    private FoodModel _food;
    public FoodModel Food
    {
        get => _food;
        set
        {
            _food = value;
            OnPropertyChanged();
        }
    }

    public string Source { get; set; }
    public Command InfoCommand { get; set; }
    public Command GoReportCommand { get; set; }

    public FoodDetailViewModel()
    {
        //InfoCommand = new Command(() => foodDetailPage.ShowPopup(new InformationFoodPopup()));
        GoReportCommand = new Command(GoReport);
        Fill();
    }

    public async void ChangeMeasure(bool isZero)
    {
        if (Food == null) return;
        Measure = isZero ? 0 : Measure;
        var food = await FoodService.ChangeUnitMeasure(Food.Id, Measure);
        Carbohydrates = food.Carboidratos;
        Proteins = food.Proteinas;
        Lipids = food.Lipidios;
        Sodium = food.Sodio;
        DietaryFiber = food.FibraAlimentar;
        CalorificValue = food.ValorCalorico;
    }

    private void Fill()
    {
        if (Food != null)
            Measure = Convert.ToInt32(Food.Medida) != 0 ? Convert.ToDouble(Food.Medida) : 100;
        else
            Measure = 100;
        Source = Food != null ? FoodReference.GetReference(Food.Fonte) : null;
        
    }

    private async void GoReport()
    {
        // var foodReport = await FoodService.ChangeUnitMeasure(Food.Id, Measure);
        // List<FoodModel> listFood = new List<FoodModel> { foodReport };
        // await App.NavPage.PushAsync(new ReportPage(listFood));
    }
    public void ApplyQueryAttributes(IDictionary<string, object> query)
    {
        Food = query["food"] as FoodModel;
        ChangeMeasure(false);
    }
    
}