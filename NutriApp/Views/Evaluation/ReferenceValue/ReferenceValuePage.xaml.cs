using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NutriApp.Components.ContentPageCustomer;

namespace NutriApp.Views.Evaluation.ReferenceValue;

public partial class ReferenceValuePage : BaseContentPage
{
    public ReferenceValuePage()
    {
        InitializeComponent();
        BindingContext = new ReferenceValuePageViewModel();
    }
}