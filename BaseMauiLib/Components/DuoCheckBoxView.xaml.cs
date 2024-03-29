namespace MauiLib1.Components;

public partial class DuoCheckBoxView : ContentView
{
    public static readonly BindableProperty CheckedItemOneProperty = BindableProperty.Create(
        nameof(CheckedItemOne),
        typeof(bool),
        typeof(DuoCheckBoxView),
        defaultValue: false,
        defaultBindingMode: BindingMode.TwoWay);

    public static readonly BindableProperty CheckedItemTwoProperty = BindableProperty.Create(
        nameof(CheckedItemTwo),
        typeof(bool),
        typeof(DuoCheckBoxView),
        defaultValue: false,
        defaultBindingMode: BindingMode.TwoWay);

    public static readonly BindableProperty TitleOneProperty = BindableProperty.Create(
        nameof(TitleOne),
        typeof(string),
        typeof(DuoCheckBoxView),
        defaultValue: string.Empty,
        defaultBindingMode: BindingMode.TwoWay);

    public static readonly BindableProperty TitleTwoProperty = BindableProperty.Create(
        nameof(TitleTwo),
        typeof(string),
        typeof(DuoCheckBoxView),
        defaultValue: string.Empty,
        defaultBindingMode: BindingMode.TwoWay);

    public bool CheckedItemOne
    {
        get => (bool)GetValue(CheckedItemOneProperty);
        set => SetValue(CheckedItemOneProperty, value);
    }

    public bool CheckedItemTwo
    {
        get => (bool)GetValue(CheckedItemTwoProperty);
        set => SetValue(CheckedItemTwoProperty, value);
    }

    public string TitleOne
    {
        get => (string)GetValue(TitleOneProperty);
        set => SetValue(TitleOneProperty, value);
    }

    public string TitleTwo
    {
        get => (string)GetValue(TitleTwoProperty);
        set => SetValue(TitleTwoProperty, value);
    }
    public DuoCheckBoxView()
    {
        InitializeComponent();
    }

    private void TapItemOneTapped(object? sender, TappedEventArgs e)
    {
        CheckedItemOne = true;
    }
    
    private void TapItemTwoTapped(object? sender, TappedEventArgs e)
    {
        CheckedItemTwo = true;
    }

    private void CheckBoxItemOneOnCheckedChanged(object? sender, CheckedChangedEventArgs e)
    {
        if (CheckedItemOne) CheckedItemTwo = false;
    }
    
    private void CheckBoxItemTwoOnCheckedChanged(object? sender, CheckedChangedEventArgs e)
    {
        if (CheckedItemTwo) CheckedItemOne = false;
    }
}