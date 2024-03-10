using CommunityToolkit.Maui.Views;

namespace NutriApp.Views.Evaluation.CircumferenceWaist.InfoPopup;

public partial class InfoCircumferenceWaistPopup : Popup
{
    public InfoCircumferenceWaistPopup()
    {
        InitializeComponent();
        var popupPage = new InfoCircumferenceWaistPopupViewModel(this);
        BindingContext = popupPage;
        popupPage.Popup = this;
    }

    public void ClosePopupPage()
    {
       CloseAsync();
    }
}