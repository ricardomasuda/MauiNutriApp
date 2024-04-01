using CommunityToolkit.Maui.Core;

namespace NutriApp.Views.Evaluation.EstimatedWeight.FormulaRabito;

public  partial class FormulaRabitoViewModel : BaseViewModel
{
    [ObservableProperty]
    private bool _checkedWoman;
    [ObservableProperty]
    private bool _checkedMan;
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