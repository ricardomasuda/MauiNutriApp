namespace NutriApp.Components.Table;

public partial class NewReportTableView : ContentView
{
    public static readonly BindableProperty NutrientsModelProperty =
        BindableProperty.Create(
            propertyName: nameof(NutrientsModel),
            returnType: typeof(NutrientsModel),
            declaringType: typeof(NewReportTableView),
            defaultValue: null);

    public NutrientsModel NutrientsModel
    {
        get => (NutrientsModel)GetValue(NutrientsModelProperty);
        set => SetValue(NutrientsModelProperty, value);
    }

    public NewReportTableView()
    {
        InitializeComponent();
    }

    protected override void OnPropertyChanged(string propertyName)
    {
        base.OnPropertyChanged(propertyName);

        if (propertyName == NutrientsModelProperty.PropertyName)
        {
            ProteinaLabel.Nutrient = ValidateNutrient(NutrientsModel.Proteina, NutrientsTypes.PROTEINA);
            CarboidratoLabel.Nutrient = ValidateNutrient(NutrientsModel.Carboidratos, NutrientsTypes.CARBOIDRATO);
            LipidioLabel.Nutrient = ValidateNutrient(NutrientsModel.Lipidio, NutrientsTypes.LIPIDIO);
            ValorCaloricoLabel.Nutrient = ValidateNutrient(NutrientsModel.ValorCalorico, NutrientsTypes.VALOR_CALORICO);
            MedidaLabel.Nutrient = ValidateNutrient(NutrientsModel.Medida, NutrientsTypes.MEDIDA);
            SodioLabel.Nutrient = ValidateNutrient(NutrientsModel.Sodio, NutrientsTypes.SODIO);
            FibraAlimentarLabel.Nutrient =
                ValidateNutrient(NutrientsModel.FibraAlimentar, NutrientsTypes.FIBRA_ALIMENTAR);
            CalcioLabel.Nutrient = ValidateNutrient(NutrientsModel.Calcio, NutrientsTypes.CALCIO);
            MagnesioLabel.Nutrient = ValidateNutrient(NutrientsModel.Magnesio, NutrientsTypes.MAGNESIO);
            ManganesLabel.Nutrient = ValidateNutrient(NutrientsModel.Manganes, NutrientsTypes.MANGANES);
            FosforoLabel.Nutrient = ValidateNutrient(NutrientsModel.Fosforo, NutrientsTypes.FOSFORO);
            FerroLabel.Nutrient = ValidateNutrient(NutrientsModel.Ferro, NutrientsTypes.FERRO);
            PotassioLabel.Nutrient = ValidateNutrient(NutrientsModel.Potassio, NutrientsTypes.POTASSIO);
            CobreLabel.Nutrient = ValidateNutrient(NutrientsModel.Cobre, NutrientsTypes.COBRE);
            ZincoLabel.Nutrient = ValidateNutrient(NutrientsModel.Zinco, NutrientsTypes.ZINCO);
            VitaminaALabel.Nutrient = ValidateNutrient(NutrientsModel.VitaminaA, NutrientsTypes.VITAMINA_A);
            VitaminaB1Label.Nutrient = ValidateNutrient(NutrientsModel.VitaminaB1, NutrientsTypes.VITAMINA_B1);
            VitaminaB2Label.Nutrient = ValidateNutrient(NutrientsModel.VitaminaB2, NutrientsTypes.VITAMINA_B2);
            VitaminaB6Label.Nutrient = ValidateNutrient(NutrientsModel.VitaminaB6, NutrientsTypes.VITAMINA_B6);
            VitaminaB3Label.Nutrient = ValidateNutrient(NutrientsModel.VitaminaB3, NutrientsTypes.VITAMINA_B3);
            VitaminaCLabel.Nutrient = ValidateNutrient(NutrientsModel.VitaminaC, NutrientsTypes.VITAMINA_C);
        }
    }

    private string ValidateNutrient(string nutrient, NutrientsTypes nutrientsTypes)
    {
        if (nutrient != null)
        {
            return $"{CommonCalculations.RoundNutrient(nutrient)} {NutrientsBuild.AddUnitMeasure(nutrientsTypes)}";
        }

        return null;
    }

    private void Percent()
    {
        var proteinaPorcent = FoodPlanCalculationService.CalculateFoodPlan(NutrientsModel.ValorCalorico, NutrientsModel.Proteina, MacroNutrients.PROTEIN).ToString();
        var carboidratoPorcent = FoodPlanCalculationService.CalculateFoodPlan(NutrientsModel.ValorCalorico, NutrientsModel.Carboidratos, MacroNutrients.CARBOHYDRATES).ToString();
        var lipidioPorcent = FoodPlanCalculationService.CalculateFoodPlan(NutrientsModel.ValorCalorico, NutrientsModel.Lipidio, MacroNutrients.LIPIDS).ToString();

        // ProteinaPorcentagemLabel.Text = $"({proteinaPorcent})%";
        // CarboidratoPorcentagemLabel.Text = $"({carboidratoPorcent})%";
        // LipidioPorcentagemLabel.Text = $"({lipidioPorcent})%";
    }
}