using System.Globalization;
using System.Windows.Input;
using CommunityToolkit.Maui.Views;
using NutriApp.Views.Evaluation.IdealWeight.InfoPopup;

namespace NutriApp.Views.Evaluation.IdealWeight;

public partial class IdealWeightViewModel : BaseViewModel
{
    [ObservableProperty]
    private bool _canDisplay;
    [ObservableProperty]
    private Item _imcIdeal;
    [ObservableProperty]
    private string _height;
    [ObservableProperty]
    private string _idealWeight;
    [ObservableProperty]
    private bool _hasErrorHeight;
    [ObservableProperty]
    private bool _hasErrorImcIdeal;
    public ObservableCollection<Item> ItemImcIdeal { get; set; }
    public ICommand InfoCommand { get; set; }

    public IdealWeightViewModel()
    {
        InfoCommand = new RelayCommand(() => Shell.Current.CurrentPage.ShowPopup(new InfoIdealWeightPopup()));
        CanDisplay = false;
        Fill();
    }

    private void Fill()
    {
        ItemImcIdeal = new ObservableCollection<Item>
        {
            new() { Id = 22, Nome = "Homem 22 kg/m²" },
            new() { Id = 21, Nome = "Mulher 21 kg/m²" }
        };
    }
    
    [RelayCommand]
    private void Calculate()
    {
        if (!Validate())
        {
            CanDisplay = false;
            return;
        }

        IdealWeight = EvaluationCalculations
            .IdealWeight(Convert.ToDouble(ImcIdeal.Id), Utils.ParseToDoubleWithCommaSeparator(Height))
            .ToString(CultureInfo.InvariantCulture);
        if (!string.IsNullOrEmpty(IdealWeight))
        {
            CanDisplay = true;
        }
    }

    private bool Validate()
    {
        HasErrorHeight = string.IsNullOrWhiteSpace(Height);
        HasErrorImcIdeal = ImcIdeal == null;

        return (!HasErrorHeight && !HasErrorImcIdeal);
    }
}