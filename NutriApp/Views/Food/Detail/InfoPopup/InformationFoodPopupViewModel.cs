using CommunityToolkit.Maui.Views;

namespace NutriApp.Views.Food.Detail.InfoPopup;

public partial class InformationFoodPopupViewModel
{
    [RelayCommand]
    private void Close(Popup popup)
    {
        popup.Close();
    }
}