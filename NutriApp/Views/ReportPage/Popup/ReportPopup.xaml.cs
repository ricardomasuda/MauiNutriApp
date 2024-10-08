using NutriApp.Views.ReportPage.Page;

namespace NutriApp.Views.ReportPage.Popup;

public partial class ReportPopup
{
    public ReportPopup(List<FoodModel> listFood)
    {
        BindingContext = new ReportViewModel(listFood);
        InitializeComponent();
    }
}