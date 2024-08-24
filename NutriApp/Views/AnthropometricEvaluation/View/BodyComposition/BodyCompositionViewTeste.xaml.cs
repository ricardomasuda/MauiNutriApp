using NutriApp.Resources.Strings;

namespace NutriApp.Views.AnthropometricEvaluation.View.BodyComposition;

public partial class BodyCompositionViewTeste : ContentView
{
    public static readonly BindableProperty GenderTypeProperty =
        BindableProperty.Create(
            propertyName: nameof(GenderType),
            returnType: typeof(string),
            declaringType: typeof(BodyCompositionViewTeste),
            defaultValue: default(string));

    public static readonly BindableProperty AnthropometricEvaluationTypeStringProperty =
        BindableProperty.Create(
            propertyName: nameof(AnthropometricEvaluationTypeString),
            returnType: typeof(string),
            declaringType: typeof(BodyCompositionViewTeste),
            defaultValue: default(string));

    public static readonly BindableProperty AbdominalProperty =
        BindableProperty.Create(
            propertyName: nameof(Abdominal),
            returnType: typeof(string),
            declaringType: typeof(BodyCompositionViewTeste),
            defaultValue: default(string));

    public static readonly BindableProperty BicepsProperty =
        BindableProperty.Create(
            propertyName: nameof(Biceps),
            returnType: typeof(string),
            declaringType: typeof(BodyCompositionViewTeste),
            defaultValue: default(string));

    public static readonly BindableProperty TricepsProperty =
        BindableProperty.Create(
            propertyName: nameof(Triceps),
            returnType: typeof(string),
            declaringType: typeof(BodyCompositionViewTeste),
            defaultValue: default(string));

    public static readonly BindableProperty SuprailiacProperty =
        BindableProperty.Create(
            propertyName: nameof(Suprailiac),
            returnType: typeof(string),
            declaringType: typeof(BodyCompositionViewTeste),
            defaultValue: default(string));

    public static readonly BindableProperty MiddleAxillaryProperty =
        BindableProperty.Create(
            propertyName: nameof(MiddleAxillary),
            returnType: typeof(string),
            declaringType: typeof(BodyCompositionViewTeste),
            defaultValue: default(string));

    public static readonly BindableProperty ChestProperty =
        BindableProperty.Create(
            propertyName: nameof(Chest),
            returnType: typeof(string),
            declaringType: typeof(BodyCompositionViewTeste),
            defaultValue: default(string));

    public static readonly BindableProperty SubScapularProperty =
        BindableProperty.Create(
            propertyName: nameof(SubScapular),
            returnType: typeof(string),
            declaringType: typeof(BodyCompositionViewTeste),
            defaultValue: default(string));

    public static readonly BindableProperty ThighProperty =
        BindableProperty.Create(
            propertyName: nameof(Thigh),
            returnType: typeof(string),
            declaringType: typeof(BodyCompositionViewTeste),
            defaultValue: default(string));


    public static readonly BindableProperty MedialCalfProperty =
        BindableProperty.Create(
            propertyName: nameof(MedialCalf),
            returnType: typeof(string),
            declaringType: typeof(BodyCompositionViewTeste),
            defaultValue: default(string));
    
    public string GenderType
    {
        get => (string)GetValue(GenderTypeProperty);
        set => SetValue(GenderTypeProperty, value);
    }
    
    public string AnthropometricEvaluationTypeString
    {
        get => (string)GetValue(AnthropometricEvaluationTypeStringProperty);
        set => SetValue(AnthropometricEvaluationTypeStringProperty, value);
    }
    
    public string Abdominal
    {
        get => (string)GetValue(AbdominalProperty);
        set => SetValue(AbdominalProperty, value);
    }
    
    public string Biceps
    {
        get => (string)GetValue(BicepsProperty);
        set => SetValue(BicepsProperty, value);
    }
    
    public string Triceps
    {
        get => (string)GetValue(TricepsProperty);
        set => SetValue(TricepsProperty, value);
    }
    
    public string Suprailiac
    {
        get => (string)GetValue(SuprailiacProperty);
        set => SetValue(SuprailiacProperty, value);
    }

    public string MiddleAxillary
    {
        get => (string)GetValue(MiddleAxillaryProperty);
        set => SetValue(MiddleAxillaryProperty, value);
    }
    
    public string SubScapular
    {
        get => (string)GetValue(SubScapularProperty);
        set => SetValue(SubScapularProperty, value);
    }
    
    public string Chest
    {
        get => (string)GetValue(ChestProperty);
        set => SetValue(ChestProperty, value);
    }
    
    public string Thigh
    {
        get => (string)GetValue(ThighProperty);
        set => SetValue(ThighProperty, value);
    }
    
    public string MedialCalf
    {
        get => (string)GetValue(MedialCalfProperty);
        set => SetValue(MedialCalfProperty, value);
    }

    // Propriedades observáveis para _hasError*
    private bool _hasErrorBiceps;
    public bool HasErrorBiceps
    {
        get => _hasErrorBiceps;
        set => SetProperty(ref _hasErrorBiceps, value);
    }

    private bool _hasErrorTriceps;
    public bool HasErrorTriceps
    {
        get => _hasErrorTriceps;
        set => SetProperty(ref _hasErrorTriceps, value);
    }

    private bool _hasErrorSubScapular;
    public bool HasErrorSubScapular
    {
        get => _hasErrorSubScapular;
        set => SetProperty(ref _hasErrorSubScapular, value);
    }

