using System.Windows.Input;

namespace NutriApp.Components.Button;

public partial class ButtonView : ContentView
{
    public static readonly BindableProperty TextProperty = BindableProperty.Create(
        propertyName: nameof(Text),
        returnType: typeof(string),
        declaringType: typeof(ButtonView),
        defaultValue: null
    );

    public new static readonly BindableProperty BackgroundColorProperty =
        BindableProperty.Create(
            propertyName: nameof(BackgroundColor),
            returnType: typeof(Color),
            declaringType: typeof(ButtonView),
            defaultValue: Color.FromArgb(System.Drawing.Color.White.ToString())
            );

    public static readonly BindableProperty TextColorProperty =
        BindableProperty.Create(
            propertyName: nameof(TextColor),
            returnType: typeof(Color),
            declaringType: typeof(ButtonView),
            defaultValue: Color.FromArgb(System.Drawing.Color.White.ToString())
            );

    public static readonly BindableProperty CommandProperty =
        BindableProperty.Create(nameof(Command), typeof(ICommand), typeof(ButtonView), null);

    public ICommand Command
    {
        get => (ICommand)GetValue(CommandProperty);
        set => SetValue(CommandProperty, value);
    }

    public new Color BackgroundColor
    {
        get => (Color)GetValue(BackgroundColorProperty);
        set => SetValue(BackgroundColorProperty, value);
    }

    public Color TextColor
    {
        get => (Color)GetValue(TextColorProperty);
        set => SetValue(TextColorProperty, value);
    }

    public string Text
    {
        get => (string)GetValue(TextProperty);
        set => SetValue(TextProperty, value);
    }

    public ButtonView()
    {
        InitializeComponent();
    }

    private void TapGestureRecognizer_Command(object sender, EventArgs e)
    {
        if (Command == null) return;
        if (Command.CanExecute(null))
        {
            Command.Execute(null);
        }
    }
}