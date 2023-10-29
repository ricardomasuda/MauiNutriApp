using Microsoft.Maui.Controls.Shapes;
using NutriApp.AppNutri.Model;
using NutriApp.AppNutri.Utils;

namespace NutriApp.AppNutri.Componente;

public partial class ResultLineView : ContentView
{
    public static readonly BindableProperty TextTitleProperty = BindableProperty.Create(
        propertyName: nameof(TextTitle),
        returnType: typeof(string),
        declaringType: typeof(ResultLineView),
        defaultValue: null
    );

    public static readonly BindableProperty BodyTextProperty = BindableProperty.Create(
        propertyName: nameof(BodyText),
        returnType: typeof(string),
        declaringType: typeof(ResultLineView),
        defaultValue: null
    );

    public static readonly BindableProperty ResultTypeProperty = BindableProperty.Create(
        propertyName: nameof(ResultType),
        returnType: typeof(ResultType),
        declaringType: typeof(ResultLineView),
        defaultValue: ResultType.OTHER
    );

    public static readonly BindableProperty UnityMeasureTypeProperty = BindableProperty.Create(
        propertyName: nameof(UnityMeasureType),
        returnType: typeof(UnidadeMedida),
        declaringType: typeof(ResultLineView),
        defaultValue: UnidadeMedida.NONE
    );

    public ResultType ResultType
    {
        get => (ResultType)GetValue(ResultTypeProperty);
        set => SetValue(ResultTypeProperty, value);
    }

    public UnidadeMedida UnityMeasureType
    {
        get => (UnidadeMedida)GetValue(UnityMeasureTypeProperty);
        set => SetValue(UnityMeasureTypeProperty, value);
    }

    public string TextTitle
    {
        get => (string)GetValue(TextTitleProperty);
        set => SetValue(TextTitleProperty, value);
    }

    public string BodyText
    {
        get => (string)GetValue(BodyTextProperty);
        set => SetValue(BodyTextProperty, value);
    }

    public ResultLineView()
    {
        InitializeComponent();
    }

    private void SetFirstFrame()
    {
        TitleView.StrokeShape = new RoundRectangle
        {
            CornerRadius = new CornerRadius(20, 0, 0, 0)
        };
        BodyView.StrokeShape = new RoundRectangle
        {
            CornerRadius =new CornerRadius(0, 20, 0, 0)
        };
    }

    private void SetUnidadeMedida()
    {
        if (string.IsNullOrEmpty(BodyText)) return;
        BodyTextLabel.Text = UnityMeasureType switch
        {
            UnidadeMedida.KILOS => CommonCalculations.ConverterDouble(BodyText, 2) + " kg",
            UnidadeMedida.PERCENTAGE => CommonCalculations.ConverterDouble(BodyText, 2) + " %",
            UnidadeMedida.METERS => BodyText + " m",
            UnidadeMedida.GRAMS => BodyText + " g",
            _ => BodyText
        };
    }

    protected override void OnPropertyChanged(string propertyName)
    {
        base.OnPropertyChanged(propertyName);

        if (propertyName == ResultTypeProperty.PropertyName)
        {
            if (ResultType == ResultType.FIRST) SetFirstFrame();
        }

        if (propertyName == UnityMeasureTypeProperty.PropertyName || propertyName == BodyTextProperty.PropertyName)
        {
            SetUnidadeMedida();
        }
    }
}