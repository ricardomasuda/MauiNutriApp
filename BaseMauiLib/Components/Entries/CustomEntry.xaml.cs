namespace MauiLib1.Components.Entries;

public partial class CustomEntry
{
    private const int DefaultCornerRadius = 5;

    public static readonly BindableProperty CornerRadiusProperty =
        BindableProperty.Create(
            nameof(CornerRadius),
            typeof(int),
            typeof(CustomEntry),
            DefaultCornerRadius);

    public static readonly BindableProperty TextProperty =
        BindableProperty.Create(
            nameof(Text), 
            typeof(string), 
            typeof(CustomEntry));
    
    public static readonly BindableProperty HintProperty =
        BindableProperty.Create(
            nameof(Hint), 
            typeof(string), 
            typeof(CustomEntry));
    
    public static readonly BindableProperty BorderColorProperty =
        BindableProperty.Create(
            nameof(BorderColor), 
            typeof(Brush), 
            typeof(CustomEntry));
    
    public static readonly BindableProperty IsRequiredProperty =
        BindableProperty.Create(
            nameof(IsRequired),
            typeof(bool), 
            typeof(CustomEntry),
            false);

    public static readonly BindableProperty KeyboardTypeProperty =
        BindableProperty.Create(
            nameof(KeyboardType),
            typeof(Keyboard),
            typeof(CustomEntry)
        );
    
    public static readonly BindableProperty HasErrorProperty =
        BindableProperty.Create(
            nameof(HasError),
            typeof(bool),
            typeof(CustomEntry),
            false);

    public static readonly BindableProperty ErrorTextProperty =
        BindableProperty.Create(
            nameof(ErrorText),
            typeof(string),
            typeof(CustomEntry),
            string.Empty);
    
    public int CornerRadius
    {
        get => (int)GetValue(CornerRadiusProperty);
        set => SetValue(CornerRadiusProperty, value);
    }

    public string Text
    {
        get => (string)GetValue(TextProperty);
        set => SetValue(TextProperty, value);
    }
    
    public string Hint
    {
        get => (string)GetValue(HintProperty);
        set => SetValue(HintProperty, value);
    }
    
    public Brush BorderColor
    {
        get => (Brush)GetValue(BorderColorProperty);
        set => SetValue(BorderColorProperty, value);
    }

    public bool IsRequired
    {
        get => (bool)GetValue(IsRequiredProperty);
        set => SetValue(IsRequiredProperty, value);
    }

    public Keyboard KeyboardType
    {
        get => (Keyboard)GetValue(KeyboardTypeProperty);
        set => SetValue(KeyboardTypeProperty, value);
    }
    
    public bool HasError
    {
        get => (bool)GetValue(HasErrorProperty);
        set => SetValue(HasErrorProperty, value);
    }

    public string ErrorText
    {
        get => (string)GetValue(ErrorTextProperty);
        set => SetValue(ErrorTextProperty, value);
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
                    new Span { Text = HintLabel.Text },
                    new Span { Text = "*", TextColor = Colors.Red }
                }
            };
        }
        else
        {
            Text = HintLabel.Text;
        }
    }
    
    private void OnEntryFocused(object sender, FocusEventArgs e)
    {
        BorderContainer.StrokeThickness = 2; // Aumenta a espessura da borda
    }

    private void OnEntryUnfocused(object sender, FocusEventArgs e)
    {
        BorderContainer.StrokeThickness = 1; // Retorna à espessura original da borda
    }

    protected override void OnPropertyChanged(string? propertyName = null)
    {
        if (propertyName is nameof(IsRequired)) OnIsRequired();

        base.OnPropertyChanged(propertyName);
    }
}