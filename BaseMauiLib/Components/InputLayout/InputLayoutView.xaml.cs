namespace MauiLib1.Components.InputLayout;

public partial class InputLayoutView : ContentView
{
    private const int DefaultCornerRadius = 5;
    
    public static readonly BindableProperty CornerRadiusProperty =
        BindableProperty.Create(
            nameof(CornerRadius),
            typeof(int),
            typeof(InputLayoutView),
            DefaultCornerRadius);
    
    public static readonly BindableProperty BorderColorProperty =
        BindableProperty.Create(
            nameof(BorderColor), 
            typeof(Brush), 
            typeof(InputLayoutView));
    
    public static readonly BindableProperty HintProperty =
        BindableProperty.Create(
            nameof(Hint), 
            typeof(string), 
            typeof(InputLayoutView));
    
    public static readonly BindableProperty IsRequiredProperty =
        BindableProperty.Create(
            nameof(IsRequired),
            typeof(bool), 
            typeof(InputLayoutView),
            false);
    
    public static readonly BindableProperty HasErrorProperty =
        BindableProperty.Create(
            nameof(HasError),
            typeof(bool),
            typeof(InputLayoutView),
            false);

    public static readonly BindableProperty ErrorTextProperty =
        BindableProperty.Create(
            nameof(ErrorText),
            typeof(string),
            typeof(InputLayoutView),
            string.Empty);
    
    public static readonly BindableProperty IsEnabledProperty =
        BindableProperty.Create(
            nameof(IsEnabled),
            typeof(bool),
            typeof(InputLayoutView),
            true,
            propertyChanged: OnIsEnabledChanged);
    
    public static readonly BindableProperty HeightRequestProperty =
        BindableProperty.Create(
            nameof(HeightRequest),
            typeof(int),
            typeof(InputLayoutView),
            50);
    
    public int CornerRadius
    {
        get => (int)GetValue(CornerRadiusProperty);
        set => SetValue(CornerRadiusProperty, value);
    }
    
    public int HeightRequest
    {
        get => (int)GetValue(HeightRequestProperty);
        set => SetValue(HeightRequestProperty, value);
    }
    
    public Brush BorderColor
    {
        get => (Brush)GetValue(BorderColorProperty);
        set => SetValue(BorderColorProperty, value);
    }
    
    public string Hint
    {
        get => (string)GetValue(HintProperty);
        set => SetValue(HintProperty, value);
    }
    
    public bool IsRequired
    {
        get => (bool)GetValue(IsRequiredProperty);
        set => SetValue(IsRequiredProperty, value);
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

    public new bool IsEnabled
    {
        get => (bool)GetValue(IsEnabledProperty);
        set => SetValue(IsEnabledProperty, value);
    }
    
    public InputLayoutView()
    {
        InitializeComponent();
    }
    
    private void OnIsRequired()
    {
        var hintLabel = this.FindByName<Label>("HintLabel");
        if (IsRequired && hintLabel != null)
        {
            hintLabel.FormattedText = new FormattedString
            {
                Spans =
                {
                    new Span { Text = hintLabel.Text },
                    new Span { Text = "*", TextColor = Colors.Red }
                }
            };
        }
    }
    
    private static void OnIsEnabledChanged(BindableObject bindable, object oldValue, object newValue)
    {
        if (bindable is InputLayoutView inputLayoutView)
        {
            inputLayoutView.UpdateIsEnabled();
        }
    }
    
    private void UpdateIsEnabled()
    {
        var contentPresenter = this.FindByName<ContentPresenter>("ContentPresenter");
        if (IsEnabled)
        {
            BorderColor = new SolidColorBrush(Colors.Gray);
            if (contentPresenter != null)
            {
                contentPresenter.IsEnabled = false;
            }
        }
        else
        {
            BorderColor = new SolidColorBrush(Colors.Black);
            if (contentPresenter != null)
            {
                contentPresenter.IsEnabled = true;
            }
        }
    }
    
    protected override void OnPropertyChanged(string? propertyName = null)
    {
        if (propertyName is nameof(IsRequired)) OnIsRequired();
    
        base.OnPropertyChanged(propertyName);
    }
}