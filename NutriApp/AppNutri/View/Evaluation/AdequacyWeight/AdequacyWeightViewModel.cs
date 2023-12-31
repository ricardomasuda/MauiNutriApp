using System.Globalization;
using NutriApp.AppNutri.Componente;
using NutriApp.AppNutri.service;
using NutriApp.AppNutri.Utils;

namespace NutriApp.AppNutri.View.Evaluation.AdequacyWeight;

public class AdequacyWeightViewModel : BaseViewModel
{
    private string _pesoAtual;

    public string PesoAtual
    {
        get => _pesoAtual;
        set
        {
            _pesoAtual = value;
            OnPropertyChanged("PesoAtual");
        }
    }

    private string _pesoIdeal;

    public string PesoIdeal
    {
        get => _pesoIdeal;
        set
        {
            _pesoIdeal = value;
            OnPropertyChanged("PesoIdeal");
        }
    }

    private bool _hasErrorPesoAtual;

    public bool HasErrorPesoAtual
    {
        get => _hasErrorPesoAtual;
        set
        {
            _hasErrorPesoAtual = value;
            OnPropertyChanged("HasErrorPesoAtual");
        }
    }

    private bool _hasErrorPesoIdeal;

    public bool HasErrorPesoIdeal
    {
        get => _hasErrorPesoIdeal;
        set
        {
            _hasErrorPesoIdeal = value;
            OnPropertyChanged("HasErrorPesoIdeal");
        }
    }

    private string _result;

    public string Result
    {
        get => _result;
        set
        {
            _result = value;
            OnPropertyChanged("Result");
        }
    }

    private string _classificacaoPesoAdequado;

    public string ClassificacaoPesoAdequado
    {
        get => _classificacaoPesoAdequado;
        set
        {
            _classificacaoPesoAdequado = value;
            OnPropertyChanged("ClassificacaoPesoAdequado");
        }
    }

    private bool _canDisplayResult;

    public bool CanDisplayResult
    {
        get => _canDisplayResult;
        set
        {
            _canDisplayResult = value;
            OnPropertyChanged("CanDisplayResult");
        }
    }

    public Command CalculateCommand { get; set; }
    public Command InfoCommand { get; set; }

    public AdequacyWeightViewModel()
    {
        CalculateCommand = new Command(Calculate);
        //InfoCommand = new Command(async () => await Navigation.PushPopupAsync(new AdequacyWeightInfoPopupPage()));
    }

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