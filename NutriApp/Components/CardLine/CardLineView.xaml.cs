namespace NutriApp.Components.CardLine;

public partial class CardLineView : ContentView
{
    private static readonly BindableProperty BodyTextProperty =
        BindableProperty.Create(nameof(BodyText), typeof(string), typeof(CardLineView), string.Empty);

    public static readonly BindableProperty ValueTextProperty =
        BindableProperty.Create(nameof(ValueText), typeof(string), typeof(CardLineView), string.Empty, BindingMode.TwoWay);

    public string BodyText
    {
        get => (string) GetValue(BodyTextProperty);
        set => SetValue(BodyTextProperty, value);
    }
        
    public string ValueText
    {
        get => (string) GetValue(ValueTextProperty);
        set => SetValue(ValueTextProperty, value);
    }
        
    public CardLineView()
    {
        InitializeComponent();
    }
}