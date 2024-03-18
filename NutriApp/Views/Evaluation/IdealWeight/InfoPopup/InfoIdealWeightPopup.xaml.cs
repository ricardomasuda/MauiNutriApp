using CommunityToolkit.Maui.Views;

namespace NutriApp.AppNutri.View.Evaluation.IdealWeight.InfoPopup;

public partial class InfoIdealWeightPopup : Popup
{
    public InfoIdealWeightPopup()
    {
        InitializeComponent();
        BindingContext = new InfoIdealWeightPopupViewModel();
    }
}