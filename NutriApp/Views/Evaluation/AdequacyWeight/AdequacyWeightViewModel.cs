using System.Globalization;
using System.Windows.Input;
using CommunityToolkit.Maui.Views;
using NutriApp.Utils;
using NutriApp.Views.Evaluation.AdequacyWeight.InfoPopup;

namespace NutriApp.Views.Evaluation.AdequacyWeight;

public partial class AdequacyWeightViewModel : BaseViewModel
{
    [ObservableProperty] private string _pesoAtual;
    [ObservableProperty] private string _pesoIdeal;
    [ObservableProperty] private bool _hasErrorPesoAtual;
    [ObservableProperty] private bool _hasErrorPesoIdeal;
    [ObservableProperty] private string _result;
    [ObservableProperty] private string _classificacaoPesoAdequado;
    [ObservableProperty] private bool _canDisplayResult;
    
    public ICommand InfoCommand => new RelayCommand(() => Shell.Current.CurrentPage.ShowPopup(new AdequacyWeightInfoPopupPage()));

    public AdequacyWeightViewModel()
    {
    }
    
    [RelayCommand]
    private void Calculate()
    {
        if (!ValidateData())
        {
            CanDisplayResult = false;
            return;
        }

        Result = Math
            .Round(EvaluationCalculations.AdequacyWeight(Convert.ToDouble(PesoIdeal), Convert.ToDouble(PesoAtual)), 2)
            .ToString(CultureInfo.CurrentCulture);
        if (!string.IsNullOrEmpty(Result))
        {
            ClassificacaoPesoAdequado = WeightAdjustmentService.VerifyAdequacyWeight(Convert.ToDouble(Result));
            Result += "%";
            CanDisplayResult = true;
        }
    }

    private bool ValidateData()
    {
        HasErrorPesoIdeal = string.IsNullOrWhiteSpace(PesoIdeal);
        HasErrorPesoAtual = string.IsNullOrWhiteSpace(PesoAtual);

        return (!HasErrorPesoIdeal && !HasErrorPesoAtual);
    }
}