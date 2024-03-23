using NutriApp.Components.ContentPageCustomer;

namespace NutriApp.Views.Evaluation.EstimatedHeight;

public partial class EstimatedHeightPage : BaseContentPage
{
    public EstimatedHeightPage()
    {
        InitializeComponent();
        BindingContext = new EstimatedHeightPageViewModel();
    }
}