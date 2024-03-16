using CommunityToolkit.Maui.Views;

namespace NutriApp.Views.Evaluation.IdealWeight.InfoPopup;

public class InfoIdealWeightPopupViewModel
{
    public Command CloseCommand { get; set; }
        
    public InfoIdealWeightPopupViewModel()
    {
        CloseCommand = new Command<Popup>(ClosePage);
    }
        
    private void ClosePage(Popup popup)
    {
        popup.Close();
    }
}