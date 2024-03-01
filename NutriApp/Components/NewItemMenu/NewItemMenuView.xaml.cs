using System.Windows.Input;

namespace NutriApp.AppNutri.Componente.NewItemMenu;

public partial class NewItemMenuView : ContentView
{
    private static readonly BindableProperty TextTitleProperty =
        BindableProperty.Create(nameof(TextTitle), typeof(string), typeof(NewItemMenuView), string.Empty);

    public static readonly BindableProperty CommandProperty =
        BindableProperty.Create(nameof(Command), typeof(ICommand), typeof(NewItemMenuView), null);
    
        
    public ICommand Command
    {
        get => (ICommand) GetValue(CommandProperty);
        set => SetValue(CommandProperty, value); 
    }

    public string TextTitle
    {
        get => (string) GetValue(TextTitleProperty);
        set => SetValue(TextTitleProperty, value);
    }
        
    public NewItemMenuView()
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
        
    private void TapGestureRecognizer_Command(object sender, EventArgs e)
    {
        if (Command == null) return;
        if (Command.CanExecute(null))
        {
            Command.Execute(null);
        }
    }
}