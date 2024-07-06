namespace NutriApp.Components.Table;

public partial class ReportTableLineView : ContentView
{
     public static readonly BindableProperty TitleProperty =
            BindableProperty.Create(
                propertyName: nameof(Title),
                returnType: typeof(string),
                declaringType: typeof(ReportTableLineView),
                defaultValue: default(string));
        
        public static readonly BindableProperty TextFontProperty =
            BindableProperty.Create(
                propertyName: nameof(TextFont),
                returnType: typeof(int),
                declaringType: typeof(ReportTableLineView),
                defaultValue: 15);
        
        public static readonly BindableProperty NutrientProperty =
            BindableProperty.Create(
                propertyName: nameof(Nutrient),
                returnType: typeof(string),
                declaringType: typeof(ReportTableLineView),
                defaultValue: default(string));
        
        public static readonly BindableProperty PercentageProperty =
            BindableProperty.Create(
                propertyName: nameof(Percentage),
                returnType: typeof(string),
                declaringType: typeof(ReportTableLineView),
                defaultValue: default(string));
        
        public static readonly BindableProperty ColorLineProperty =
            BindableProperty.Create(
                propertyName: nameof(ColorLine),
                returnType: typeof(Color),
                declaringType: typeof(ReportTableLineView),
                defaultValue: Color.FromArgb(System.Drawing.Color.White.ToString()));
        
        public static readonly BindableProperty TextColorProperty =
            BindableProperty.Create(
                propertyName: nameof(TextColor),
                returnType: typeof(Color),
                declaringType: typeof(ReportTableLineView),
                defaultValue: null);
        
        public string Title
        {
            get => (string)GetValue(TitleProperty);
            set => SetValue(TitleProperty, value);
        }
        
        public string Percentage
        {
            get => (string)GetValue(PercentageProperty);
            set => SetValue(PercentageProperty, value);
        }
        
        public string Nutrient
        {
            get => (string)GetValue(NutrientProperty);
            set => SetValue(NutrientProperty, value);
        }
        
        public Color ColorLine
        {
            get => (Color)GetValue(ColorLineProperty);
            set => SetValue(ColorLineProperty, value);
        }
        
        public Color TextColor
        {
            get => (Color)GetValue(TextColorProperty);
            set => SetValue(TextColorProperty, value);
        }

        public int TextFont
        {
            get => (int)GetValue(TextFontProperty);
            set => SetValue(TextFontProperty, value);
        }
        
        
        public ReportTableLineView()
        {
            InitializeComponent();
            PercentageLabel.IsVisible = false;
        }

        protected override void OnPropertyChanged(string propertyName)
        {
            base.OnPropertyChanged(propertyName);
            
            if (propertyName == TitleProperty.PropertyName)
            {
                TitleLabel.Text = Title;
            }
            
            if (propertyName == NutrientProperty.PropertyName)
            {
                NutrientLabel.Text = Nutrient;
            }
            
            if (propertyName == ColorLineProperty.PropertyName)
            {
                ColorLineLabel.BackgroundColor = ColorLine;
            }

            if (propertyName == TextColorProperty.PropertyName)
            {
                TitleLabel.TextColor = TextColor;
            }
            
            if (propertyName == TextFontProperty.PropertyName)
            {
                TitleLabel.FontSize = TextFont;
            }

            if (propertyName == PercentageProperty.PropertyName)
            {
                PercentageLabel.Text = Percentage;
                PercentageLabel.IsVisible = true;
            }
            
        }
}