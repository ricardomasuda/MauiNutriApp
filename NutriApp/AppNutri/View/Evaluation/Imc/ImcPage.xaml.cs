using NutriApp.AppNutri.Componente.ContentPageCustomer;

namespace NutriApp.AppNutri.View.Evaluation.Imc;

public partial class ImcPage : BaseContentPage
{
    public ImcPage()
    {
        InitializeComponent();
        BindingContext = new ImcPageViewModel(this);
    }
}