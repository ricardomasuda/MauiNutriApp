using System.Collections.ObjectModel;
using NutriApp.AppNutri.Componente;
using NutriApp.AppNutri.Model;

namespace NutriApp.AppNutri.View.Evaluation.SemiologyNutritional;

public class SemiologyNutritionalListViewModel : BaseViewModel
{
    private ObservableCollection<SemiologyNutritionalModel> _listSemiologyNutritional;
    public ObservableCollection<SemiologyNutritionalModel> ListSemiologyNutritional { get => _listSemiologyNutritional;
        set { _listSemiologyNutritional = value; OnPropertyChanged("ListSemiologyNutritional"); } }

    public SemiologyNutritionalListViewModel()
    {
        Fetch();
    }
        
    private void Fetch()
    {
        ListSemiologyNutritional = new SemiologyNutritionalModel().LoadList();
    }
}

