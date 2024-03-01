using NutriApp.AppNutri.Componente;
using NutriApp.AppNutri.Model;
using NutriApp.AppNutri.service;
using NutriApp.AppNutri.View.FoodPlan.FoodDetail;

namespace NutriApp.AppNutri.View.FoodPlan.SelectFood.SelectFoodPopup;

public class SelectFoodPopupViewModel : BaseViewModel
{
    private FoodModel _food;

    public FoodModel Food
    {
        get => _food;
        set
        {
            _food = value;
            OnPropertyChanged("Food");
        }
    }

    private double _measure;

    public double Measure
    {
        get => _measure;
        set
        {
            _measure = value;
            ChangeMeasure();
            OnPropertyChanged("Measure");
        }
    }

    private bool _hasErrorFood;

    public bool HasErrorFood
    {
        get => _hasErrorFood;
        set
        {
            _hasErrorFood = value;
            OnPropertyChanged("HasErrorFood");
        }
    }

    private bool _hasErrorMeasure;

    public bool HasErrorMeasure
    {
        get => _hasErrorMeasure;
        set
        {
            _hasErrorMeasure = value;
            OnPropertyChanged("HasErrorMeasure");
        }
    }

    private string _title;

    public string Title
    {
        get => _title;
        set
        {
            _title = value;
            OnPropertyChanged("Title");
        }
    }

    private bool _canDelete;

    public bool CanDelete
    {
        get => _canDelete;
        set
        {
            _canDelete = value;
            OnPropertyChanged("CanDelete");
        }
    }

    public Command GoPopupFoodCommand { get; set; }
    public Command AddFoodCommand { get; set; }
    public Command RemoveFoodCommand { get; set; }
    public Command CloseCommand { get; set; }
    public Command ReportCommand { get; set; }

    private readonly FoodModel _foodAssistant;
    private readonly FoodDetailViewModel _foodDetailViewModel;
    private ChangeFoodView _changeFoodView;

    public SelectFoodPopupViewModel(FoodDetailViewModel foodDetailViewModel, FoodModel food = null)
    {
        Food = new FoodModel();
        _foodAssistant = food;
        CanDelete = false;
        _foodDetailViewModel = foodDetailViewModel;
        GoPopupFoodCommand = new Command(GoSelectFood);
        RemoveFoodCommand = new Command(RemoveFood);
        AddFoodCommand = new Command(AddFood);
        ReportCommand = new Command(GoReport);
        //CloseCommand = new Command(() => App.NavPage.Navigation.PopPopupAsync());
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

    private async void RemoveFood()
    {
        if (await App.NavPage.DisplayAlert("Retirar Alimento", "Deseja retirar o alimento da refeição?", "Sim", "Não"))
        {
            _foodDetailViewModel.RemoveFoodList(_foodAssistant);
            //await App.NavPage.Navigation.PopPopupAsync();
        }
    }

    private void UpdateFood()
    {
        _foodDetailViewModel.UpdateFoodList(Food, _foodAssistant);
    }

    private void GoReport()
    {
        if (!ValidateFood()) return;
        List<FoodModel> listFood = new List<FoodModel> { Food };
        //App.NavPage.Navigation.PushPopupAsync(new ReportPopup(listFood));
    }

    private async void GoSelectFood()
    {
        _changeFoodView = new ChangeFoodView(this);
        //await App.NavPage.Navigation.PushPopupAsync(_changeFoodView);
    }

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
            _foodDetailViewModel.SaveFoodList(Food);
        }

        //App.NavPage.Navigation.PopPopupAsync();
    }

    private async void ChangeMeasure()
    {
        if (Food.Id == 0) return;
        Food = await FoodService.ChangeUnitMeasure(Food.Id, Measure);
    }

    private bool ValidateFood()
    {
        HasErrorFood = Food == null;
        HasErrorMeasure = Measure == 0;

        return (!HasErrorFood && !HasErrorMeasure);
    }
}