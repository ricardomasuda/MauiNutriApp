using NutriApp.Components;

namespace NutriApp.Views.Evaluation.AdjustedWeight;

public class ViewModelProperties : BaseViewModel
{
    private string _currentWeight;
    public string CurrentWeight { 
        get => _currentWeight;
        set { _currentWeight = value; OnPropertyChanged("CurrentWeight"); } }
        
    private string _idealWeight;
    public string IdealWeight { 
        get => _idealWeight;
        set { _idealWeight = value; OnPropertyChanged("IdealWeight"); } }
        
    private bool _hasErrorCurrencyWeight;
    public bool HasErrorCurrencyWeight { 
        get => _hasErrorCurrencyWeight;
        set { _hasErrorCurrencyWeight = value; OnPropertyChanged("HasErrorCurrencyWeight"); } 
    }
        
    private bool _hasErrorIdealWeight;
    public bool HasErrorIdealWeight { 
        get => _hasErrorIdealWeight;
        set { _hasErrorIdealWeight = value; OnPropertyChanged("HasErrorIdealWeight"); } }

    private bool _canDisplayResult;
    public bool CanDisplayResult { 
        get => _canDisplayResult;
        set { _canDisplayResult = value; OnPropertyChanged("CanDisplayResult"); } }
        
    private string _result;
    public string Result { get => _result;
        set { _result = value; OnPropertyChanged("Result"); } }        
        
    private bool _checkedObesity;
    public bool CheckedObesity
    {
        get => _checkedObesity;
        set
        {
            _checkedObesity = value; OnPropertyChanged("CheckedObesity");
            if (CheckedObesity) CheckedMalnutrition = false;
        }
    }

    private bool _checkedMalnutrition;
    public bool CheckedMalnutrition
    {
        get => _checkedMalnutrition;
        set
        {
            _checkedMalnutrition = value; OnPropertyChanged("CheckedMalnutrition");
            if (CheckedMalnutrition) CheckedObesity = false;
        }
    }
}
