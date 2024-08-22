using NutriApp.Resources.Strings;

namespace NutriApp.Views.AnthropometricEvaluation.View.BodyComposition;

public partial class BodyCompositionViewModel : BaseViewModel
{
    [ObservableProperty] private AnthropometricEvaluationModel _anthropometricEvaluationModel;
    [ObservableProperty] private string _genderType;
    [ObservableProperty] private string _anthropometricEvaluationTypeString;
    [ObservableProperty] private string _abdominal;
    [ObservableProperty] private string _biceps;
    [ObservableProperty] private string _triceps;
    [ObservableProperty] private string _suprailiac;
    [ObservableProperty] private string _middleAxillary;
    [ObservableProperty] private string _subScapular;
    [ObservableProperty] private string _chest;
    [ObservableProperty] private string _thigh;
    [ObservableProperty] private string _medialCalf;
    
    [ObservableProperty] private bool _displayAbdominal;
    [ObservableProperty] private bool _displayBiceps;
    [ObservableProperty] private bool _displayTriceps;
    [ObservableProperty] private bool _displaySubScapular;
    [ObservableProperty] private bool _displaySuprailiac;
    [ObservableProperty] private bool _displayMiddleAxillary;
    [ObservableProperty] private bool _displayThigh;
    [ObservableProperty] private bool _displayChest;
    [ObservableProperty] private bool _displayMedialCalf;
    
    [ObservableProperty] private bool _hasErrorBiceps;
    [ObservableProperty] private bool _hasErrorTriceps;
    [ObservableProperty] private bool _hasErrorSubScapular;
    [ObservableProperty] private bool _hasErrorSuprailiac;
    [ObservableProperty] private bool _hasErrorMiddleAxillary;
    [ObservableProperty] private bool _hasErrorAbdominal;
    [ObservableProperty] private bool _hasErrorThigh;
    [ObservableProperty] private bool _hasErrorChest;
    [ObservableProperty] private bool _hasErrorMedialCalf;


    public BodyCompositionViewModel()
    {
        AnthropometricEvaluationModel = new AnthropometricEvaluationModel();
    }

    public void SelectAnthropometricEvaluationType()
    {
        if (string.IsNullOrWhiteSpace(AnthropometricEvaluationTypeString) ||
            string.IsNullOrWhiteSpace(GenderType)) return;

        WipeData();

        DisplayAbdominal = false;
        DisplayBiceps = false;
        DisplayTriceps = false;

        DisplaySuprailiac = false;
        DisplayMiddleAxillary = false;
        DisplaySubScapular = false;

        DisplayChest = false;
        DisplayThigh = false;
        DisplayMedialCalf = false;

        if (AnthropometricEvaluationStrings.SevenPleatsJacksonPolloc == AnthropometricEvaluationTypeString)
        {
            DisplaySevenPleatsJacksonPolloc();
        }

        if (AnthropometricEvaluationStrings.SevenPleatsJacksonPolloc == AnthropometricEvaluationTypeString)
        {
            DisplayFourPleatsDurninWomersley();
        }

        if (AnthropometricEvaluationStrings.FourPleatsPetroski == AnthropometricEvaluationTypeString)
        {
            DisplayFourPleatsPetroski();
        }

        if (AnthropometricEvaluationStrings.ThreePleatsJacksonPolloc == AnthropometricEvaluationTypeString)
        {
            DisplayThreePleatsJacksonPolloc();
        }

        if (AnthropometricEvaluationStrings.ThreePleatsGuedes == AnthropometricEvaluationTypeString)
        {
            DisplayThreePleatsGuedes();
        }
    }

    private void DisplayThreePleatsGuedes()
    {
        if (GenderUtils.ConverterGender(GenderType) == Genders.Male)
        {
            //Homens (tríceps, suprailíaca, abdominal)
            DisplayTriceps = true;
            DisplaySuprailiac = true;
            DisplayAbdominal = true;
        }

        if (GenderUtils.ConverterGender(GenderType) == Genders.Female)
        {
            //Mulheres (subescapular, suprailíaca, coxa)
            DisplaySubScapular = true;
            DisplaySuprailiac = true;
            DisplayThigh = true;
        }
    }

