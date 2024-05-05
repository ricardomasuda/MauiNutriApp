namespace NutriApp.Views.AnthropometricEvaluation.View.ResultView;

public partial class AnthropometricEvaluationResultView : ContentView
{
    public static readonly BindableProperty AnthropometricEvaluationResultModelProperty =
        BindableProperty.Create(
            nameof(AnthropometricEvaluationResultModel),
            typeof(AnthropometricEvaluationResultModel),
            typeof(AnthropometricEvaluationResultView),
            default(AnthropometricEvaluationResultModel),
            BindingMode.TwoWay);

    public static readonly BindableProperty BoneDiameterModelProperty =
        BindableProperty.Create(
            nameof(BoneDiameterModel),
            typeof(BoneDiameterModel),
            typeof(AnthropometricEvaluationResultView),
            default(BoneDiameterModel));
    public AnthropometricEvaluationResultModel AnthropometricEvaluationResultModel
    {
        get => (AnthropometricEvaluationResultModel)GetValue(AnthropometricEvaluationResultModelProperty);
        set => SetValue(AnthropometricEvaluationResultModelProperty, value);
    }

    public BoneDiameterModel BoneDiameterModel
    {
        get => (BoneDiameterModel)GetValue(BoneDiameterModelProperty);
        set => SetValue(BoneDiameterModelProperty, value);
    }

    public AnthropometricEvaluationResultView()
    {
        InitializeComponent();
    }

    protected override void OnPropertyChanged(string propertyName)
    {
        base.OnPropertyChanged(propertyName);
    }
}