using NutriApp.Resources.Strings;
using NutriApp.Services.AnthropometricEvaluation;
using Microsoft.Maui.Graphics;
using NutriApp.Views.AnthropometricEvaluation.View.BodyComposition;
using NutriApp.Views.AnthropometricEvaluation.View.BoneDiameter;

namespace NutriApp.Views.AnthropometricEvaluation;

public partial class AnthropometricEvaluationViewModel : BaseViewModel
{
    private string _anthropometricEvaluationType;
    public string AnthropometricEvaluationType
    {
        get => _anthropometricEvaluationType;
        set
        {
            _anthropometricEvaluationType = value;
            BodyCompositionViewModel.AnthropometricEvaluationTypeString = value;
            BodyCompositionViewModel.SelectAnthropometricEvaluationType();
            OnPropertyChanged("AnthropometricEvaluationType");
        }
    }

    private Item _genderType;

    public Item GenderType
    {
        get => _genderType;
        set
        {
            BodyCompositionViewModel.GenderType = value.Nome;
            BodyCompositionViewModel.SelectAnthropometricEvaluationType();
            _genderType = value;
            OnPropertyChanged("GenderType");
        }
    }

    [ObservableProperty] private List<string> _anthropometricEvaluationTypeList;
    [ObservableProperty] private BoneDiameterViewModel _boneDiameterViewModel;
    [ObservableProperty] private BodyCompositionViewModel _bodyCompositionViewModel;
    [ObservableProperty] private string _age;
    [ObservableProperty] private string _weight;
    [ObservableProperty] private bool _hasErrorGender;
    [ObservableProperty] private bool _hasErrorAnthropometricEvaluation;
    [ObservableProperty] private bool _hasErrorWeigh;
    [ObservableProperty] private bool _hasErrorAge;
    [ObservableProperty] private bool _canDisplayResult;
    [ObservableProperty] private AnthropometricEvaluationResultModel _anthropometricEvaluationResultModel;
    [ObservableProperty] private BoneDiameterModel _boneDiameterModel;
    [ObservableProperty] private bool _boneDiameterExpanded;

    // private ExpandState _expandState;
    // public ExpandState ExpandState { get => _expandState; 
    //     set { _expandState = value;
    //         Color = value == ExpandState.Expanded ? Color.Black : Color.Gray;
    //         OnPropertyChanged("ExpandState"); } 
    // }
    [ObservableProperty] private System.Drawing.Color _color;
    public ObservableCollection<Item> ListGender { get; set; }

    public AnthropometricEvaluationViewModel()
    {
        Fill();
    }

    private void Fill()
    {
        BoneDiameterViewModel = new BoneDiameterViewModel();
        BodyCompositionViewModel = new BodyCompositionViewModel();
        Color = System.Drawing.Color.MediumSpringGreen;
        AnthropometricEvaluationTypeList = new List<string>();
        AnthropometricEvaluationTypeList.Add(AnthropometricEvaluationStrings.SevenPleatsJacksonPolloc);
        AnthropometricEvaluationTypeList.Add(AnthropometricEvaluationStrings.FourPleatsDurninWomersley);
        AnthropometricEvaluationTypeList.Add(AnthropometricEvaluationStrings.FourPleatsPetroski);
        AnthropometricEvaluationTypeList.Add(AnthropometricEvaluationStrings.ThreePleatsJacksonPolloc);
        AnthropometricEvaluationTypeList.Add(AnthropometricEvaluationStrings.ThreePleatsGuedes);

        ListGender = new ObservableCollection<Item>
        {
            new() { Id = 0, Nome = "Homem" },
            new() { Id = 1, Nome = "Mulher" }
        };
    }

    [RelayCommand]
    private void Calculate()
    {
        if (!ValidateData()) return;
        if (!BodyCompositionViewModel.ValidateViewData()) return;

        PatientModel patient = new();

        if (AnthropometricEvaluationType == AnthropometricEvaluationStrings.SevenPleatsJacksonPolloc)
        {
            AnthropometricEvaluationResultModel = AnthropometricEvaluationService.Calculate(
                AnthropometricEvaluationTypeEnum.JacksonAndPollockSevenPleats,
                BodyCompositionViewModel.AnthropometricEvaluationModel, Convert.ToDouble(Weight), Convert.ToInt32(Age),
                GenderUtils.ConverterGender(GenderType.Nome));
        }

        if (AnthropometricEvaluationType == AnthropometricEvaluationStrings.ThreePleatsJacksonPolloc)
        {
            AnthropometricEvaluationResultModel = AnthropometricEvaluationService.Calculate(
                AnthropometricEvaluationTypeEnum.JacksonAndPollockThreePleats,
                BodyCompositionViewModel.AnthropometricEvaluationModel, Convert.ToDouble(Weight), Convert.ToInt32(Age),
                GenderUtils.ConverterGender(GenderType.Nome));
        }

        if (AnthropometricEvaluationType == AnthropometricEvaluationStrings.FourPleatsDurninWomersley)
        {
            AnthropometricEvaluationResultModel = AnthropometricEvaluationService.Calculate(
                AnthropometricEvaluationTypeEnum.DurninAndWomersley,
                BodyCompositionViewModel.AnthropometricEvaluationModel, Convert.ToDouble(Weight), Convert.ToInt32(Age),
                GenderUtils.ConverterGender(GenderType.Nome));
        }

        if (AnthropometricEvaluationType == AnthropometricEvaluationStrings.FourPleatsPetroski)
        {
            AnthropometricEvaluationResultModel = AnthropometricEvaluationService.Calculate(
                AnthropometricEvaluationTypeEnum.Petroski, BodyCompositionViewModel.AnthropometricEvaluationModel,
                Convert.ToDouble(Weight), Convert.ToInt32(Age),
                GenderUtils.ConverterGender(GenderType.Nome));
        }

        if (AnthropometricEvaluationType == AnthropometricEvaluationStrings.ThreePleatsGuedes)
        {
            AnthropometricEvaluationResultModel = AnthropometricEvaluationService.Calculate(
                AnthropometricEvaluationTypeEnum.Guedes, BodyCompositionViewModel.AnthropometricEvaluationModel,
                Convert.ToDouble(Weight), Convert.ToInt32(Age),
                GenderUtils.ConverterGender(GenderType.Nome));
        }

        if (_boneDiameterExpanded)
        {
            if (BoneDiameterViewModel.ValidateViewData())
            {
                patient.Wrist = Convert.ToDouble(BoneDiameterViewModel.Wrist);
                patient.Height = Convert.ToDouble(BoneDiameterViewModel.Height);
                patient.Femur = Convert.ToDouble(BoneDiameterViewModel.Femur);
                patient.Gender = GenderUtils.ConverterGender(GenderType.Nome);
                patient.Weigh = Convert.ToDouble(Weight);
                BoneDiameterModel =
                    BodyCompositionService.Calculate(patient, AnthropometricEvaluationResultModel.BodyLean);
            }
        }

        CanDisplayResult = true;

        // Device.BeginInvokeOnMainThread(async () =>
        // {
        //     await _anthropometricEvaluationPage.EndScroll();
        // });
    }

    private bool ValidateData()
    {
        HasErrorAge = string.IsNullOrWhiteSpace(Age);
        HasErrorAnthropometricEvaluation = string.IsNullOrEmpty(AnthropometricEvaluationType);
        HasErrorGender = string.IsNullOrEmpty(GenderType?.Nome);
        HasErrorWeigh = string.IsNullOrEmpty(Weight);

        return (!HasErrorAge && !HasErrorAnthropometricEvaluation && !HasErrorGender && !HasErrorWeigh);
    }
}