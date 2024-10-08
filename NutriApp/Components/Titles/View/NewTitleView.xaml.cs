using System.Windows.Input;
using NutriApp.Models;
using NutriApp.Resources;

namespace NutriApp.Components.Titles.View;

public partial class NewTitleView : ContentView
{
    public static readonly BindableProperty VisibleBackProperty =
            BindableProperty.Create(
                propertyName: nameof(VisibleBack),
                returnType: typeof(bool),
                declaringType: typeof(NewTitleView),
                defaultValue: true);

        public static readonly BindableProperty TextTitleProperty =
            BindableProperty.Create(
                propertyName: nameof(TextTitle),
                returnType: typeof(string),
                defaultValue: default(string),
                declaringType: typeof(NewTitleView));

        public static readonly BindableProperty CommandProperty =
            BindableProperty.Create(
                propertyName: nameof(Command),
                returnType: typeof(ICommand),
                declaringType: typeof(NewTitleView),
                defaultValue: null);

        public static readonly BindableProperty TypeTitleProperty =
            BindableProperty.Create(
                propertyName: nameof(TypeTitle),
                returnType: typeof(TypeTitleEnum),
                declaringType: typeof(NewTitleView),
                defaultValue: TypeTitleEnum.None);
        
        public static readonly BindableProperty CommandParameterProperty =
            BindableProperty.Create(
                nameof(CommandParameter),
                typeof(object),
                typeof(NewTitleView),
                defaultValue: null);

        public ICommand Command
        {
            get => (ICommand) GetValue(CommandProperty);
            set => SetValue(CommandProperty, value);
        }
        
        public object CommandParameter
        {
            get => GetValue(CommandParameterProperty);
            set => SetValue(CommandParameterProperty, value);
        }

        public string TextTitle
        {
            get => (string) GetValue(TextTitleProperty);
            set => SetValue(TextTitleProperty, value);
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

        public NewTitleView()
        {
            InitializeComponent();
            Title.Margin = new Thickness(0, 10, 0, 0);
        }

        private void TipoAcao()
        {
            if (Icon == null) return;
            switch (TypeTitle)
            {
                case TypeTitleEnum.InfoCircle:
                    Icon.Text = IconName.QuestionCircle; 
                    break;
                case TypeTitleEnum.Edit:
                    Icon.Text = IconName.PencilSquare; 
                    //ImageLogo.Source = ImageSource.FromFile("edit.png");
                    break;
                case TypeTitleEnum.Plus:
                    Icon.Text = IconName.Plus; 
                    //ImageLogo.Source = ImageSource.FromFile("plusBlack.png");
                    break;
                case TypeTitleEnum.Trash:
                    Icon.Text = IconName.TrashO; 
                    Icon.FontFamily = "FontAwesomeRegular";
                    //ImageLogo.Source = ImageSource.FromFile("trashIcon.png");
                    break;
                case TypeTitleEnum.Close:
                    Icon.Text = IconName.Times;
                    Icon.FontFamily = "FontAwesomeBold";
                    //ImageLogo.Source = ImageSource.FromFile("close.png");
                    break;
                case TypeTitleEnum.Share:
                    Icon.Text = IconName.ShareAlt; 
                    Icon.FontFamily = "FontAwesomeBold";
                    //ImageLogo.Source = ImageSource.FromFile("share.png");
                    break;
                case TypeTitleEnum.None:
                default:
                    Icon.IsVisible = false;
                    FrameLogo.IsVisible = false;
                    Title.Margin = new Thickness(0, 20, 0, 0);
                    break;
            }
        }

        private void TapGestureRecognizer_OnTapped(object sender, EventArgs e)
        {
            try
            {
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
            if (Command.CanExecute(CommandParameter))
            {
                Command.Execute(CommandParameter);
            }
        }

        protected override void OnPropertyChanged(string propertyName)
        {
            base.OnPropertyChanged(propertyName);

            if (propertyName == TextTitleProperty.PropertyName)
            {
                LabelTitle.Text = TextTitle;
            }

            if (propertyName == TypeTitleProperty.PropertyName)
            {
                TipoAcao();
            }
        }
}