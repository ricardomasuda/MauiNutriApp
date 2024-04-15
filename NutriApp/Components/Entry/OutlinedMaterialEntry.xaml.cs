using System.Windows.Input;

namespace NutriApp.Components.Entry;

public partial class OutlinedMaterialEntry {
    public static readonly BindableProperty TextColorProperty = BindableProperty.Create(nameof(TextColor),
        typeof(Color), typeof(OutlinedMaterialEntry), Colors.White, propertyChanged: (bindable, _, newValue) => {
            OutlinedMaterialEntry view = (OutlinedMaterialEntry)bindable;
            view.CustomEntry.TextColor = (Color)newValue;
        });

    public static readonly BindableProperty PlaceholderColorProperty = BindableProperty.Create(nameof(PlaceholderColor),
        typeof(Color), typeof(OutlinedMaterialEntry), Colors.White, propertyChanged: (bindable, _, newValue) => {
            OutlinedMaterialEntry view = (OutlinedMaterialEntry)bindable;
            view.PlaceholderText.TextColor = (Color)newValue;
        });

    public static readonly BindableProperty CounterTextColorProperty = BindableProperty.Create(nameof(CounterTextColor),
        typeof(Color), typeof(OutlinedMaterialEntry), Colors.Gray, propertyChanged: (bindable, _, newValue) => {
            OutlinedMaterialEntry view = (OutlinedMaterialEntry)bindable;
            view.CharCounterText.TextColor = (Color)newValue;
        });

    public static readonly BindableProperty PlaceholderBackgroundColorProperty = BindableProperty.Create(
        nameof(PlaceholderBackgroundColor), typeof(Color), typeof(OutlinedMaterialEntry), Colors.White,
        propertyChanged: (bindable, _, newValue) => {
            OutlinedMaterialEntry view = (OutlinedMaterialEntry)bindable;
            view.PlaceholderContainer.BackgroundColor = (Color)newValue;
        });

    public static readonly BindableProperty TextProperty = BindableProperty.Create(nameof(Text), typeof(string),
        typeof(OutlinedMaterialEntry), default(string), BindingMode.TwoWay, null, (bindable, _, newValue) => {
            OutlinedMaterialEntry view = (OutlinedMaterialEntry)bindable;
            view.CustomEntry.Text = (string)newValue;
        });

    public static readonly BindableProperty PlaceholderProperty = BindableProperty.Create(nameof(Placeholder),
        typeof(string), typeof(OutlinedMaterialEntry), default(string), BindingMode.OneWay, null,
        (bindable, _, newValue) => {
            OutlinedMaterialEntry view = (OutlinedMaterialEntry)bindable;
            view.PlaceholderText.Text = (string)newValue;
        });

    public static readonly BindableProperty IsPasswordProperty = BindableProperty.Create(nameof(IsPassword),
        typeof(bool), typeof(OutlinedMaterialEntry), default(bool), BindingMode.OneWay, null,
        (bindable, _, newValue) => {
            OutlinedMaterialEntry view = (OutlinedMaterialEntry)bindable;
            view.CustomEntry.IsPassword = (bool)newValue;
            view.PasswordIcon.IsVisible = (bool)newValue;
        });

    public static readonly BindableProperty MaxLengthProperty = BindableProperty.Create(nameof(MaxLength), typeof(int),
        typeof(OutlinedMaterialEntry), default(int), BindingMode.OneWay, null, (bindable, _, newValue) => {
            OutlinedMaterialEntry view = (OutlinedMaterialEntry)bindable;
            view.CustomEntry.MaxLength = (int)newValue;
            view.CharCounterText.IsVisible = view.CustomEntry.MaxLength > 0;
            view.CharCounterText.Text = $"0 / {view.MaxLength}";
        });

    public static readonly BindableProperty FocusedStrokeProperty = BindableProperty.Create(nameof(FocusedStroke),
        typeof(Color), typeof(OutlinedMaterialEntry), Colors.Blue, BindingMode.OneWay);

    public static readonly BindableProperty UnfocusedStrokeProperty = BindableProperty.Create(nameof(UnfocusedStroke),
        typeof(Color), typeof(OutlinedMaterialEntry), Colors.Gray, propertyChanged: (bindable, _, newValue) => {
            OutlinedMaterialEntry view = (OutlinedMaterialEntry)bindable;
            view.ContainerBorder.Stroke = (Color)newValue;
        });

    public static readonly BindableProperty BorderStrokeShapeProperty = BindableProperty.Create(
        nameof(BorderStrokeShape), typeof(IShape), typeof(OutlinedMaterialEntry), null,
        propertyChanged: (bindable, _, newValue) => {
            OutlinedMaterialEntry view = (OutlinedMaterialEntry)bindable;
            view.ContainerBorder.StrokeShape = (IShape?)newValue;
        });

