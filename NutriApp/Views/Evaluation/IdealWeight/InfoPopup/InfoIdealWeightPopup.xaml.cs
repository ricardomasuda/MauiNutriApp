using CommunityToolkit.Maui.Views;
using NutriApp.Views.Evaluation.IdealWeight.InfoPopup;

namespace NutriApp.AppNutri.View.Evaluation.IdealWeight.InfoPopup;

public partial class InfoIdealWeightPopup : Popup
{
    public InfoIdealWeightPopup()
    {
        InitializeComponent();
        BindingContext = new InfoIdealWeightPopupViewModel();
    }
}