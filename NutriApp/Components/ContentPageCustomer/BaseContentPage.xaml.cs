using System.Windows.Input;
using NutriApp.Models;

namespace NutriApp.Components.ContentPageCustomer;

public partial class BaseContentPage : ContentPage
{
    public static readonly BindableProperty VisibleBackProperty =
        BindableProperty.Create(
            propertyName: nameof(VisibleBack),
            returnType: typeof(bool),
            declaringType: typeof(BaseContentPage),
            defaultValue: true);

    public static readonly BindableProperty TextTitleProperty =
        BindableProperty.Create(
            propertyName: nameof(TextTitle),
            returnType: typeof(string),
            defaultValue: default(string),
            declaringType: typeof(BaseContentPage));

    public static readonly BindableProperty CommandProperty =
        BindableProperty.Create(
            propertyName: nameof(Command),
            returnType: typeof(ICommand),
            declaringType: typeof(BaseContentPage),
            defaultValue: null);

    public static readonly BindableProperty TypeTitleProperty =
        BindableProperty.Create(
            propertyName: nameof(TypeTitle),
            returnType: typeof(TypeTitleEnum),
            declaringType: typeof(BaseContentPage),
            defaultValue: TypeTitleEnum.None);
    
    public static readonly BindableProperty CommandParameterProperty =
        BindableProperty.Create(
            nameof(CommandParameter),
            typeof(object),
            typeof(BaseContentPage),
            defaultValue: null);

    public ICommand Command
    {
        get => (ICommand)GetValue(CommandProperty);
        set => SetValue(CommandProperty, value);
    }

    public string TextTitle
    {
        get => (string)GetValue(TextTitleProperty);
        set => SetValue(TextTitleProperty, value);
    }

    public bool VisibleBack
    {
        get => (bool)GetValue(VisibleBackProperty);
        set => SetValue(VisibleBackProperty, value);
    }

    public TypeTitleEnum TypeTitle
    {
        get => (TypeTitleEnum)GetValue(TypeTitleProperty);
        set => SetValue(TypeTitleProperty, value);
    }
    
    public object CommandParameter
    {
        get => GetValue(CommandParameterProperty);
        set => SetValue(CommandParameterProperty, value);
    }

    public BaseContentPage()
    {
        InitializeComponent();
    }
    
    protected override void OnPropertyChanged(string propertyName)
    {
        if (propertyName == null) throw new ArgumentNullException(nameof(propertyName));
            
        base.OnPropertyChanged(propertyName);

        if (propertyName == TypeTitleProperty.PropertyName)
        {
            var teste = TypeTitle;
            //PageBase.ViewTeste.TypeTitle = TypeTitleEnum.InfoCircle;
            //ViewTeste.TypeTitle = TypeTitle;
        }
            
    }
}