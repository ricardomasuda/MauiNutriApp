using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NutriApp.AppNutri.View.Evaluation.SemiologyNutritional;

public partial class SemiologiaNutricionalList : ContentPage
{
    public SemiologiaNutricionalList()
    {
        InitializeComponent();
        BindingContext = new SemiologyNutritionalListViewModel();
    }
}