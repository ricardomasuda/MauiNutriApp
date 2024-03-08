using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Core;
using CommunityToolkit.Mvvm.ComponentModel;
using NutriApp.Models;
using NutriApp.Services;
using NutriApp.Utils;

namespace NutriApp.Views.Evaluation.Imc;

public partial class ImcPageViewModel : ObservableObject
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
    
    [ObservableProperty]
    private bool _hasErrorWeight;
    [ObservableProperty]
    private bool _hasErrorHeight;
    [ObservableProperty]
    private bool _canDisplayResult;
    [ObservableProperty]
    private string _result;
    [ObservableProperty]
    private string _imcType;
    [ObservableProperty]
    private ImcModel _imc;

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

        Result = EvaluationCalculations.Imc(Convert.ToDouble((string)Imc.Altura), Convert.ToDouble((string)Imc.Peso)).ToString();
        if (!string.IsNullOrEmpty(Result))
        {
            var pessoa = CheckedAdult ? PersonAgeType.Adulto : PersonAgeType.Idoso;
            ImcType = ImcService.CheckImc(Convert.ToDouble((string)Result), pessoa);
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