using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NutriApp.AppNutri.View.Evaluation.IdealWeight;

public partial class IdealWeightPage : ContentPage
{
    public IdealWeightPage()
    {
        InitializeComponent();
        BindingContext = new IdealWeightViewModel();
    }
}