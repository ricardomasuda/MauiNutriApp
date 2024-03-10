using System.Collections.ObjectModel;
using NutriApp.Components;
using NutriApp.Models;

namespace NutriApp.Views.Evaluation.SemiologyNutritional;

public class SemiologyNutritionalListViewModel : BaseViewModel
{
    private ObservableCollection<SemiologyNutritionalModel> _listSemiologyNutritional;
    public ObservableCollection<SemiologyNutritionalModel> ListSemiologyNutritional { 
        get => _listSemiologyNutritional;
        set
        {
            _listSemiologyNutritional = value; OnPropertyChanged("ListSemiologyNutritional"); 
        }
    }

    public SemiologyNutritionalListViewModel()
    {
        Fetch();
    }
        
    private void Fetch()
    {
        ListSemiologyNutritional = new SemiologyNutritionalModel().LoadList();
    }
}

