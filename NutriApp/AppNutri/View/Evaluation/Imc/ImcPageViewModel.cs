using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Core;
using NutriApp.AppNutri.Model;
using NutriApp.AppNutri.service;
using NutriApp.AppNutri.Utils;
using NutriApp.Componente;

namespace NutriApp.AppNutri.View.Evaluation.Imc;

public class ImcPageViewModel : BaseViewModel
{
    private bool _checkedElder;

    public bool CheckedElder
    {
        get => _checkedElder;
        set
        {
            _checkedElder = value;
            OnPropertyChanged("CheckedElder");
            if (CheckedElder) CheckedAdult = false;
        }
    }

    private bool _checkedAdult;

    public bool CheckedAdult
    {
        get => _checkedAdult;
        set
        {
            _checkedAdult = value;
            OnPropertyChanged("CheckedAdult");
            if (CheckedAdult) CheckedElder = false;
        }
    }

    private bool _hasErrorWeight;

    public bool HasErrorWeight
    {
        get => _hasErrorWeight;
        set
        {
            _hasErrorWeight = value;
            OnPropertyChanged("HasErrorWeight");
        }
    }

    private bool _hasErrorHeight;

    public bool HasErrorHeight
    {
        get => _hasErrorHeight;
        set
        {
            _hasErrorHeight = value;
            OnPropertyChanged("HasErrorHeight");
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

    private string _imcType;

    public string ImcType
    {
        get => _imcType;
        set
        {
            _imcType = value;
            OnPropertyChanged("ImcType");
        }
    }

    private ImcModel _imc;

    public ImcModel Imc
    {
        get => _imc;
        set
        {
            _imc = value;
            OnPropertyChanged("Imc");
        }
    }

    public Command CalculateCommand { get; set; }
    public Command InfoCommand { get; set; }
    public Command CheckedAdultCommand { get; set; }
    public Command CheckedElderCommand { get; set; }

    public ImcPageViewModel()
    {
        Imc = new ImcModel();
        CalculateCommand = new Command(Calculate);
        //InfoCommand = new Command(async () => await Navigation.PushPopupAsync(new InfoImcPopup())) ;
        CheckedAdultCommand = new Command(() => CheckedAdult = !CheckedAdult);
        CheckedElderCommand = new Command(() => CheckedElder = !CheckedElder);
    }

    private async void Calculate()
    {
        if (!await Validate())
        {
            CanDisplayResult = false;
            return;
        }

        Result = EvaluationCalculations.Imc(Convert.ToDouble(Imc.Altura), Convert.ToDouble(Imc.Peso)).ToString();
        if (!string.IsNullOrEmpty(Result))
        {
            var pessoa = CheckedAdult ? PersonAgeType.Adulto : PersonAgeType.Idoso;
            ImcType = ImcService.CheckImc(Convert.ToDouble(Result), pessoa);
            CanDisplayResult = true;
        }
    }

    private async Task<bool> Validate()
    {
        HasErrorHeight = string.IsNullOrWhiteSpace(_imc.Altura);
        HasErrorWeight = string.IsNullOrWhiteSpace(_imc.Peso);
        if (!(CheckedElder || CheckedAdult))
        {
            //App.NavPage.DisplayActionSheet("Selecione um tipo de grupo");
            CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();

            string text = "Selecione um tipo de grupo";
            ToastDuration duration = ToastDuration.Short;
            double fontSize = 14;

            var toast = Toast.Make(text, duration, fontSize);

            await toast.Show(cancellationTokenSource.Token);
            return false;
        }

        return !(HasErrorHeight && HasErrorWeight);
    }
}