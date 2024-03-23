using NutriApp.AppUtilities;
using NutriApp.Services.AnthropometricEvaluation;

namespace NutriApp.Views.Evaluation.BodyComposition;

public partial class BodyCompositionPageViewModel : BaseViewModel
{
    [ObservableProperty]
    private string _height;
    [ObservableProperty]
    private string _wrist;
    [ObservableProperty]
    private string _femur;
    [ObservableProperty]
    private string _weight;
    [ObservableProperty]
    private bool _hasErrorHeight;
    [ObservableProperty]
    private bool _hasErrorWrist;
    [ObservableProperty]
    private bool _hasErrorFemur;
    [ObservableProperty]
    private bool _hasErrorWeight;
    [ObservableProperty]
    private bool _hasErrorGender;
    [ObservableProperty]
    private double _boneMassResult;
    [ObservableProperty]
    private double _residualWeightResult;
    [ObservableProperty]
    private Item _genderType;
    [ObservableProperty]
    private bool _canDisplayResult;
    public ObservableCollection<Item> ListGender { get; set; }

    public BodyCompositionPageViewModel()
    {
        ListGender = new ObservableCollection<Item>
        {
            new() { Id = 0, Nome = "Homem" },
            new() { Id = 1, Nome = "Mulher" }
        };
    }
    
    [RelayCommand]
    private void Calculate()
    {
        if (ValidateData())
        {
            BoneMassResult = BodyCompositionService.CalculateBoneMass( Utils.ParseToDoubleWithCommaSeparator(Height), Convert.ToDouble(Wrist),
                Convert.ToDouble(Femur));
            ResidualWeightResult = BodyCompositionService.CalculateResidualWeight(Convert.ToDouble(Weight),
                GenderUtils.ConverterGender(GenderType.Nome));
            CanDisplayResult = true;
        }
    }

    private bool ValidateData()
    {
        HasErrorHeight = string.IsNullOrWhiteSpace(Height);
        HasErrorWrist = string.IsNullOrWhiteSpace(Wrist);
        HasErrorFemur = string.IsNullOrWhiteSpace(Femur);
        HasErrorWeight = string.IsNullOrWhiteSpace(Weight);
        HasErrorGender = string.IsNullOrWhiteSpace(GenderType?.Nome);
        return (!HasErrorHeight && !HasErrorHeight && !HasErrorFemur && !HasErrorWeight && !HasErrorGender);
    }
}