using CommunityToolkit.Maui.Views;

namespace NutriApp.Views.FoodPlan.FoodPlanList.NewFoodPlan;

public partial class FoodPlanPopupViewModel : BaseViewModel
{
    [ObservableProperty] private string _foodPlanName;
    [ObservableProperty] private bool _hasFoodPlanNameError;
    [ObservableProperty] private bool _hasWeightError;
    [ObservableProperty] private bool _hasEnergyError;
    [ObservableProperty] private bool _haveValueReference;
    [ObservableProperty] private double _energy;
    [ObservableProperty] private double _weight;
    [ObservableProperty] private int _lipidio;
    [ObservableProperty] private int _proteina;
    [ObservableProperty] private int _carboidratos;
    [ObservableProperty] private FoodPlanPopup _foodPlanPopup;
    public bool CanDelete { get; set; }
    private readonly FoodPlanListViewModel _foodPlanListViewModel;
    private readonly FoodPlanModel _foodPlan;

    public FoodPlanPopupViewModel(FoodPlanListViewModel foodPlanListViewModel, FoodPlanModel foodPlan = null)
    {
        _foodPlan = foodPlan;
        _foodPlanListViewModel = foodPlanListViewModel;
        Fetch();
    }

    private void Fetch()
    {
        CanDelete = false;
        if (_foodPlan is null)
        {
            Proteina = 34;
            Carboidratos = 33;
            Lipidio = 33;
            return;
        }

        FoodPlanName = _foodPlan.Nome;
        CanDelete = true;
        FillValueReference(_foodPlan.Id);
    }
    
    [RelayCommand]
    private async Task DeleteFoodPlan(object obj)
    {
        if (await Shell.Current.DisplayAlert("Apagar plano", "Deseja apagar esse plano?", "Sim", "Não"))
        {
            await new FoodPlanDB().ExcluirTotalAsync(_foodPlan.Id);
            _foodPlanListViewModel.ListFoodPlan.Clear();
            _foodPlanListViewModel.Fetch();
            await App.NavPage.GoBackModal();
        }
    }
    
    [RelayCommand]
    private async Task AddFoodPlan()
    {
        if (!Validate()) return;

        FoodPlanModel foodPlan = new FoodPlanModel
        {
            Nome = FoodPlanName,
            Data = DateTime.Now
        };

        if (_foodPlan is not null)
        {
            foodPlan.Id = _foodPlan.Id;
            await new FoodPlanDB().AtualizarAsync(foodPlan);
        }
        else
        {
            foodPlan.Id = await new FoodPlanDB().CadastrarAsync(foodPlan);
        }

        if (HaveValueReference) SaveReferenceValue(foodPlan.Id);
        else await new ValueReferenceDB().ExcluirWhereAsync(foodPlan.Id);

        _foodPlanListViewModel.Fetch();
        await App.NavPage.GoBackModal();
    }
    
    [RelayCommand]
    private async void Close()
    {
       await App.NavPage.GoBackModal();
    }

    private async void SaveReferenceValue(int foodPlanId)
    {
        var valueReferenceModel = new ValueReferenceModel();
        valueReferenceModel.FoodPlanId = foodPlanId;
        valueReferenceModel.Peso = Weight;
        valueReferenceModel.Energia = Energy;
        valueReferenceModel.Proteinas = Proteina;
        valueReferenceModel.Carboidratos = Carboidratos;
        valueReferenceModel.Lipidios = Lipidio;
        await new ValueReferenceDB().CadastrarAsync(valueReferenceModel);
    }

    private async void FillValueReference(int foodPlanId)
    {
        var valueReferenceModel = await new ValueReferenceDB().ConsultarWhereAsync(foodPlanId);
        if (valueReferenceModel != null)
        {
            HaveValueReference = true;
            Weight = valueReferenceModel.Peso;
            Energy = valueReferenceModel.Energia;
            Proteina = valueReferenceModel.Proteinas;
            Lipidio = valueReferenceModel.Lipidios;
            Carboidratos = valueReferenceModel.Carboidratos;
        }
        else
        {
            Proteina = 34;
            Carboidratos = 33;
            Lipidio = 33;
        }
    }

    private bool Validate()
    {
        HasFoodPlanNameError = string.IsNullOrWhiteSpace(FoodPlanName);
        if (HaveValueReference)
        {
            HasWeightError = Weight == 0;
            HasEnergyError = Energy == 0;
            return (!HasFoodPlanNameError && !HasWeightError && !HasEnergyError);
        }

        return !HasFoodPlanNameError;
    }
}