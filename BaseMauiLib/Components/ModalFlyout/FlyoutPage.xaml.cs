using System.Runtime.CompilerServices;
using System.Windows.Input;
using MauiLib1.Navigation;

namespace MauiLib1.Components.ModalFlyout;

public partial class FlyoutPage : ContentPage
{
    private Page _page;
    private Color _pageBackgroundColor;
    
    public static readonly BindableProperty CommandProperty =
        BindableProperty.Create(
            propertyName: nameof(Command),
            returnType: typeof(ICommand),
            declaringType: typeof(FlyoutPage),
            defaultValue: null);

    public new static readonly BindableProperty TitleProperty =
        BindableProperty.Create(
            propertyName: nameof(Title),
            returnType: typeof(string),
            declaringType: typeof(FlyoutPage),
            defaultValue: "");
    
    public static readonly BindableProperty TextSearchProperty =
        BindableProperty.Create(
            propertyName: nameof(TextSearch),
            returnType: typeof(string),
            defaultValue: default(string),
            defaultBindingMode: BindingMode.TwoWay,
            declaringType: typeof(FlyoutPage));
    
    public static readonly BindableProperty IsSearchProperty =
        BindableProperty.Create(
            propertyName: nameof(IsSearch),
            returnType: typeof(bool),
            defaultValue: false,
            declaringType: typeof(FlyoutPage));

    public ICommand Command
    {
        get => (ICommand)GetValue(CommandProperty);
        set => SetValue(CommandProperty, value);
    }

    public new string Title
    {
        get => (string)GetValue(TitleProperty);
        set => SetValue(TitleProperty, value);
    }
    
    public string TextSearch
    {
        get => (string) GetValue(TextSearchProperty);
        set => SetValue(TextSearchProperty, value);
    }
    
    public bool IsSearch
    {
        get => (bool) GetValue(IsSearchProperty);
        set => SetValue(IsSearchProperty, value);
    }

    public FlyoutPage()
    {
        InitializeComponent();
        _page = Shell.Current.CurrentPage;
    }
    
    protected override void OnAppearing()
    {
        base.OnAppearing();
        if (_page is not null)
        {
            _pageBackgroundColor = _page.BackgroundColor;
            // if (_page is FlyoutPage)
            // {
            //     _page.Opacity = 0.4;
            // }
            // else
            // {
            //     _page.BackgroundColor = Color.FromArgb("#000000");
            //     _page.Opacity = 0.4;
            // }
        }
    }
    
    protected override void OnDisappearing()
    {
        base.OnDisappearing();
       
    }

    private void OnCloseModal(object? sender, TappedEventArgs e)
    {
        new NavigationService().GoBackAsync();
    }

    private void OnBorderTapped(object? sender, TappedEventArgs e)
    {
    }
}