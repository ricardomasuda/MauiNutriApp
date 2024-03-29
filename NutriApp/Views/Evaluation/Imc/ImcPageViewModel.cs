using CommunityToolkit.Maui.Core;
using NutriApp.Views.Evaluation.Imc.InfoPopup;

namespace NutriApp.Views.Evaluation.Imc;

public partial class ImcPageViewModel :  BaseViewModel
{
    [ObservableProperty]
    private bool _checkedElder;
    [ObservableProperty]
    private bool _checkedAdult;
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

    public ImcPageViewModel()
    {
        Imc = new ImcModel();
        CalculateCommand = new Command(Calculate);
        InfoCommand = new Command(() => App.NavPage.ShowPopup(new InfoImcPopup()));
    }

    private async void Calculate()
    {
        if (!await Validate())
        {
            CanDisplayResult = false;
            return;
        }

        Result = EvaluationCalculations.Imc(Utils.ParseToDoubleWithCommaSeparator(Imc.Altura), Convert.ToDouble(Imc.Peso)).ToString();
        if (!string.IsNullOrEmpty(Result))
        {
            var pessoa = CheckedAdult ? PersonAgeType.Adulto : PersonAgeType.Idoso;
            ImcType = ImcService.CheckImc(Convert.ToDouble((string)Result), pessoa);
            CanDisplayResult = true;
        }
    }

    private async Task<bool> Validate()
    {
        HasErrorHeight = string.IsNullOrWhiteSpace(Imc.Altura);
        HasErrorWeight = string.IsNullOrWhiteSpace(Imc.Peso);
        if (!(CheckedElder || CheckedAdult))
        {
            InfoToaster("Selecione um tipo de grupo", ToastDuration.Long);
            return false;
        }

        return !(HasErrorHeight && HasErrorWeight);
    }
    
}