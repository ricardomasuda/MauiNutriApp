using CommunityToolkit.Maui.Views;

namespace NutriApp.Views.Evaluation.CircumferenceWaist;

public partial class InfoCircumferenceWaistPopup : Popup
{
    public InfoCircumferenceWaistPopup()
    {
        InitializeComponent();
        BindingContext = new InfoCircumferenceWaistPopupViewModel(this);
    }

    public void ClosePopupPage()
    {
       CloseAsync();
    }
}