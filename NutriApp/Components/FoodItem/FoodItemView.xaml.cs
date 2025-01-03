namespace NutriApp.Components.FoodItem;

public partial class FoodItemView : ContentView
{
    public static readonly BindableProperty NomeProperty =
        BindableProperty.Create(nameof(Nome), typeof(string), typeof(FoodItemView), default(string));
    
    public static readonly BindableProperty ProteinasProperty =
        BindableProperty.Create(nameof(Proteinas), typeof(string), typeof(FoodItemView), default(string));
    
    public static readonly BindableProperty LipidiosProperty =
        BindableProperty.Create(nameof(Lipidios), typeof(string), typeof(FoodItemView), default(string));
    
    public static readonly BindableProperty CarboidratosProperty =
        BindableProperty.Create(nameof(Carboidratos), typeof(string), typeof(FoodItemView), default(string));
    
    public static readonly BindableProperty CommandProperty =
        BindableProperty.Create(nameof(Command), typeof(Command), typeof(FoodItemView));
    
    public string Nome
    {
        get => (string)GetValue(NomeProperty);
        set => SetValue(NomeProperty, value);
    }
    public string Proteinas
    {
        get => (string)GetValue(ProteinasProperty);
        set => SetValue(ProteinasProperty, value);
    }
    
    public string Lipidios
    {
        get => (string)GetValue(LipidiosProperty);
        set => SetValue(LipidiosProperty, value);
    }
    
    public string Carboidratos
    {
        get => (string)GetValue(CarboidratosProperty);
        set => SetValue(CarboidratosProperty, value);
    }
    
    public Command Command
    {
        get => (Command)GetValue(CommandProperty);
        set => SetValue(CommandProperty, value);
    }

    public FoodItemView()
    {
        InitializeComponent();
    }
    
    private void TapGestureRecognizer_Command(object sender, EventArgs e)
    {
        if (Command == null) return;
            
        //if(CommandParameter)
        if (Command.CanExecute(sender))
        {
            Command.Execute(sender);
        }
    }

    protected override void OnPropertyChanged(string propertyName)
    {
        if (propertyName == null) throw new ArgumentNullException(nameof(propertyName));

        base.OnPropertyChanged(propertyName);

        if (propertyName == ProteinasProperty.PropertyName)
        {
            ProteinasLabel.Text = Proteinas;
        }
        
        if (propertyName == CarboidratosProperty.PropertyName)
        {
            CarboidratosLabel.Text = Carboidratos;
        }
        
        if (propertyName == LipidiosProperty.PropertyName)
        {
            LipidiosLabel.Text = Lipidios;
        }
        
        if (propertyName == NomeProperty.PropertyName)
        {
            NomeLabel.Text = Nome;
        }
        
    }
}