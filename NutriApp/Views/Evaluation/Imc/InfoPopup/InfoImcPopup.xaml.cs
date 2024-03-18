using CommunityToolkit.Maui.Views;

namespace NutriApp.Views.Evaluation.Imc.InfoPopup;

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