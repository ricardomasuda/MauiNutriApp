namespace NutriApp.Views.Food.Detail.InfoPopup;

public class InformationFoodPopupViewModel
{
    public Command CloseCommand { get; set; }
    private InformationFoodPopup _informationFoodPopup;
    public InformationFoodPopupViewModel(InformationFoodPopup informationFoodPopup)
    {
        _informationFoodPopup = informationFoodPopup;
        CloseCommand = new Command(ClosePage);
    }

    private void ClosePage()
    {
        _informationFoodPopup.CloseAsync();
    }
}