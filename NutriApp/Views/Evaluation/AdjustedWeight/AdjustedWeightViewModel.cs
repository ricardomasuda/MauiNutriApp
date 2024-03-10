using NutriApp.Components;
using NutriApp.Models;
using NutriApp.Utils;

namespace NutriApp.Views.Evaluation.AdjustedWeight;

public class AdjustedWeightPageViewModel : BaseViewModel
{
    private ViewModelProperties _properties;
    public ViewModelProperties Properties { get => _properties; set { _properties = value; OnPropertyChanged("Properties"); } }
        
    public Command CalculateCommand { get; set; }
    public Command MalnutritionCommand { get; set; }
    public Command ObesityCommand { get; set; }
        
    public AdjustedWeightPageViewModel()
    {
        Properties = new ViewModelProperties();
        CalculateCommand = new Command(Calculate);
        MalnutritionCommand = new Command(() => Properties.CheckedMalnutrition = !Properties.CheckedMalnutrition);
        ObesityCommand = new Command(() => Properties.CheckedObesity = !Properties.CheckedObesity);
    }

    private void Calculate()
    {
        if (!Validate())
        {
            Properties.CanDisplayResult = false;
            return;
        }
        Properties.Result = EvaluationCalculations.AdjustedWeight(Convert.ToDouble(Properties.IdealWeight), Convert.ToDouble(Properties.CurrentWeight), Properties.CheckedObesity ? WeightTypes.OBESITY : WeightTypes.MALNUTRITION).ToString();
        if (!string.IsNullOrEmpty(Properties.Result))
        {
            Properties.CanDisplayResult = true;
        }
    }

    private bool Validate()
    {
        Properties.HasErrorIdealWeight = string.IsNullOrWhiteSpace(Properties.IdealWeight);
        Properties.HasErrorCurrencyWeight = string.IsNullOrWhiteSpace(Properties.CurrentWeight);
        if (!(Properties.CheckedObesity || Properties.CheckedMalnutrition))
        {
            //App.NavPage.DisplayToastAsync("Selecione uma opção na categoria");
            return false;
        }
        return (!Properties.HasErrorIdealWeight && !Properties.HasErrorCurrencyWeight);
    }
}