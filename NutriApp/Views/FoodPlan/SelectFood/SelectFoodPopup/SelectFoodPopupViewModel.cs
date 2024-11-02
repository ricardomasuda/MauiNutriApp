using NutriApp.Views.FoodPlan.FoodDetail;
using NutriApp.Views.ReportPage.Popup;

namespace NutriApp.Views.FoodPlan.SelectFood.SelectFoodPopup;

public partial class SelectFoodPopupViewModel : BaseViewModel
{
    [ObservableProperty] private FoodModel _food;
    [ObservableProperty] private double _measure;
    [ObservableProperty] private bool _hasErrorFood;
    [ObservableProperty] private bool _hasErrorMeasure;
    [ObservableProperty] private string _title;
    [ObservableProperty] private bool _canDelete;

    private readonly FoodModel _foodAssistant;
    private readonly MealFoodDetailViewModel _mealFoodDetailViewModel;
    private SelectFoodPopup _selectFoodPopup;
    private ChangeFoodPopup _changeFoodPopup;

    public SelectFoodPopupViewModel(MealFoodDetailViewModel mealFoodDetailViewModel, SelectFoodPopup selectFoodPopup, FoodModel food = null)
    {
        Food = new FoodModel();
        _selectFoodPopup = selectFoodPopup;
        _foodAssistant = food;
        CanDelete = false;
        _mealFoodDetailViewModel = mealFoodDetailViewModel;
        Fetch();
    }

    private async void Fetch()
    {
        Title = "Adicione um alimento";
        if (_foodAssistant != null)
        {
            Title = "Atualize um alimento";
            FoodService.RemoveUnitMeasurement(_foodAssistant);
            Food = await FoodService.ChangeUnitMeasure(_foodAssistant.Id, Convert.ToDouble(_foodAssistant.Medida));
            FoodService.AddUnitMeasureToValues(Food);
            Measure = Convert.ToDouble(_foodAssistant.Medida);
            CanDelete = true;
        }
    }

    [RelayCommand]
    private async Task RemoveFood()
    {
        if (await Shell.Current.DisplayAlert("Retirar Alimento", "Deseja retirar o alimento da refeição?", "Sim", "Não"))
        {
            await _mealFoodDetailViewModel.RemoveFood(_foodAssistant);
            await App.NavPage.GoBackModal();
        }
    }

    [RelayCommand]
    private void Report()
    {
        if (!ValidateFood()) return;
        List<FoodModel> listFood = new List<FoodModel> { Food };
        App.NavPage.GoToModalAsync(new ReportPopup(listFood));
    }

    [RelayCommand]
    private async Task GoPopupFood()
    {
        _changeFoodPopup = new ChangeFoodPopup(this);
        await App.NavPage.GoToModalAsync( new ChangeFoodPopup(this));
    }

    [RelayCommand]
    private void AddFood()
    {
        if (!ValidateFood()) return;

        ChangeMeasure();

        if (_foodAssistant != null)
        {
            UpdateFood();
        }
        else
        {
            _mealFoodDetailViewModel.SaveFoodList(Food);
        }

        App.NavPage.GoBackModal();
        App.NavPage.GoBackModal();
    }
    
    [RelayCommand]
    private void Close()
    {
        App.NavPage.GoBackModal();
    }
    
    [RelayCommand]
    private async Task ChangeMeasure()
    {
        if (Food.Id == 0) return;
        Food = await FoodService.ChangeUnitMeasure(Food.Id, Measure);
    }
    
    private void UpdateFood()
    {
        _mealFoodDetailViewModel.UpdateFoodList(Food, _foodAssistant);
    }

    private bool ValidateFood()
    {
        HasErrorFood = Food == null;
        HasErrorMeasure = Measure == 0;

        return (!HasErrorFood && !HasErrorMeasure);
    }
}