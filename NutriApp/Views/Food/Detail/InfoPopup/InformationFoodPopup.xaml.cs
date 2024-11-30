namespace NutriApp.Views.Food.Detail.InfoPopup;

public partial class InformationFoodPopup
{
    public InformationFoodPopup()
    {
        InitializeComponent();
        BindingContext = new InformationFoodPopupViewModel();
    }
}