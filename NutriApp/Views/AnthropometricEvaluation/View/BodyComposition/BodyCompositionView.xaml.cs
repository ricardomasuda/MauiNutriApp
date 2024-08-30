using NutriApp.Resources.Strings;

namespace NutriApp.Views.AnthropometricEvaluation.View.BodyComposition;

public partial class BodyCompositionView : ContentView
{
    public static readonly BindableProperty AnthropometricEvaluationModelProperty =
        BindableProperty.Create(
            propertyName: nameof(AnthropometricEvaluationModel),
            returnType: typeof(AnthropometricEvaluationPageModel),
            declaringType: typeof(BodyCompositionView));
    
    public AnthropometricEvaluationPageModel AnthropometricEvaluationModel
    {
        get => (AnthropometricEvaluationPageModel)GetValue(AnthropometricEvaluationModelProperty);
        set => SetValue(AnthropometricEvaluationModelProperty, value);
    }

    
    
    public static readonly BindableProperty GenderTypeProperty =
        BindableProperty.Create(
            propertyName: nameof(GenderType),
            returnType: typeof(string),
            declaringType: typeof(BodyCompositionView),
            defaultValue: default(string));
    
    public static readonly BindableProperty AnthropometricEvaluationTypeStringProperty =
        BindableProperty.Create(
            propertyName: nameof(AnthropometricEvaluationTypeString),
            returnType: typeof(string),
            declaringType: typeof(BodyCompositionView),
            defaultValue: default(string));
    //
    // public static readonly BindableProperty AbdominalProperty =
    //     BindableProperty.Create(
    //         propertyName: nameof(Abdominal),
    //         returnType: typeof(string),
    //         declaringType: typeof(BodyCompositionView),
    //         defaultValue: default(string));
    //
    // public static readonly BindableProperty BicepsProperty =
    //     BindableProperty.Create(
    //         propertyName: nameof(Biceps),
    //         returnType: typeof(string),
    //         declaringType: typeof(BodyCompositionView),
    //         defaultValue: default(string));
    //
    // public static readonly BindableProperty TricepsProperty =
    //     BindableProperty.Create(
    //         propertyName: nameof(Triceps),
    //         returnType: typeof(string),
    //         declaringType: typeof(BodyCompositionView),
    //         defaultValue: default(string));
    //
    // public static readonly BindableProperty SuprailiacProperty =
    //     BindableProperty.Create(
    //         propertyName: nameof(Suprailiac),
    //         returnType: typeof(string),
    //         declaringType: typeof(BodyCompositionView),
    //         defaultValue: default(string));
    //
    // public static readonly BindableProperty MiddleAxillaryProperty =
    //     BindableProperty.Create(
    //         propertyName: nameof(MiddleAxillary),
    //         returnType: typeof(string),
    //         declaringType: typeof(BodyCompositionView),
    //         defaultValue: default(string));
    //
    // public static readonly BindableProperty ChestProperty =
    //     BindableProperty.Create(
    //         propertyName: nameof(Chest),
    //         returnType: typeof(string),
    //         declaringType: typeof(BodyCompositionView),
    //         defaultValue: default(string));
    //
    // public static readonly BindableProperty SubScapularProperty =
    //     BindableProperty.Create(
    //         propertyName: nameof(SubScapular),
    //         returnType: typeof(string),
    //         declaringType: typeof(BodyCompositionView),
    //         defaultValue: default(string));
    //
    // public static readonly BindableProperty ThighProperty =
    //     BindableProperty.Create(
    //         propertyName: nameof(Thigh),
    //         returnType: typeof(string),
    //         declaringType: typeof(BodyCompositionView),
    //         defaultValue: default(string));
    //
    //
    // public static readonly BindableProperty MedialCalfProperty =
    //     BindableProperty.Create(
    //         propertyName: nameof(MedialCalf),
    //         returnType: typeof(string),
    //         declaringType: typeof(BodyCompositionView),
    //         defaultValue: default(string));
    //
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
    
