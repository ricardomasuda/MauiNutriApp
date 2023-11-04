using System.Collections.ObjectModel;
using NutriApp.AppNutri.Componente;
using NutriApp.AppNutri.Model;
using NutriApp.AppNutri.service;

namespace NutriApp.AppNutri.View.Evaluation.List;

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