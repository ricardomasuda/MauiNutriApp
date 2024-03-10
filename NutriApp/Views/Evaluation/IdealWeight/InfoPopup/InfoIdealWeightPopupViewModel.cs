namespace NutriApp.AppNutri.View.Evaluation.IdealWeight.InfoPopup;

public class InfoIdealWeightPopupViewModel
{
    public Command CloseCommand { get; set; }
        
    public InfoIdealWeightPopupViewModel()
    {
        CloseCommand = new Command(ClosePage);
    }
        
    private static void ClosePage()
    {
        //App.NavPage.Navigation.PopPopupAsync();
    }
}