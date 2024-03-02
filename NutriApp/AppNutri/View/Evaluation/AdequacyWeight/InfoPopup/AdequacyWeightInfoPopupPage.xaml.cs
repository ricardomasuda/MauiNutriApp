using CommunityToolkit.Maui.Views;

namespace NutriApp.AppNutri.View.Evaluation.AdequacyWeight.InfoPopup;

public partial class AdequacyWeightInfoPopupPage : Popup
{
    public AdequacyWeightInfoPopupPage()
    {
        InitializeComponent();
        BindingContext = new AdequacyWeightInfoViewModel();
    }
}