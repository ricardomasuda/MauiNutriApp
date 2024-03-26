using NutriApp.Resources;

namespace NutriApp.Components.Icon;

public partial class IconView : ContentView
{
    public static readonly BindableProperty TextTitleProperty =
        BindableProperty.Create(
            propertyName: nameof(IconType),
            returnType: typeof(IconNameEnum),
            defaultValue: default(IconNameEnum),
            declaringType: typeof(IconView));
    
    public static readonly BindableProperty FontSizeProperty = BindableProperty.Create(
        propertyName: nameof(FontSize),
        returnType: typeof(int),
        declaringType: typeof(IconView),
        defaultValue: 27);
    
    public static readonly BindableProperty TextColorProperty = BindableProperty.Create(
        propertyName: nameof(TextColor),
        returnType: typeof(Color),
        declaringType: typeof(IconView),
        defaultValue: Colors.White); // Ajuste para a cor padrão desejada

    public Color TextColor
    {
        get => (Color)GetValue(TextColorProperty);
        set => SetValue(TextColorProperty, value);
    }

    public int FontSize
    {
        get => (int)GetValue(FontSizeProperty);
        set => SetValue(FontSizeProperty, value);
    }
    
    
    public IconNameEnum IconType
    {
        get => (IconNameEnum) GetValue(TextTitleProperty);
        set => SetValue(TextTitleProperty, value);
    }

    
    public IconView()
    {
        InitializeComponent();
    }

    protected override void OnPropertyChanged(string propertyName = null)
    {
        base.OnPropertyChanged(propertyName);
        if (propertyName == TextTitleProperty.PropertyName)
        {
            Icon.Text = ((char)IconType).ToString() ?? string.Empty;
        }
    }
}