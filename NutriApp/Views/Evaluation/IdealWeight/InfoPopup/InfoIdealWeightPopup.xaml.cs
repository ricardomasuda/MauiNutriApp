using CommunityToolkit.Maui.Views;

namespace NutriApp.Views.Evaluation.IdealWeight.InfoPopup;

public partial class InfoIdealWeightPopup : Popup
{
    public InfoIdealWeightPopup()
    {
        InitializeComponent();
        BindingContext = new InfoIdealWeightPopupViewModel();
    }
}