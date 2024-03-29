using System.Windows.Input;
using CommunityToolkit.Maui.Core;
using NutriApp.AppUtilities;

namespace NutriApp.Views.Evaluation.AdjustedWeight;

public partial class AdjustedWeightPageViewModel : BaseViewModel
{
    [ObservableProperty]
    private string _currentWeight;
    [ObservableProperty]
    private string _idealWeight;
    [ObservableProperty]
    private bool _hasErrorCurrencyWeight;
    [ObservableProperty]
    private bool _hasErrorIdealWeight;
    [ObservableProperty]
    private bool _canDisplayResult;
    [ObservableProperty]
    private string _result; 
    [ObservableProperty]
    private bool _checkedObesity;
    [ObservableProperty]
    private bool _checkedMalnutrition;

    [RelayCommand]
    private void Calculate()
    {
        if (!Validate())
        {
            CanDisplayResult = false;
            return;
        }
        Result = EvaluationCalculations.AdjustedWeight(Convert.ToDouble(IdealWeight), Convert.ToDouble(CurrentWeight), CheckedObesity ? WeightTypes.OBESITY : WeightTypes.MALNUTRITION).ToString();
        if (!string.IsNullOrEmpty(Result))
        {
            CanDisplayResult = true;
        }
    }

    private bool Validate()
    {
        HasErrorIdealWeight = string.IsNullOrWhiteSpace(IdealWeight);
        HasErrorCurrencyWeight = string.IsNullOrWhiteSpace(CurrentWeight);
        if (!(CheckedObesity || CheckedMalnutrition))
        {
            InfoToaster("Selecione uma opção na categoria", ToastDuration.Long);
            return false;
        }
        return (!HasErrorIdealWeight && !HasErrorCurrencyWeight);
    }
}