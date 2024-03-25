using System.Globalization;
using System.Windows.Input;
using CommunityToolkit.Maui.Core;
using NutriApp.Utils;

namespace NutriApp.Views.Evaluation.EstimatedHeight;

public partial class EstimatedHeightPageViewModel : BaseViewModel
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
    [ObservableProperty]
    private string _kneeHeight;
    [ObservableProperty]
    private string _age;
    [ObservableProperty]
    private string _result;
    [ObservableProperty]
    private bool _canDisplayResult;
    [ObservableProperty]
    private bool _hasErrorAge;
    [ObservableProperty]
    private bool _hasErrorKneeHeight;

    public ICommand WomanCommand { get; set; }
    public ICommand ManCommand { get; set; }

    public EstimatedHeightPageViewModel()
    {
        WomanCommand = new RelayCommand(() => CheckedWoman = !CheckedWoman);
        ManCommand = new RelayCommand(() => CheckedMan = !CheckedMan);
    }
    
    [RelayCommand]
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
            InfoToaster( "Selecione um gênero", ToastDuration.Long);
            return false;
        }

        return (!HasErrorAge && !HasErrorKneeHeight);
    }
}