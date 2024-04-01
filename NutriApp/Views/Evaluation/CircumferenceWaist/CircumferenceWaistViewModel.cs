using System.Globalization;
using System.Windows.Input;
using CommunityToolkit.Maui.Core;

namespace NutriApp.Views.Evaluation.CircumferenceWaist;

public partial class CircumferenceWaistViewModel : BaseViewModel
{
    [ObservableProperty]
    private bool _checkedWoman;
    [ObservableProperty]
    private bool _checkedMan;
    [ObservableProperty] 
    private bool _hasErrorCircumferenceAbdominal;
    [ObservableProperty] 
    private bool _hasErrorCircumferenceHip;
    [ObservableProperty] 
    private bool _hasErrorAge;
    [ObservableProperty] 
    private string _circumferenceHip;
    [ObservableProperty] 
    private string _circumferenceAbdominal;
    [ObservableProperty] 
    private string _age;
    [ObservableProperty] 
    private string _result;
    [ObservableProperty] 
    private bool _displayResult;
    [ObservableProperty] 
    private string _classification;

    public ICommand InfoImcCommand { get; set; }
    public ICommand WomanCommand { get; set; }
    public ICommand ManCommand { get; set; }

    public CircumferenceWaistViewModel()
    {
        InfoImcCommand = new RelayCommand(() => App.NavPage.ShowPopup(new InfoPopup.InfoCircumferenceWaistPopup()));
        WomanCommand = new RelayCommand(() => CheckedWoman = !CheckedWoman);
        ManCommand = new RelayCommand(() => CheckedMan = !CheckedMan);
    }
    
    [RelayCommand]
    private void Calculate()
    {
        if (!Validate())
        {
            DisplayResult = false;
            return;
        }

        Result = Math.Round(
            EvaluationCalculations.CircumferenceWaist(Convert.ToDouble(CircumferenceAbdominal),
                Convert.ToDouble(CircumferenceHip)), 2).ToString(CultureInfo.InvariantCulture);
        if (!string.IsNullOrEmpty(Result))
        {
            DisplayResult = true;
            Classification = WaistCircumferenceService.GetWaistCircumferenceRatio(
                CommonCalculations.ConverterDouble(Result), Convert.ToInt32(Age),
                CheckedMan ? Genders.Male : Genders.Female);
        }
    }

    private bool Validate()
    {
        HasErrorCircumferenceAbdominal = string.IsNullOrWhiteSpace(CircumferenceAbdominal);
        HasErrorCircumferenceHip = string.IsNullOrWhiteSpace(CircumferenceHip);
        HasErrorAge = string.IsNullOrWhiteSpace(Age);

        if (!(CheckedWoman || CheckedMan))
        {
            InfoToaster("Selecione um gênero", ToastDuration.Long);
            return false;
        }

        return !HasErrorCircumferenceAbdominal && !HasErrorCircumferenceHip;
    }
}