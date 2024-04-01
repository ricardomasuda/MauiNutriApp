using CommunityToolkit.Maui.Core;

namespace NutriApp.Views.Evaluation.EstimatedWeight.FormulaChumlea;

public partial class FormulaChumleaViewModel : BaseViewModel
{
    [ObservableProperty] 
    private bool _checkedWoman;
    [ObservableProperty] 
    private bool _checkedMan;
    [ObservableProperty] 
    private string _circunferenciaPerna;
    [ObservableProperty] 
    private string _alturaJoelho;
    [ObservableProperty] 
    private string _brachialMuscleCircumference;
    [ObservableProperty] 
    private string _subscapularSkinfold;
    [ObservableProperty] 
    private bool _hasErrorCircunferenciaPerna;
    [ObservableProperty] 
    private bool _hasErrorAlturaJoelho;
    [ObservableProperty] 
    private bool _hasErrorBrachialMuscleCircumference;
    [ObservableProperty] 
    private bool _hasErrorSubscapularSkinfold;

    public bool ValidateData()
    {
        HasErrorCircunferenciaPerna = string.IsNullOrWhiteSpace(CircunferenciaPerna);
        HasErrorAlturaJoelho = string.IsNullOrWhiteSpace(AlturaJoelho);
        HasErrorBrachialMuscleCircumference = string.IsNullOrWhiteSpace(BrachialMuscleCircumference);
        HasErrorSubscapularSkinfold = string.IsNullOrWhiteSpace(SubscapularSkinfold);

        if (!(CheckedWoman || CheckedMan))
        {
            InfoToaster("Selecione um gênero", ToastDuration.Long);
            return false;
        }

        return (!HasErrorCircunferenciaPerna && !HasErrorAlturaJoelho && !HasErrorBrachialMuscleCircumference &&
                !HasErrorSubscapularSkinfold);
    }
}