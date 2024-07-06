namespace NutriApp.Components.Table;

public partial class ReferenceValueView : ContentView
{
    public static readonly BindableProperty ValueReferenceProperty =
        BindableProperty.Create(
            propertyName: nameof(ValueReference),
            returnType: typeof(ValueReferenceModel),
            declaringType: typeof(ReferenceValueView),
            defaultValue: null);

    public static readonly BindableProperty FoodPlanIdProperty =
        BindableProperty.Create(
            propertyName: nameof(FoodPlanId),
            returnType: typeof(int),
            declaringType: typeof(ReferenceValueView),
            defaultValue: 0);

    public static readonly BindableProperty ProteinaProperty =
        BindableProperty.Create(
            propertyName: nameof(Proteina),
            returnType: typeof(string),
            declaringType: typeof(ReferenceValueView),
            defaultValue: default(string));

    public static readonly BindableProperty CarboidratoProperty =
        BindableProperty.Create(
            propertyName: nameof(Carboidrato),
            returnType: typeof(string),
            declaringType: typeof(ReferenceValueView),
            defaultValue: default(string));

    public static readonly BindableProperty LipidioProperty =
        BindableProperty.Create(
            propertyName: nameof(Lipidio),
            returnType: typeof(string),
            declaringType: typeof(ReferenceValueView),
            defaultValue: default(string));

    public static readonly BindableProperty ValorCaloricoProperty =
        BindableProperty.Create(
            propertyName: nameof(ValorCalorico),
            returnType: typeof(string),
            declaringType: typeof(ReferenceValueView),
            defaultValue: default(string));
    
    public ValueReferenceModel ValueReference
    {
        get => (ValueReferenceModel)GetValue(ValueReferenceProperty);
        set => SetValue(ValueReferenceProperty, value);
    }

    public int FoodPlanId
    {
        get => (int)GetValue(FoodPlanIdProperty);
        set => SetValue(FoodPlanIdProperty, value);
    }

    public string Proteina
    {
        get => (string)GetValue(ProteinaProperty);
        set => SetValue(ProteinaProperty, value);
    }

    public string Carboidrato
    {
        get => (string)GetValue(CarboidratoProperty);
        set => SetValue(CarboidratoProperty, value);
    }

    public string Lipidio
    {
        get => (string)GetValue(LipidioProperty);
        set => SetValue(LipidioProperty, value);
    }

    public string ValorCalorico
    {
        get => (string)GetValue(ValorCaloricoProperty);
        set => SetValue(ValorCaloricoProperty, value);
    }

    private bool IsBusy { get; set; }

    public ReferenceValueView()
    {
        InitializeComponent();
    }

    private async Task FetchValueReference()
    {
        if (IsBusy) return;
        IsBusy = true;
        ValueReference = await new ValueReferenceDB().ConsultarWhereAsync(FoodPlanId);
        CalculateReferenceValue();
    }

    private void CalculateReferenceValue()
    {
        if (ValueReference == null) return;
        ProteinaVrLabel.Nutrient =$"{FoodPlanCalculationService.CalculateReferenceValue(ValueReference.Energia.ToString(), ValueReference.Proteinas, MacroNutrients.PROTEIN).ToString()} {NutrientsBuild.AddUnitMeasure(NutrientsTypes.PROTEINA)}";
        ProteinaVrLabel.Percentage = $"({ValueReference.Proteinas})%";
        LipídioVrLabel.Nutrient =$"{FoodPlanCalculationService.CalculateReferenceValue(ValueReference.Energia.ToString(), ValueReference.Lipidios, MacroNutrients.LIPIDS).ToString()} {NutrientsBuild.AddUnitMeasure(NutrientsTypes.LIPIDIO)}";
        LipídioVrLabel.Percentage = $"({ValueReference.Lipidios})%";
        CarboidratoVrLabel.Nutrient = $"{FoodPlanCalculationService.CalculateReferenceValue(ValueReference.Energia.ToString(), ValueReference.Carboidratos, MacroNutrients.CARBOHYDRATES).ToString()} {NutrientsBuild.AddUnitMeasure(NutrientsTypes.CARBOIDRATO)}";
        CarboidratoVrLabel.Percentage = $"({ValueReference.Carboidratos})%";
        VlCaloricoVrLabel.Nutrient =$"{ValueReference.Energia} {NutrientsBuild.AddUnitMeasure(NutrientsTypes.VALOR_CALORICO)}";
    }

    protected override void OnPropertyChanged(string propertyName)
    {
        base.OnPropertyChanged(propertyName);

        if (propertyName == ProteinaProperty.PropertyName)
        {
            ProteinaLabel.Nutrient =
                $"{CommonCalculations.RoundNutrient(Proteina)} {NutrientsBuild.AddUnitMeasure(NutrientsTypes.PROTEINA)}";
        }

        if (propertyName == CarboidratoProperty.PropertyName)
        {
            CarboidratoLabel.Nutrient =
                $"{CommonCalculations.RoundNutrient(Carboidrato)} {NutrientsBuild.AddUnitMeasure(NutrientsTypes.CARBOIDRATO)}";
        }

        if (propertyName == LipidioProperty.PropertyName)
        {
            LipidioLabel.Nutrient =
                $"{CommonCalculations.RoundNutrient(Lipidio)} {NutrientsBuild.AddUnitMeasure(NutrientsTypes.LIPIDIO)}";
        }

        if (propertyName == ValorCaloricoProperty.PropertyName)
        {
            ValorCaloricaLabel.Nutrient =
                $"{CommonCalculations.RoundNutrient(ValorCalorico)} {NutrientsBuild.AddUnitMeasure(NutrientsTypes.VALOR_CALORICO)}";
        }

        if (FoodPlanId != 0)
        {
            FetchValueReference();
        }
    }
}