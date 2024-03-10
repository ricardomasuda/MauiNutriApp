using System.Collections.ObjectModel;
using NutriApp.Components;
using NutriApp.Models;
using NutriApp.Services;

namespace NutriApp.Views.Evaluation.List;

public class EvaluationListPageViewModel : BaseViewModel
{
    public Command GoToEvaluationMenuCommand { get; set; }
        
    private ObservableCollection<ItemMenu> _itemMenu;
    public ObservableCollection<ItemMenu> ItemMenu { get => _itemMenu; set { _itemMenu = value; OnPropertyChanged("ItemMenu"); } }
        
    public EvaluationListPageViewModel()
    {
        FillPage();
        GoToEvaluationMenuCommand = new Command(GoEvaluationMenu);
    }

    private void FillPage()
    {
        ItemMenu = new ObservableCollection<ItemMenu>();
        ItemMenu = NavigationEvaluationService.Fetch();
    }

    private static void GoEvaluationMenu(object sender)
    {
        NavigationEvaluationService.GoEvaluationMenu((ItemMenu)sender);
    }
}