    private void DisplayFourPleatsPetroski()
    {
        if (GenderUtils.ConverterGender(GenderType) == Genders.Male)
        {
            //Homens (subescapular, tríceps, suprailíaca, panturrilha medial))
            DisplaySubScapular = true;
            DisplayTriceps = true;
            DisplaySuprailiac = true;
            DisplayMedialCalf = true;
        }

        if (GenderUtils.ConverterGender(GenderType) == Genders.Female)
        {
            //Mulheres (axila medial, suprailíaca, coxa, panturrilha medial)
            DisplayMiddleAxillary = true;
            DisplaySuprailiac = true;
            DisplayThigh = true;
            DisplayMedialCalf = true;
        }
    }

    private void DisplaySevenPleatsJacksonPolloc()
    {
        DisplayAbdominal = true;
        DisplayTriceps = true;
        DisplaySuprailiac = true;
        DisplayMiddleAxillary = true;
        DisplaySubScapular = true;
        DisplayChest = true;
        DisplayThigh = true;
    }

    private void DisplayFourPleatsDurninWomersley()
    {
        //Bicipital, tricipital, subescapular e suprailíaca.
        DisplayTriceps = true;
        DisplaySubScapular = true;
        DisplaySuprailiac = true;
        DisplayBiceps = true;
    }

    private void DisplayThreePleatsJacksonPolloc()
    {
        if (GenderUtils.ConverterGender(GenderType) == Genders.Female)
        {
            DisplayTriceps = true;
            DisplaySuprailiac = true;
            DisplayThigh = true;
        }

        if (GenderUtils.ConverterGender(GenderType) == Genders.Male)
        {
            DisplayChest = true;
            DisplayAbdominal = true;
            DisplayThigh = true;
        }
    }

    private void WipeData()
    {
        Abdominal = null;
        Biceps = null;
        Triceps = null;
        Suprailiac = null;
        MiddleAxillary = null;
        SubScapular = null;
        Chest = null;
        Thigh = null;
        MedialCalf = null;
    }

    public bool ValidateViewData()
    {
        bool validated = false;
        if (AnthropometricEvaluationStrings.SevenPleatsJacksonPolloc == AnthropometricEvaluationTypeString)
        {
            validated = ValidateJacksonPollocSevenPlats();
        }

        if (AnthropometricEvaluationStrings.ThreePleatsJacksonPolloc == AnthropometricEvaluationTypeString)
        {
            validated = ValidateJacksonPollocThreePlats();
        }

        if (AnthropometricEvaluationStrings.FourPleatsDurninWomersley == AnthropometricEvaluationTypeString)
        {
            validated = ValidateDurninWomersleyFourPleats();
        }

        if (AnthropometricEvaluationStrings.ThreePleatsGuedes == AnthropometricEvaluationTypeString)
        {
            validated = ValidadeGuedesThreePlats();
        }

        if (AnthropometricEvaluationStrings.FourPleatsPetroski == AnthropometricEvaluationTypeString)
        {
            validated = ValidateFourPleatsPetroski();
        }

        if (!validated) return false;
        FillAnthropometricEvaluationModel();

        return true;
    }

    private bool ValidadeGuedesThreePlats()
    {
        if (GenderUtils.ConverterGender(GenderType) == Genders.Male)
        {
            HasErrorTriceps = string.IsNullOrWhiteSpace(Triceps);
            HasErrorSuprailiac = string.IsNullOrWhiteSpace(Suprailiac);
            HasErrorAbdominal = string.IsNullOrWhiteSpace(Abdominal);
            return (!HasErrorTriceps && !HasErrorSuprailiac && !HasErrorAbdominal);
        }

        if (GenderUtils.ConverterGender(GenderType) == Genders.Female)
        {
            HasErrorSubScapular = string.IsNullOrWhiteSpace(SubScapular);
            HasErrorSuprailiac = string.IsNullOrWhiteSpace(Suprailiac);
            HasErrorThigh = string.IsNullOrWhiteSpace(Thigh);
            return (!HasErrorSubScapular && !HasErrorSuprailiac && !HasErrorThigh);
        }

        return false;
    }

