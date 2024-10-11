using NutriApp.Components.ContentPageCustomer;

namespace NutriApp.Views.ReportPage.Page;

public partial class ReportPage : BaseContentPage
{
    public ReportPage()
    {
        InitializeComponent();
        BindingContext = new ReportViewModel();
    }

}