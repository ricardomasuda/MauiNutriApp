namespace NutriApp.Views.Evaluation.SemiologyNutritional;

public partial class SemiologiaNutricionalList : ContentPage
{
    public SemiologiaNutricionalList()
    {
        InitializeComponent();
        BindingContext = new SemiologyNutritionalListViewModel();
    }
}