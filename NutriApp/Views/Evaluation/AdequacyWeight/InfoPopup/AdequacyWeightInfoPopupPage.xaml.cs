using CommunityToolkit.Maui.Views;
using NutriApp.Views.Evaluation.AdequacyWeight.InfoPopup;

namespace NutriApp.AppNutri.View.Evaluation.AdequacyWeight.InfoPopup;

public partial class AdequacyWeightInfoPopupPage : Popup
{
    public AdequacyWeightInfoPopupPage()
    {
        InitializeComponent();
        BindingContext = new AdequacyWeightInfoViewModel();
    }
}