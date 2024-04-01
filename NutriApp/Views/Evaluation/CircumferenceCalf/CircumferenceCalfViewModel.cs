using System.Windows.Input;
using NutriApp.AppNutri.View.Evaluation.CircumferenceCalf.InfoPopup;

namespace NutriApp.Views.Evaluation.CircumferenceCalf;

public partial class CircumferenceCalfViewModel : BaseViewModel
{
    [ObservableProperty]
    private string _result;
    [ObservableProperty]
    private bool _canDisplayResult;
    [ObservableProperty]
    private string _circumferenceCalf;
    [ObservableProperty]
    private bool _hasErrorCircumferenceCalf;
    public ICommand InfoCommand { get; set; }

    public CircumferenceCalfViewModel()
    {
        InfoCommand = new RelayCommand(() => App.NavPage.ShowPopup(new InfoCircumferenceCalfPopup()));
    }
    
    [RelayCommand]
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