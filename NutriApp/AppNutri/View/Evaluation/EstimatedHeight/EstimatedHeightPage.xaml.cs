using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NutriApp.AppNutri.View.Evaluation.EstimatedHeight;

public partial class EstimatedHeightPage : ContentPage
{
    public EstimatedHeightPage()
    {
        InitializeComponent();
        BindingContext = new EstimatedHeightPageViewModel();
    }
}