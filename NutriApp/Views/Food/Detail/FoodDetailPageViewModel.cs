using System.Windows.Input;
using CommunityToolkit.Maui.Views;
using NutriApp.Views.Food.Detail.InfoPopup;

namespace NutriApp.Views.Food.Detail;

[QueryProperty(nameof(Food), "food")]
public partial class FoodDetailPageViewModel : BaseViewModel, IQueryAttributable
{
    [ObservableProperty]
    private double _measure;
    [ObservableProperty]
    private string _carbohydrates;
    [ObservableProperty]
    private string _proteins;
    [ObservableProperty]
    private string _lipids;
    [ObservableProperty]
    private string _sodium;
    [ObservableProperty]
    private string _dietaryFiber;
    [ObservableProperty]
    private string _calorificValue;
    [ObservableProperty]
    private FoodModel _food;
    public string Source { get; set; }
    public ICommand InfoCommand { get; set; }

    public FoodDetailPageViewModel()
    {
        InfoCommand = new RelayCommand(() => Shell.Current.CurrentPage.ShowPopup(new InformationFoodPopup()));
        Fill();
    }

    [RelayCommand]
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
    
    [RelayCommand]
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