    private void FillAnthropometricEvaluationModel()
    {
        AnthropometricEvaluationModel.Abdominal = Convert.ToDouble(Abdominal);
        AnthropometricEvaluationModel.Biceps = Convert.ToDouble(Biceps);
        AnthropometricEvaluationModel.Chest = Convert.ToDouble(Chest);
        AnthropometricEvaluationModel.MiddleAxillary = Convert.ToDouble(MiddleAxillary);
        AnthropometricEvaluationModel.MedialAxilla = Convert.ToDouble(MedialCalf);
        AnthropometricEvaluationModel.SubScapular = Convert.ToDouble(SubScapular);
        AnthropometricEvaluationModel.SupraIliac = Convert.ToDouble(Suprailiac);
        AnthropometricEvaluationModel.Triceps = Convert.ToDouble(Triceps);
        AnthropometricEvaluationModel.Thigh = Convert.ToDouble(Thigh);
    }

    private bool ValidateJacksonPollocSevenPlats()
    {
        HasErrorTriceps = string.IsNullOrWhiteSpace(Triceps);
        HasErrorSubScapular = string.IsNullOrWhiteSpace(SubScapular);
        HasErrorSuprailiac = string.IsNullOrWhiteSpace(Suprailiac);
        HasErrorAbdominal = string.IsNullOrWhiteSpace(Abdominal);
        HasErrorThigh = string.IsNullOrWhiteSpace(Thigh);
        HasErrorChest = string.IsNullOrWhiteSpace(Chest);
        HasErrorMiddleAxillary = string.IsNullOrWhiteSpace(MiddleAxillary);

        return (!HasErrorTriceps && !HasErrorSubScapular && !HasErrorSuprailiac && !HasErrorAbdominal &&
                !HasErrorThigh && !HasErrorChest && !HasErrorMiddleAxillary);
    }

    private bool ValidateDurninWomersleyFourPleats()
    {
        HasErrorTriceps = string.IsNullOrEmpty(Triceps);
        HasErrorSubScapular = string.IsNullOrEmpty(SubScapular);
        HasErrorSuprailiac = string.IsNullOrEmpty(Suprailiac);
        HasErrorBiceps = string.IsNullOrEmpty(Biceps);
        return (!HasErrorTriceps && !HasErrorSubScapular && !HasErrorSuprailiac && !HasErrorBiceps);
    }

    private bool ValidateFourPleatsPetroski()
    {
        if (GenderUtils.ConverterGender(GenderType) == Genders.Male)
        {
            //Homens (subescapular, tríceps, suprailíaca, panturrilha medial))
            HasErrorSubScapular = string.IsNullOrEmpty(SubScapular);
            HasErrorTriceps = string.IsNullOrEmpty(Triceps);
            HasErrorSuprailiac = string.IsNullOrEmpty(Suprailiac);
            HasErrorMedialCalf = string.IsNullOrEmpty(MedialCalf);

            return (!HasErrorSubScapular && !HasErrorTriceps && !HasErrorSuprailiac && !HasErrorMedialCalf);
        }

        if (GenderUtils.ConverterGender(GenderType) == Genders.Female)
        {
            //Mulheres (axila medial, suprailíaca, coxa, panturrilha medial)
            HasErrorMiddleAxillary = string.IsNullOrEmpty(MiddleAxillary);
            HasErrorSuprailiac = string.IsNullOrEmpty(Suprailiac);
            HasErrorThigh = string.IsNullOrEmpty(Thigh);
            HasErrorMedialCalf = string.IsNullOrEmpty(MedialCalf);

            return (!HasErrorMiddleAxillary && !HasErrorSuprailiac && !HasErrorThigh && !HasErrorMedialCalf);
        }

        return false;
    }

    private bool ValidateJacksonPollocThreePlats()
    {
        if (GenderUtils.ConverterGender(GenderType) == Genders.Female)
        {
            HasErrorTriceps = string.IsNullOrWhiteSpace(Triceps);
            HasErrorSuprailiac = string.IsNullOrWhiteSpace(Suprailiac);
            HasErrorThigh = string.IsNullOrWhiteSpace(Thigh);
            return (!HasErrorTriceps && !HasErrorSuprailiac && !HasErrorThigh);
        }

        if (GenderUtils.ConverterGender(GenderType) == Genders.Male)
        {
            HasErrorChest = string.IsNullOrWhiteSpace(Chest);
            HasErrorAbdominal = string.IsNullOrWhiteSpace(Abdominal);
            HasErrorThigh = string.IsNullOrWhiteSpace(Thigh);
            return (!HasErrorChest && !HasErrorAbdominal && !HasErrorThigh);
        }

        return false;
    }
}