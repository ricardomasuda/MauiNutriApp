using System.Windows.Input;
using CommunityToolkit.Maui.Core;

namespace NutriApp.Views.Evaluation.EstimatedWeight.FormulaRabito;

public  partial class FormulaRabitoViewModel : BaseViewModel
{
    private bool _checkedWoman;
    public bool CheckedWoman
    {
        get => _checkedWoman;
        set
        {
            _checkedWoman = value;
            OnPropertyChanged(nameof(CheckedWoman));
            if (CheckedWoman) CheckedMan = false;
        }
    }

    private bool _checkedMan;
    public bool CheckedMan
    {
        get => _checkedMan;
        set
        {
            _checkedMan = value;
            OnPropertyChanged(nameof(CheckedMan));
            if (CheckedMan) CheckedWoman = false;
        }
    }

    [ObservableProperty]
    private string _armCircumference;
    [ObservableProperty]
    private string _waistCircumference;
    [ObservableProperty]
    private string _calfCircumference;
    [ObservableProperty]
    private bool _hasErrorArmCircumference;
    [ObservableProperty]
    private bool _hasErrorWaistCircumference;
    [ObservableProperty]
    private bool _hasErrorCalfCircumference;
    
    public ICommand CheckWomanCommand => new RelayCommand(() => CheckedWoman = !CheckedWoman);
    public ICommand CheckManCommand => new RelayCommand(() => CheckedMan = !CheckedMan);

    public FormulaRabitoViewModel()
    {
        
    }

    public bool ValidateData()
    {
        HasErrorArmCircumference = string.IsNullOrWhiteSpace(ArmCircumference);
        HasErrorWaistCircumference = string.IsNullOrWhiteSpace(WaistCircumference);
        HasErrorCalfCircumference = string.IsNullOrWhiteSpace(CalfCircumference);

        if (!(CheckedWoman || CheckedMan))
        {
            InfoToaster("Selecione um gênero", ToastDuration.Long);
            return false;
        }

        return (!HasErrorArmCircumference && !HasErrorWaistCircumference && !HasErrorCalfCircumference);
    }
}