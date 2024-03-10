using CommunityToolkit.Maui.Views;
using NutriApp.Views.Evaluation.CircumferenceCalf.InfoPopup;

namespace NutriApp.AppNutri.View.Evaluation.CircumferenceCalf.InfoPopup;

public partial class InfoCircumferenceCalfPopup : Popup
{
    public InfoCircumferenceCalfPopup()
    {
        InitializeComponent();
        BindingContext = new InfoCircumferenceCalfPopupViewModel();
    }
}