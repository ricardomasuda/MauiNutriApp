namespace MauiLib1.Components.Entries;

public partial class CustomEntry
{
    private const int DefaultCornerRadius = 5;
    
    public static readonly BindableProperty CornerRadiusProperty = BindableProperty.Create(nameof(CornerRadius), typeof(int), typeof(CustomEntry), DefaultCornerRadius);
    public int CornerRadius
    {
        get => (int)GetValue(CornerRadiusProperty);
        set => SetValue(CornerRadiusProperty, value);
    }

    public static readonly BindableProperty TextProperty = BindableProperty.Create(nameof(Text), typeof(string), typeof(CustomEntry));
    public string Text
    {
        get => (string)GetValue(TextProperty);
        set => SetValue(TextProperty, value);
    }

    public static readonly BindableProperty HintProperty = BindableProperty.Create(nameof(Hint), typeof(string), typeof(CustomEntry));
    public string Hint
    {
        get => (string)GetValue(HintProperty);
        set => SetValue(HintProperty, value);
    }

    public static readonly BindableProperty BorderColorProperty = BindableProperty.Create(nameof(BorderColor), typeof(Brush), typeof(CustomEntry));
    public Brush BorderColor
    {
        get => (Brush)GetValue(BorderColorProperty);
        set => SetValue(BorderColorProperty, value);
    }

    public static readonly BindableProperty IsRequiredProperty = BindableProperty.Create(nameof(IsRequired), typeof(bool), typeof(CustomEntry), false);
    public bool IsRequired
    {
        get => (bool)GetValue(IsRequiredProperty);
        set => SetValue(IsRequiredProperty, value);
    }

    public CustomEntry()
    {
        InitializeComponent();
    }

    private void OnIsRequired()
    {
        if (IsRequired)
        {
            HintLabel.FormattedText = new FormattedString
            {
                Spans =
                {
                    new Span {Text = HintLabel.Text},
                    new Span {Text = "*", TextColor = Colors.Red}
                }
            };
        }
        else
        {
            Text = HintLabel.Text;
        }
    }

    protected override void OnPropertyChanged(string? propertyName = null)
    {
        if (propertyName is nameof(IsRequired)) OnIsRequired();

        base.OnPropertyChanged(propertyName);
    }
}