    public static readonly BindableProperty ReturnCommandProperty = BindableProperty.Create(nameof(ReturnCommand),
        typeof(ICommand), typeof(OutlinedMaterialEntry), default(ICommand), BindingMode.OneWay, null,
        (bindable, _, newValue) => {
            OutlinedMaterialEntry view = (OutlinedMaterialEntry)bindable;
            view.CustomEntry.ReturnCommand = (ICommand)newValue;
        });

    public event EventHandler<EventArgs>? EntryCompleted;
    public event EventHandler<TextChangedEventArgs>? TextChanged;

    public Color TextColor {
        get => (Color)GetValue(TextColorProperty);
        init => SetValue(TextColorProperty, value);
    }

    public Color PlaceholderColor {
        get => (Color)GetValue(PlaceholderColorProperty);
        init => SetValue(PlaceholderColorProperty, value);
    }

    public Color CounterTextColor {
        get => (Color)GetValue(CounterTextColorProperty);
        init => SetValue(CounterTextColorProperty, value);
    }

    public Color PlaceholderBackgroundColor {
        get => (Color)GetValue(PlaceholderBackgroundColorProperty);
        init => SetValue(PlaceholderBackgroundColorProperty, value);
    }

    public string Text {
        get => (string)GetValue(TextProperty);
        set => SetValue(TextProperty, value);
    }

    public string Placeholder {
        get => (string)GetValue(PlaceholderProperty);
        init => SetValue(PlaceholderProperty, value);
    }

    public bool IsPassword {
        get => (bool)GetValue(IsPasswordProperty);
        init => SetValue(IsPasswordProperty, value);
    }

    public int MaxLength {
        get => (int)GetValue(MaxLengthProperty);
        init => SetValue(MaxLengthProperty, value);
    }

    public Color FocusedStroke {
        get => (Color)GetValue(FocusedStrokeProperty);
        init => SetValue(FocusedStrokeProperty, value);
    }

    public Color UnfocusedStroke {
        get => (Color)GetValue(UnfocusedStrokeProperty);
        init => SetValue(UnfocusedStrokeProperty, value);
    }

    public IShape? BorderStrokeShape {
        get => (IShape?)GetValue(BorderStrokeShapeProperty);
        init => SetValue(BorderStrokeShapeProperty, value);
    }

    public Keyboard Keyboard {
        init => CustomEntry.Keyboard = value;
    }

    public ReturnType ReturnType {
        init => CustomEntry.ReturnType = value;
    }

    public ICommand ReturnCommand {
        get => (ICommand)GetValue(ReturnCommandProperty);
        init => SetValue(ReturnCommandProperty, value);
    }

    public ICommand ClearCommand { get; }

    public OutlinedMaterialEntry() {
        InitializeComponent();

        ClearCommand = new Command(() => CustomEntry.Text = string.Empty);

        CustomEntry.Text = Text;
        CustomEntry.TextChanged += OnCustomEntryTextChanged;
        CustomEntry.Completed += OnCustomEntryCompleted;
    }

    private async Task ControlFocused() {
        if (string.IsNullOrEmpty(CustomEntry.Text) || CustomEntry.Text.Length > 0) {
            CustomEntry.Focus();

            double y = -(CustomEntry.Height / 2);

            await PlaceholderContainer.TranslateTo(0, y, 120, Easing.CubicOut);

            PlaceholderContainer.HorizontalOptions = LayoutOptions.Start;
            PlaceholderText.FontSize = 12;
        } else
            await ControlUnfocused();
    }

    private async Task ControlUnfocused() {
        CustomEntry.Unfocus();

        if (string.IsNullOrEmpty(CustomEntry.Text) || CustomEntry.MaxLength <= 0) {
            await PlaceholderContainer.TranslateTo(0, 0, 100, Easing.CubicOut);

            PlaceholderContainer.HorizontalOptions = LayoutOptions.Start;
            PlaceholderText.FontSize = 12;
        }
    }

    private void CustomEntryFocused(object? sender, FocusEventArgs e) {
        if (e.IsFocused) MainThread.InvokeOnMainThreadAsync(async () => await ControlFocused());
    }

    private void CustomEntryUnfocused(object? sender, FocusEventArgs e) {
        if (!e.IsFocused) MainThread.InvokeOnMainThreadAsync(async () => await ControlUnfocused());
    }

    private void OutlinedMaterialEntryTapped(object? sender, EventArgs e) =>
        MainThread.InvokeOnMainThreadAsync(async () => await ControlFocused());

    private void PasswordEyeTapped(object? sender, EventArgs e) => CustomEntry.IsPassword = !CustomEntry.IsPassword;

    private void OnCustomEntryTextChanged(object? sender, TextChangedEventArgs e) {
        Text = e.NewTextValue;

        if (CharCounterText.IsVisible) CharCounterText.Text = $"{CustomEntry.Text.Length} / {MaxLength}";

        TextChanged?.Invoke(this, e);
    }

    private void OnCustomEntryCompleted(object? sender, EventArgs e) => EntryCompleted?.Invoke(this, EventArgs.Empty);
}