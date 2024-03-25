using CommunityToolkit.Maui.Views;

namespace NutriApp.Views.Evaluation.IdealWeight.InfoPopup;

public partial class InfoIdealWeightPopupViewModel
{
    [RelayCommand]
    private void Close(Popup popup)
    {
        popup.Close();
    }
}