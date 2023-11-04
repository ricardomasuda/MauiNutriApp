using CommunityToolkit.Maui.Views;

namespace NutriApp.AppNutri.View.Evaluation.CircumferenceWaist;

public partial class InfoCircumferenceWaistPopup : Popup
{
    public InfoCircumferenceWaistPopup()
    {
        InitializeComponent();
        BindingContext = new InfoCircumferenceWaistPopupViewModel(this);
    }

    public static void ClosePopup()
    {
        ClosePopup();
    }
}