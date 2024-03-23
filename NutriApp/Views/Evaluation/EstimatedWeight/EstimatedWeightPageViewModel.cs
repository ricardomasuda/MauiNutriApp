using System.Globalization;
using NutriApp.Utils;
using NutriApp.Views.Evaluation.EstimatedWeight.FormulaChumlea;
using NutriApp.Views.Evaluation.EstimatedWeight.FormulaRabito;

namespace NutriApp.Views.Evaluation.EstimatedWeight;

public partial class EstimatedWeightPageViewModel : BaseViewModel
{
    [ObservableProperty] private bool _hasErrorFormula;
    [ObservableProperty] private string _result;
    [ObservableProperty] private bool _displayResult;
    [ObservableProperty] private bool _displayRabitoFormula;
    [ObservableProperty] private FormulaChumleaViewModel _formulaChumleaViewModel;
    [ObservableProperty] private FormulaRabitoViewModel _formulaRabitoViewModel;
    public ObservableCollection<Item> ListFormula { get; set; }
    
    private Item _formulaType;
    public Item FormulaType
    {
        get => _formulaType;
        set
        {
            _formulaType = value;
            SetFormula();
            OnPropertyChanged("Formula");
        }
    }
    
    public EstimatedWeightPageViewModel()
    {
        Fill();
    }

    private void Fill()
    {
        FormulaRabitoViewModel = new FormulaRabitoViewModel();
        FormulaChumleaViewModel = new FormulaChumleaViewModel();
        ListFormula = new ObservableCollection<Item>
        {
            new() { Id = 0, Nome = "RABITO et al., 2006" },
            new() { Id = 1, Nome = "CHUMLEA et al., 1988" }
        };
        FormulaType = ListFormula[0];
    }

    public void SetFormula()
    {
        if (FormulaType.Nome == "RABITO et al., 2006")
        {
            DisplayRabitoFormula = true;
        }

        if (FormulaType.Nome == "CHUMLEA et al., 1988")
        {
            DisplayRabitoFormula = false;
        }

        DisplayResult = false;
    }

    [RelayCommand]
    private void Calculate()
    {
        if (FormulaType.Nome == "RABITO et al., 2006")
        {
            if (!FormulaRabitoViewModel.ValidateData())
            {
                DisplayResult = false;
                return;
            }

            Result = Math.Round(EvaluationCalculations.EstimateWeight(
                    Convert.ToDouble(FormulaRabitoViewModel.ArmCircumference),
                    Convert.ToDouble(FormulaRabitoViewModel.WaistCircumference),
                    Convert.ToDouble(FormulaRabitoViewModel.CalfCircumference),
                    FormulaRabitoViewModel.CheckedMan ? Genders.Male : Genders.Female), 2)
                .ToString(CultureInfo.InvariantCulture);
        }
        else if (FormulaType.Nome == "CHUMLEA et al., 1988")
        {
            if (!FormulaChumleaViewModel.ValidateData())
            {
                DisplayResult = false;
                return;
            }

            Result = Math.Round(EvaluationCalculations.EstimateWeight(
                    Convert.ToDouble(FormulaChumleaViewModel.CircunferenciaPerna),
                    Convert.ToDouble(FormulaChumleaViewModel.AlturaJoelho),
                    Convert.ToDouble(FormulaChumleaViewModel.BrachialMuscleCircumference),
                    Convert.ToDouble(FormulaChumleaViewModel.SubscapularSkinfold),
                    FormulaChumleaViewModel.CheckedMan ? Genders.Male : Genders.Female), 2)
                .ToString(CultureInfo.InvariantCulture);
        }

        DisplayResult = !string.IsNullOrEmpty(Result);
    }
}