    private bool _hasErrorSuprailiac;
    public bool HasErrorSuprailiac
    {
        get => _hasErrorSuprailiac;
        set => SetProperty(ref _hasErrorSuprailiac, value);
    }

    private bool _hasErrorMiddleAxillary;
    public bool HasErrorMiddleAxillary
    {
        get => _hasErrorMiddleAxillary;
        set => SetProperty(ref _hasErrorMiddleAxillary, value);
    }

    private bool _hasErrorAbdominal;
    public bool HasErrorAbdominal
    {
        get => _hasErrorAbdominal;
        set => SetProperty(ref _hasErrorAbdominal, value);
    }

    private bool _hasErrorThigh;
    public bool HasErrorThigh
    {
        get => _hasErrorThigh;
        set => SetProperty(ref _hasErrorThigh, value);
    }

    private bool _hasErrorChest;
    public bool HasErrorChest
    {
        get => _hasErrorChest;
        set => SetProperty(ref _hasErrorChest, value);
    }

    private bool _hasErrorMedialCalf;
    public bool HasErrorMedialCalf
    {
        get => _hasErrorMedialCalf;
        set => SetProperty(ref _hasErrorMedialCalf, value);
    }

    public BodyCompositionViewTeste()
    {
        InitializeComponent();
        SelectAnthropometricEvaluationType();
    }


    public void SelectAnthropometricEvaluationType()
    {
        if (string.IsNullOrWhiteSpace(AnthropometricEvaluationTypeString) ||
            string.IsNullOrWhiteSpace(GenderType)) return;

        //WipeData();

        LayoutAbdominalView.IsEnabled = false;
        LayoutBicepsView.IsEnabled = false;
        LayoutTricepsView.IsEnabled = false;

        LayoutSuprailiacView.IsEnabled = false;
        LayoutMiddleAxillarycView.IsEnabled = false;
        LayoutSubScapularView.IsEnabled = false;

        LayoutChestView.IsEnabled = false;
        LayoutThighView.IsEnabled = false;
        LayoutMedialCalfView.IsEnabled = false;

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
            LayoutTricepsView.IsEnabled = true;
            LayoutSuprailiacView.IsEnabled = true;
            LayoutAbdominalView.IsEnabled = true;
        }

        if (GenderUtils.ConverterGender(GenderType) == Genders.Female)
        {
            //Mulheres (subescapular, suprailíaca, coxa)
            LayoutSubScapularView.IsEnabled = true;
            LayoutSuprailiacView.IsEnabled = true;
            LayoutThighView.IsEnabled = true;
        }
    }

    private void DisplayFourPleatsPetroski()
    {
        if (GenderUtils.ConverterGender(GenderType) == Genders.Male)
        {
            //Homens (subescapular, tríceps, suprailíaca, panturrilha medial))
            LayoutSubScapularView.IsEnabled = true;
            LayoutTricepsView.IsEnabled = true;
            LayoutSuprailiacView.IsEnabled = true;
            LayoutMedialCalfView.IsEnabled = true;
        }

        if (GenderUtils.ConverterGender(GenderType) == Genders.Female)
        {
            //Mulheres (axila medial, suprailíaca, coxa, panturrilha medial)
            LayoutMiddleAxillarycView.IsEnabled = true;
            LayoutSuprailiacView.IsEnabled = true;
            LayoutThighView.IsEnabled = true;
            LayoutMedialCalfView.IsEnabled = true;
        }
    }

    private void DisplaySevenPleatsJacksonPolloc()
    {
        LayoutAbdominalView.IsEnabled = true;
        LayoutTricepsView.IsEnabled = true;
        LayoutSuprailiacView.IsEnabled = true;
        LayoutMiddleAxillarycView.IsEnabled = true;
        LayoutSubScapularView.IsEnabled = true;
        LayoutChestView.IsEnabled = true;
        LayoutThighView.IsEnabled = true;
    }

    private void DisplayFourPleatsDurninWomersley()
    {
        //Bicipital, tricipital, subescapular e suprailíaca.
        LayoutTricepsView.IsEnabled = true;
        LayoutSubScapularView.IsEnabled = true;
        LayoutSuprailiacView.IsEnabled = true;
        LayoutBicepsView.IsEnabled = true;
    }

    private void DisplayThreePleatsJacksonPolloc()
    {
        if (GenderUtils.ConverterGender(GenderType) == Genders.Female)
        {
            LayoutTricepsView.IsEnabled = true;
            LayoutSuprailiacView.IsEnabled = true;
            LayoutThighView.IsEnabled = true;
        }

        if (GenderUtils.ConverterGender(GenderType) == Genders.Male)
        {
            LayoutChestView.IsEnabled = true;
            LayoutAbdominalView.IsEnabled = true;
            LayoutThighView.IsEnabled= true;
        }
    }
    


    public event PropertyChangedEventHandler PropertyChanged;

    protected override void OnPropertyChanged([CallerMemberName] string propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        base.OnPropertyChanged(propertyName);
        
        if (propertyName == GenderTypeProperty.PropertyName)
        {
            SelectAnthropometricEvaluationType();
        }
        
        if (propertyName == AnthropometricEvaluationTypeStringProperty.PropertyName)
        {
            SelectAnthropometricEvaluationType();
        }
    }

    protected bool SetProperty<T>(ref T field, T value, [CallerMemberName] string propertyName = null)
    {
        if (EqualityComparer<T>.Default.Equals(field, value))
            return false;

        field = value;
        OnPropertyChanged(propertyName);
        return true;
    }
}