    // public string Abdominal
    // {
    //     get => (string)GetValue(AbdominalProperty);
    //     set => SetValue(AbdominalProperty, value);
    // }
    //
    // public string Biceps
    // {
    //     get => (string)GetValue(BicepsProperty);
    //     set => SetValue(BicepsProperty, value);
    // }
    //
    // public string Triceps
    // {
    //     get => (string)GetValue(TricepsProperty);
    //     set => SetValue(TricepsProperty, value);
    // }
    //
    // public string Suprailiac
    // {
    //     get => (string)GetValue(SuprailiacProperty);
    //     set => SetValue(SuprailiacProperty, value);
    // }
    //
    // public string MiddleAxillary
    // {
    //     get => (string)GetValue(MiddleAxillaryProperty);
    //     set => SetValue(MiddleAxillaryProperty, value);
    // }
    //
    // public string SubScapular
    // {
    //     get => (string)GetValue(SubScapularProperty);
    //     set => SetValue(SubScapularProperty, value);
    // }
    //
    // public string Chest
    // {
    //     get => (string)GetValue(ChestProperty);
    //     set => SetValue(ChestProperty, value);
    // }
    //
    // public string Thigh
    // {
    //     get => (string)GetValue(ThighProperty);
    //     set => SetValue(ThighProperty, value);
    // }
    //
    // public string MedialCalf
    // {
    //     get => (string)GetValue(MedialCalfProperty);
    //     set => SetValue(MedialCalfProperty, value);
    // }

    public BodyCompositionView()
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

        if (AnthropometricEvaluationStrings.FourPleatsDurninWomersley == AnthropometricEvaluationTypeString)
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
        //FillAnthropometricEvaluationModel();

