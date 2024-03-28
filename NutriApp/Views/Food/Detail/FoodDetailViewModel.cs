using NutriApp.Views.Food.Detail.InfoPopup;

namespace NutriApp.Views.Food.Detail;

[QueryProperty(nameof(SelectedFood), "selectedFood")]
public partial class FoodDetailViewModel : BaseViewModel, IQueryAttributable {
    [ObservableProperty] private double _measure;
    [ObservableProperty] private string _carbohydrates;
    [ObservableProperty] private string _proteins;
    [ObservableProperty] private string _lipids;
    [ObservableProperty] private string _sodium;
    [ObservableProperty] private string _dietaryFiber;
    [ObservableProperty] private string _calorificValue;
    [ObservableProperty] private FoodModel _selectedFood;

    public string Source { get; set; }

    public FoodDetailViewModel() {
        Fill();
    }

    [RelayCommand]
    private void ShowFoodInformation() {
        App.NavPage.ShowPopup(new InformationFoodPopup());
    }

    private async void ChangeMeasure(bool isZero) {
        Measure = isZero ? 0 : Measure;
        FoodModel food = await FoodService.ChangeUnitMeasure(SelectedFood.Id, Measure);

        Carbohydrates = food.Carboidratos;
        Proteins = food.Proteinas;
        Lipids = food.Lipidios;
        Sodium = food.Sodio;
        DietaryFiber = food.FibraAlimentar;
        CalorificValue = food.ValorCalorico;
    }

    private void Fill() {
        Measure = Convert.ToInt32(SelectedFood.Medida) is not 0 ? Convert.ToDouble(SelectedFood.Medida) : 100;
        Source = FoodReference.GetReference(SelectedFood.Fonte);
    }

    [RelayCommand]
    private async void GoReportAsync() {
        FoodModel foodReport = await FoodService.ChangeUnitMeasure(SelectedFood.Id, Measure);
        List<FoodModel> listFood = [foodReport];

        // await App.NavPage.GoToAsync(new ReportPage(listFood));
    }

    public void ApplyQueryAttributes(IDictionary<string, object> query) {
        SelectedFood = (FoodModel)query["selectedFood"];

        ChangeMeasure(false);
    }
}