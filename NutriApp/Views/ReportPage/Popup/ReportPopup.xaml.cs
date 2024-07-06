using NutriApp.Views.ReportPage.Page;

namespace NutriApp.Views.ReportPage.Popup;

public partial class ReportPopup : CommunityToolkit.Maui.Views.Popup
{
    public ReportPopup(List<FoodModel> listFood)
    {
        BindingContext = new ReportViewModel(listFood);
        InitializeComponent();
    }
}