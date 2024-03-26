namespace NutriApp.Views.Evaluation.List;

public partial class EvaluationListPageViewModel : BaseViewModel
{
    [ObservableProperty]
    private ObservableCollection<ItemMenu> _itemMenu;
        
    public EvaluationListPageViewModel()
    {
        FillPage();
    }

    private void FillPage()
    {
        ItemMenu = new ObservableCollection<ItemMenu>();
        ItemMenu = NavigationEvaluationService.Fetch();
    }
    
    [RelayCommand]
    private static void GoToEvaluationMenu(object sender)
    {
        NavigationEvaluationService.GoEvaluationMenu((ItemMenu)sender);
    }
}