        return true;
    }

    private bool ValidadeGuedesThreePlats()
    {
        if (GenderUtils.ConverterGender(GenderType) == Genders.Male)
        {
            LayoutTricepsView.HasError = string.IsNullOrWhiteSpace(AnthropometricEvaluationModel.Triceps);
            LayoutSuprailiacView.HasError = string.IsNullOrWhiteSpace(AnthropometricEvaluationModel.Suprailiac);
            LayoutAbdominalView.HasError = string.IsNullOrWhiteSpace(AnthropometricEvaluationModel.Abdominal);
            return (!LayoutTricepsView.HasError && ! LayoutSuprailiacView.HasError && ! LayoutAbdominalView.HasError);
        }

        if (GenderUtils.ConverterGender(GenderType) == Genders.Female)
        {
            LayoutSubScapularView.HasError = string.IsNullOrWhiteSpace(AnthropometricEvaluationModel.SubScapular);
            LayoutSuprailiacView.HasError  = string.IsNullOrWhiteSpace(AnthropometricEvaluationModel.Suprailiac);
            LayoutThighView.HasError = string.IsNullOrWhiteSpace(AnthropometricEvaluationModel.Thigh);
            return (!LayoutSubScapularView.HasError && !LayoutSuprailiacView.HasError  && !LayoutThighView.HasError);
        }

        return false;
    }

    // private void FillAnthropometricEvaluationModel()
    // {
    //     AnthropometricEvaluationModel.Abdominal = Convert.ToDouble(Abdominal);
    //     AnthropometricEvaluationModel.Biceps = Convert.ToDouble(Biceps);
    //     AnthropometricEvaluationModel.Chest = Convert.ToDouble(Chest);
    //     AnthropometricEvaluationModel.MiddleAxillary = Convert.ToDouble(MiddleAxillary);
    //     AnthropometricEvaluationModel.MedialAxilla = Convert.ToDouble(MedialCalf);
    //     AnthropometricEvaluationModel.SubScapular = Convert.ToDouble(SubScapular);
    //     AnthropometricEvaluationModel.SupraIliac = Convert.ToDouble(Suprailiac);
    //     AnthropometricEvaluationModel.Triceps = Convert.ToDouble(Triceps);
    //     AnthropometricEvaluationModel.Thigh = Convert.ToDouble(Thigh);
    // }

    private bool ValidateJacksonPollocSevenPlats()
    {
        LayoutTricepsView.HasError = string.IsNullOrWhiteSpace(AnthropometricEvaluationModel.Triceps);
        LayoutSubScapularView.HasError = string.IsNullOrWhiteSpace(AnthropometricEvaluationModel.SubScapular);
        LayoutSuprailiacView.HasError = string.IsNullOrWhiteSpace(AnthropometricEvaluationModel.Suprailiac);
        LayoutAbdominalView.HasError = string.IsNullOrWhiteSpace(AnthropometricEvaluationModel.Abdominal);
        LayoutThighView.HasError = string.IsNullOrWhiteSpace(AnthropometricEvaluationModel.Thigh);
        LayoutChestView.HasError = string.IsNullOrWhiteSpace(AnthropometricEvaluationModel.Chest);
        LayoutMiddleAxillarycView.HasError = string.IsNullOrWhiteSpace(AnthropometricEvaluationModel.MiddleAxillary);

        return (! LayoutTricepsView.HasError && !LayoutSubScapularView.HasError && !LayoutSuprailiacView.HasError && !LayoutAbdominalView.HasError &&
                !LayoutThighView.HasError && !LayoutChestView.HasError && !LayoutMiddleAxillarycView.HasError);
    }

    private bool ValidateDurninWomersleyFourPleats()
    {
        LayoutTricepsView.HasError = string.IsNullOrEmpty(AnthropometricEvaluationModel.Triceps);
        LayoutSubScapularView.HasError = string.IsNullOrEmpty(AnthropometricEvaluationModel.SubScapular);
        LayoutSuprailiacView.HasError = string.IsNullOrEmpty(AnthropometricEvaluationModel.Suprailiac);
        LayoutBicepsView.HasError = string.IsNullOrEmpty(AnthropometricEvaluationModel.Biceps);
        return (! LayoutTricepsView.HasError && !LayoutSubScapularView.HasError && !LayoutSuprailiacView.HasError && !LayoutBicepsView.HasError);
    }

    private bool ValidateFourPleatsPetroski()
    {
        if (GenderUtils.ConverterGender(GenderType) == Genders.Male)
        {
            //Homens (subescapular, tríceps, suprailíaca, panturrilha medial))
            LayoutSubScapularView.HasError = string.IsNullOrEmpty(AnthropometricEvaluationModel.SubScapular);
            LayoutTricepsView.HasError= string.IsNullOrEmpty(AnthropometricEvaluationModel.Triceps);
            LayoutSuprailiacView.HasError = string.IsNullOrEmpty(AnthropometricEvaluationModel.Suprailiac);
            LayoutMedialCalfView.HasError = string.IsNullOrEmpty(AnthropometricEvaluationModel.MedialCalf);

            return (!LayoutSubScapularView.HasError && !LayoutTricepsView.HasError && !LayoutSuprailiacView.HasError && !LayoutMedialCalfView.HasError);
        }

        if (GenderUtils.ConverterGender(GenderType) == Genders.Female)
        {
            //Mulheres (axila medial, suprailíaca, coxa, panturrilha medial)
            LayoutMiddleAxillarycView.HasError = string.IsNullOrEmpty(AnthropometricEvaluationModel.MiddleAxillary);
            LayoutSuprailiacView.HasError = string.IsNullOrEmpty(AnthropometricEvaluationModel.Suprailiac);
            LayoutThighView.HasError = string.IsNullOrEmpty(AnthropometricEvaluationModel.Thigh);
            LayoutMedialCalfView.HasError = string.IsNullOrEmpty(AnthropometricEvaluationModel.MedialCalf);

            return (!LayoutMiddleAxillarycView.HasError && !LayoutSuprailiacView.HasError && !LayoutThighView.HasError && !LayoutMedialCalfView.HasError);
        }

        return false;
    }

    private bool ValidateJacksonPollocThreePlats()
    {
        if (GenderUtils.ConverterGender(GenderType) == Genders.Female)
        {
            LayoutTricepsView.HasError = string.IsNullOrWhiteSpace(AnthropometricEvaluationModel.Triceps);
            LayoutSuprailiacView.HasError = string.IsNullOrWhiteSpace(AnthropometricEvaluationModel.Suprailiac);
            LayoutThighView.HasError = string.IsNullOrWhiteSpace(AnthropometricEvaluationModel.Thigh);
            return (!LayoutTricepsView.HasError && !LayoutSuprailiacView.HasError && !LayoutThighView.HasError);
        }

        if (GenderUtils.ConverterGender(GenderType) == Genders.Male)
        {
            LayoutChestView.HasError = string.IsNullOrWhiteSpace(AnthropometricEvaluationModel.Chest);
            LayoutAbdominalView.HasError = string.IsNullOrWhiteSpace(AnthropometricEvaluationModel.Abdominal);
            LayoutThighView.HasError = string.IsNullOrWhiteSpace(AnthropometricEvaluationModel.Thigh);
            return (!LayoutChestView.HasError && !LayoutAbdominalView.HasError && !LayoutThighView.HasError);
        }

        return false;
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