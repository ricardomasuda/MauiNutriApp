namespace NutriApp.Views.Evaluation.SemiologyNutritional;

public partial class SemiologyNutritionalListViewModel : BaseViewModel
{
    [ObservableProperty]
    private ObservableCollection<SemiologyNutritionalModel> _listSemiologyNutritional;

    public SemiologyNutritionalListViewModel()
    {
        Fetch();
    }
        
    private void Fetch()
    {
        ListSemiologyNutritional = new SemiologyNutritionalModel().LoadList();
    }
}

