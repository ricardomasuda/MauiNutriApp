using CommunityToolkit.Maui.Views;

namespace NutriApp.Views.Evaluation.CircumferenceWaist.InfoPopup;

public partial class InfoCircumferenceWaistPopup : Popup
{
    public InfoCircumferenceWaistPopup()
    {
        InitializeComponent();
        BindingContext =  new InfoCircumferenceWaistPopupViewModel(this);;
    }
}