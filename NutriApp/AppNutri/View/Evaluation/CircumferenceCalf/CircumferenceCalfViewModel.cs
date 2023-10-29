using NutriApp.AppNutri.service;
using NutriApp.Componente;

namespace NutriApp.AppNutri.View.Evaluation.CircumferenceCalf;

public class CircumferenceCalfViewModel : BaseViewModel
{
    private string _result;
    public string Result
    {
        get => _result;
        set
        {
            _result = value;
            OnPropertyChanged("Result");
        }
    }

    private bool _canDisplayResult;
    public bool CanDisplayResult
    {
        get => _canDisplayResult;
        set
        {
            _canDisplayResult = value;
            OnPropertyChanged("CanDisplayResult");
        }
    }

    private string _circumferenceCalf;
    public string CircumferenceCalf
    {
        get => _circumferenceCalf;
        set
        {
            _circumferenceCalf = value;
            OnPropertyChanged("CircumferenceCalf");
        }
    }

    private bool _hasErrorCircumferenceCalf;
    public bool HasErrorCircumferenceCalf
    {
        get => _hasErrorCircumferenceCalf;
        set
        {
            _hasErrorCircumferenceCalf = value;
            OnPropertyChanged("HasErrorCircumferenceCalf");
        }
    }

    public Command CalculateCommand { get; set; }
    public Command InfoCommand { get; set; }

    public CircumferenceCalfViewModel()
    {
        CalculateCommand = new Command(Calculate);
        //InfoCommand = new Command(async () => await Navigation.PushPopupAsync(new InfoCircumferenceCalfPopup()));
    }

    private void Calculate()
    {
        if (!Validate())
        {
            CanDisplayResult = false;
            return;
        }

        Result = WaistCircumferenceService.GetCalfCircumference(Convert.ToDouble(CircumferenceCalf));

        if (!string.IsNullOrWhiteSpace(Result))
        {
            CanDisplayResult = true;
        }
    }

    private bool Validate()
    {
        HasErrorCircumferenceCalf = string.IsNullOrWhiteSpace(CircumferenceCalf);
        return !HasErrorCircumferenceCalf;
    }
}