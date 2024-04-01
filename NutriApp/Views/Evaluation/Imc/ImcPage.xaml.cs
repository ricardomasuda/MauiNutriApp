using NutriApp.Components.ContentPageCustomer;

namespace NutriApp.Views.Evaluation.Imc;

public partial class ImcPage : BaseContentPage
{
    public ImcPage()
    {
        InitializeComponent();
        BindingContext = new ImcPageViewModel();
    }
}