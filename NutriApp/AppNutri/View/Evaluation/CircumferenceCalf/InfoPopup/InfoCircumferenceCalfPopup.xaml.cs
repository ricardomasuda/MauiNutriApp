using CommunityToolkit.Maui.Views;

namespace NutriApp.AppNutri.View.Evaluation.CircumferenceCalf.InfoPopup;

public partial class InfoCircumferenceCalfPopup : Popup
{
    public InfoCircumferenceCalfPopup()
    {
        InitializeComponent();
        BindingContext = new InfoCircumferenceCalfPopupViewModel();
    }
}