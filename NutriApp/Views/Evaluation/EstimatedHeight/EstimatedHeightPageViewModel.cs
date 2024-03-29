using System.Globalization;
using CommunityToolkit.Maui.Core;

namespace NutriApp.Views.Evaluation.EstimatedHeight;

public partial class EstimatedHeightPageViewModel : BaseViewModel
{
    [ObservableProperty]
    private bool _checkedWoman;
    [ObservableProperty]
    private bool _checkedMan;
    [ObservableProperty]
    private string _kneeHeight;
    [ObservableProperty]
    private string _age;
    [ObservableProperty]
    private string _result;
    [ObservableProperty]
    private bool _canDisplayResult;
    [ObservableProperty]
    private bool _hasErrorAge;
    [ObservableProperty]
    private bool _hasErrorKneeHeight;

    [RelayCommand]
    private void HandleCheckedChange(object checkGener)
    {
        if ((Genders)checkGener == Genders.Male)
        {
            if(CheckedMan) CheckedWoman = false;
        }

        if ((Genders)checkGener == Genders.Female)
        {
            if(CheckedWoman) CheckedMan = false;
        }
    }
    [RelayCommand]
    private void TapCheckChange(object checkGener)
    {
        if ((Genders)checkGener == Genders.Male)
        {
            CheckedMan = true;
        }

        if ((Genders)checkGener == Genders.Female)
        {
            CheckedWoman = true;
        }
    }
    
    [RelayCommand]
    private void Calculate()
    {
        if (!Validate())
        {
            CanDisplayResult = false;
            return;
        }

        var estimateHeight = Convert.ToInt32(EvaluationCalculations.EstimatedHeight(Convert.ToDouble(KneeHeight),
            Convert.ToDouble(Age), CheckedMan ? Genders.Male : Genders.Female));
        Result = (Convert.ToDouble(estimateHeight) / 100).ToString(CultureInfo.InvariantCulture);
        if (!string.IsNullOrWhiteSpace(Result))
        {
            CanDisplayResult = true;
        }
    }

    private bool Validate()
    {
        HasErrorAge = string.IsNullOrWhiteSpace(Age);
        HasErrorKneeHeight = string.IsNullOrWhiteSpace(KneeHeight);
        if (!(CheckedWoman || CheckedMan))
        {
            InfoToaster( "Selecione um gênero", ToastDuration.Long);
            return false;
        }

        return (!HasErrorAge && !HasErrorKneeHeight);
    }
}