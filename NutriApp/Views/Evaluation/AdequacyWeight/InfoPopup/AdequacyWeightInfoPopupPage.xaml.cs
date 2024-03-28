using CommunityToolkit.Maui.Views;

namespace NutriApp.Views.Evaluation.AdequacyWeight.InfoPopup;

public partial class AdequacyWeightInfoPopupPage : Popup
{
    public AdequacyWeightInfoPopupPage()
    {
        InitializeComponent();
        BindingContext = new AdequacyWeightInfoViewModel();
    }
}