using NutriApp.Components.ContentPageCustomer;

namespace NutriApp.Views.ReportPage.Page;

public partial class ReportPage : BaseContentPage
{
    public ReportPage()
    {
        InitializeComponent();
    }
    
    // public async Task ShareReport()
    // {
    //     Stream image = await ReportStackLayout.CaptureImageAsync();
    //         
    //     await Utils.Utils.ShareFile(image);
    // }
}