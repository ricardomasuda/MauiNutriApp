using CommunityToolkit.Maui.Views;
using NutriApp.AppNutri.View.Evaluation.Imc.Info;

namespace NutriApp.AppNutri.View.Evaluation.Imc.InfoPopup;

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