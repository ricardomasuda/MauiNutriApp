using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Maui.Views;

namespace NutriApp.AppNutri.View.Food.Detail;

public partial class InformationFoodPopup : Popup
{
    public InformationFoodPopup()
    {
        InitializeComponent();
        BindingContext = new InformationFoodPopupViewModel(this);
    }
}