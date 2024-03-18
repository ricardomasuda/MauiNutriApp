using System.Windows.Input;
using NutriApp.Models;

namespace NutriApp.Components.Titles.View;

public partial class SearchTitleView : ContentView
{
    public static readonly BindableProperty VisibleBackProperty =
            BindableProperty.Create(
                propertyName: nameof(VisibleBack),
                returnType: typeof(bool),
                declaringType: typeof(SearchTitleView),
                defaultValue: true);

        public static readonly BindableProperty TextTitleProperty =
            BindableProperty.Create(
                propertyName: nameof(TextTitle),
                returnType: typeof(string),
                defaultValue: default(string),
                declaringType: typeof(SearchTitleView));
        
        public static readonly BindableProperty TextSearchProperty =
            BindableProperty.Create(
                propertyName: nameof(TextSearch),
                returnType: typeof(string),
                defaultValue: default(string),
                defaultBindingMode: BindingMode.TwoWay,
                declaringType: typeof(SearchTitleView));

        public static readonly BindableProperty CommandProperty =
            BindableProperty.Create(
                propertyName: nameof(Command),
                returnType: typeof(ICommand),
                declaringType: typeof(SearchTitleView),
                defaultValue: null);

        public static readonly BindableProperty TypeTitleProperty =
            BindableProperty.Create(
                propertyName: nameof(TypeTitle),
                returnType: typeof(TypeTitleEnum),
                declaringType: typeof(SearchTitleView),
                defaultValue: TypeTitleEnum.None);

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
        
        public string TextSearch
        {
            get => (string) GetValue(TextSearchProperty);
            set => SetValue(TextSearchProperty, value);
        }

        public bool VisibleBack
        {
            get => (bool) GetValue(VisibleBackProperty);
            set
            {
                SetValue(VisibleBackProperty, value);
                FrameBack.IsVisible = value;
            }
        }

        public TypeTitleEnum TypeTitle
        {
            get => (TypeTitleEnum) GetValue(TypeTitleProperty);
            set
            {
                SetValue(TypeTitleProperty, value);
                TipoAcao();
            }
        }

        private Thickness MarginTitle { get; set; }

        public SearchTitleView()
        {
            InitializeComponent();
            Title.Margin = new Thickness(0, 10, 0, 0);
        }

        private void TipoAcao()
        {
            if (Icon == null) return;
          
        }

        private void TapGestureRecognizer_OnTapped(object sender, EventArgs e)
        {
            try
            {
                IEnumerable<Page> navigationStack = Shell.Current.Navigation.NavigationStack;
                Shell.Current.Navigation.PopAsync();
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                throw;
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

        protected override void OnPropertyChanged(string propertyName)
        {
            base.OnPropertyChanged(propertyName);

            if (propertyName == TextTitleProperty.PropertyName)
            {
                LabelTitle.Text = TextTitle;
            }

            if (propertyName == TextTitleProperty.PropertyName)
            {
                TipoAcao();
            }
        }
}