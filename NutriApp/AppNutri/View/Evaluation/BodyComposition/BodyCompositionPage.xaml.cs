using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NutriApp.AppNutri.View.Evaluation.BodyComposition;

public partial class BodyCompositionPage : ContentPage
{
    public BodyCompositionPage()
    {
        InitializeComponent();
        BindingContext = new BodyCompositionPageViewModel();
    }
}