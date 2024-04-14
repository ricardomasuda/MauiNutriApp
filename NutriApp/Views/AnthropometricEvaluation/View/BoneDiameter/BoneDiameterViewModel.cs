namespace NutriApp.Views.AnthropometricEvaluation.View.BoneDiameter;

public partial class BoneDiameterViewModel : BaseViewModel
{
    [ObservableProperty]
    private string _height;
    [ObservableProperty]
    private string _wrist;
    [ObservableProperty]
    private string _femur;
    [ObservableProperty]
    private bool _hasErrorHeight;
    [ObservableProperty]
    private bool _hasErrorWrist;
    [ObservableProperty]
    private bool _hasErrorFemur;

    public bool ValidateViewData()
    {
        HasErrorWrist = string.IsNullOrWhiteSpace(Wrist);
        HasErrorFemur = string.IsNullOrWhiteSpace(Femur);
        HasErrorHeight = string.IsNullOrWhiteSpace(Height);
        return (!HasErrorWrist && !HasErrorFemur && !HasErrorHeight);
    }
}