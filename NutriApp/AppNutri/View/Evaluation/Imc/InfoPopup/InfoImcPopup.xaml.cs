using CommunityToolkit.Maui.Views;
namespace NutriApp.AppNutri.View.Evaluation.Imc.Info;

public partial class InfoImcPopup : Popup
{
    public InfoImcPopup()
    {
        InitializeComponent();
        var popupPage = new InfoImcPopupViewModel();
        BindingContext = popupPage;
        popupPage.Popup = this;
    }
}