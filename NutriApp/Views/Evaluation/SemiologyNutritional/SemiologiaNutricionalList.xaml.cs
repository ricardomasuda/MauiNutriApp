namespace NutriApp.AppNutri.View.Evaluation.SemiologyNutritional;

public partial class SemiologiaNutricionalList : ContentPage
{
    public SemiologiaNutricionalList()
    {
        InitializeComponent();
        BindingContext = new SemiologyNutritionalListViewModel();
    }
}