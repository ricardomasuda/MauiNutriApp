namespace NutriApp.Components.Titles.Frame;

public partial class TitleFrameView : ContentView
{
    private static readonly BindableProperty TextTitleProperty =
        BindableProperty.Create(nameof(TextTitle), typeof(string), typeof(TitleFrameView), string.Empty);

    public string TextTitle
    {
        get => (string) GetValue(TextTitleProperty);
        set => SetValue(TextTitleProperty, value);
    }
        
    public TitleFrameView()
    {
        InitializeComponent();
    }
        
    protected override void OnPropertyChanged(string propertyName)
    {
        if (propertyName == null) throw new ArgumentNullException(nameof(propertyName));
            
        base.OnPropertyChanged(propertyName);

        if (propertyName == TextTitleProperty.PropertyName)
        {
            TitleLabel.Text = TextTitle;
        }
            
    }
}