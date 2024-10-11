using CommunityToolkit.Maui.Views;

namespace NutriApp.Views.Evaluation.Imc.InfoPopup;

public partial class InfoImcPopup
{
    public InfoImcPopup()
    {
        InitializeComponent();
        var popupPage = new InfoImcPopupViewModel();
        BindingContext = popupPage;
        //popupPage.Popup = this;
    }
}