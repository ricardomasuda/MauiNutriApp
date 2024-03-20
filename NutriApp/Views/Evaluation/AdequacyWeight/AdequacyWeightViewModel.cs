using System.Globalization;
using CommunityToolkit.Maui.Views;
using NutriApp.AppNutri.View.Evaluation.AdequacyWeight.InfoPopup;
using NutriApp.Utils;

namespace NutriApp.Views.Evaluation.AdequacyWeight;

public class AdequacyWeightViewModel : BaseViewModel {
    private string _pesoAtual;

    public string PesoAtual {
        get => _pesoAtual;
        set {
            _pesoAtual = value;
            OnPropertyChanged();
        }
    }

    private string _pesoIdeal;

    public string PesoIdeal {
        get => _pesoIdeal;
        set {
            _pesoIdeal = value;
            OnPropertyChanged();
        }
    }

    private bool _hasErrorPesoAtual;

    public bool HasErrorPesoAtual {
        get => _hasErrorPesoAtual;
        set {
            _hasErrorPesoAtual = value;
            OnPropertyChanged();
        }
    }

    private bool _hasErrorPesoIdeal;

    public bool HasErrorPesoIdeal {
        get => _hasErrorPesoIdeal;
        set {
            _hasErrorPesoIdeal = value;
            OnPropertyChanged();
        }
    }

    private string _result;

    public string Result {
        get => _result;
        set {
            _result = value;
            OnPropertyChanged();
        }
    }

    private string _classificacaoPesoAdequado;

    public string ClassificacaoPesoAdequado {
        get => _classificacaoPesoAdequado;
        set {
            _classificacaoPesoAdequado = value;
            OnPropertyChanged();
        }
    }

    private bool _canDisplayResult;

    public bool CanDisplayResult {
        get => _canDisplayResult;
        set {
            _canDisplayResult = value;
            OnPropertyChanged();
        }
    }

    public Command CalculateCommand { get; set; }
    public Command InfoCommand { get; set; }

    public AdequacyWeightViewModel(AdequacyWeightPage page) {
        CalculateCommand = new Command(Calculate);
        InfoCommand = new Command(() => page.ShowPopup(new AdequacyWeightInfoPopupPage()));
    }

    private void Calculate() {
        if (!ValidateData()) {
            CanDisplayResult = false;
            return;
        }

        Result = Math
            .Round(EvaluationCalculations.AdequacyWeight(Convert.ToDouble(PesoIdeal), Convert.ToDouble(PesoAtual)), 2)
            .ToString(CultureInfo.CurrentCulture);
        if (!string.IsNullOrEmpty(Result)) {
            ClassificacaoPesoAdequado = WeightAdjustmentService.VerifyAdequacyWeight(Convert.ToDouble(Result));
            Result += "%";
            CanDisplayResult = true;
        }
    }

    private bool ValidateData() {
        HasErrorPesoIdeal = string.IsNullOrWhiteSpace(PesoIdeal);
        HasErrorPesoAtual = string.IsNullOrWhiteSpace(PesoAtual);

        return (!HasErrorPesoIdeal && !HasErrorPesoAtual);
    }
}