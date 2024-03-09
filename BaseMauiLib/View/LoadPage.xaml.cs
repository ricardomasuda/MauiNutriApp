using CommunityToolkit.Maui.Views;

namespace MauiLib1.View;

public partial class LoadPage : Popup
{
    public LoadPage()
    {
        InitializeComponent();
    }
    
    public void HidePopupPage()
    {
        this.Close();
    }

}