using System.Globalization;
using NutriApp.AppNutri.Model;
using NutriApp.AppNutri.Utils;
using NutriApp.Componente;

namespace NutriApp.AppNutri.View.Evaluation.EstimatedHeight;

public class EstimatedHeightPageViewModel : BaseViewModel
{
    private bool _checkedWoman;
    public bool CheckedWoman
    {
        get => _checkedWoman;
        set
        {
            _checkedWoman = value;
            OnPropertyChanged("CheckedWoman");
            if (CheckedWoman) CheckedMan = false;
        }
    }

    private bool _checkedMan;
    public bool CheckedMan
    {
        get => _checkedMan;
        set
        {
            _checkedMan = value;
            OnPropertyChanged("CheckedMan");
            if (CheckedMan) CheckedWoman = false;
        }
    }

    private string _kneeHeight;
    public string KneeHeight
    {
        get => _kneeHeight;
        set
        {
            _kneeHeight = value;
            OnPropertyChanged("KneeHeight");
        }
    }

    private string _age;
    public string Age
    {
        get => _age;
        set
        {
            _age = value;
            OnPropertyChanged("Age");
        }
    }

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

    private bool _hasErrorAge;
    public bool HasErrorAge
    {
        get => _hasErrorAge;
        set
        {
            _hasErrorAge = value;
            OnPropertyChanged("HasErrorAge");
        }
    }

    private bool _hasErrorKneeHeight;
    public bool HasErrorKneeHeight
    {
        get => _hasErrorKneeHeight;
        set
        {
            _hasErrorKneeHeight = value;
            OnPropertyChanged("HasErrorKneeHeight");
        }
    }

    public Command CalculateCommand { get; set; }
    public Command WomanCommand { get; set; }
    public Command ManCommand { get; set; }

    public EstimatedHeightPageViewModel()
    {
        CalculateCommand = new Command(Calculate);
        WomanCommand = new Command(() => CheckedWoman = !CheckedWoman);
        ManCommand = new Command(() => CheckedMan = !CheckedMan);
    }

    private void Calculate()
    {
        if (!Validate())
        {
            CanDisplayResult = false;
            return;
        }

        var estimateHeight = Convert.ToInt32(EvaluationCalculations.EstimatedHeight(Convert.ToDouble(KneeHeight),
            Convert.ToDouble(Age), CheckedMan ? Genders.Male : Genders.Female));
        Result = (Convert.ToDouble(estimateHeight) / 100).ToString(CultureInfo.InvariantCulture);
        if (!string.IsNullOrWhiteSpace(Result))
        {
            CanDisplayResult = true;
        }
    }

    private bool Validate()
    {
        HasErrorAge = string.IsNullOrWhiteSpace(Age);
        HasErrorKneeHeight = string.IsNullOrWhiteSpace(KneeHeight);
        if (!(CheckedWoman || CheckedMan))
        {
            //App.NavPage.DisplayToastAsync( "Selecione um gênero");
            return false;
        }

        return (!HasErrorAge && !HasErrorKneeHeight);
    }
}