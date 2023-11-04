using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NutriApp.AppNutri.View.Evaluation.CircumferenceWaist;

public partial class CircumferenceWaistPage : ContentPage
{
    public CircumferenceWaistPage()
    {
        InitializeComponent();
        BindingContext = new CircumferenceWaistViewModel();
    }
}