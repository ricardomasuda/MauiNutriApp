namespace NutriApp.Views.Evaluation.ReferenceValue;

public partial class ReferenceValuePageViewModel : BaseViewModel
{
    [ObservableProperty] private bool _hasErrorEnergy;
    [ObservableProperty] private bool _displayResult;
    [ObservableProperty] private double _energy;
    [ObservableProperty] private int _lipidPercent;
    [ObservableProperty] private int _proteinPercent;
    [ObservableProperty] private int _carbohydratePercent;
    [ObservableProperty] private double _lipid;
    [ObservableProperty] private double _protein;
    [ObservableProperty] private double _carbohydrate;

    public Command CalculateCommand { get; set; }

    public ReferenceValuePageViewModel()
    {
        CalculateCommand = new Command(Calculate);
        Fetch();
    }

    private void Fetch()
    {
        ProteinPercent = 33;
        LipidPercent = 34;
        CarbohydratePercent = 33;
    }

    private void Calculate()
    {
        if (!Validate()) return;

        DisplayResult = true;
        Protein = FoodPlanCalculations.CalculateReferenceValue(Energy.ToString(), ProteinPercent, MacroNutrients.PROTEIN);
        Lipid = FoodPlanCalculations.CalculateReferenceValue(Energy.ToString(), LipidPercent, MacroNutrients.LIPIDS);
        Carbohydrate = FoodPlanCalculations.CalculateReferenceValue(Energy.ToString(), CarbohydratePercent, MacroNutrients.CARBOHYDRATES);
    }

    private bool Validate()
    {
        HasErrorEnergy = Energy == 0;

        return !HasErrorEnergy;
    }
}