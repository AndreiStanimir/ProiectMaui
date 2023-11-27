using System.Collections.ObjectModel;

namespace ProiectMaui
{
    public class CityListViewModel : ViewModelBase
    {
        public ObservableCollection<CityInfo> Cities { get; private set; }

        public CityListViewModel() : base()
        {
            Cities = new ObservableCollection<CityInfo>();
            LoadCities();
        }

        private void LoadCities()
        {
            Cities = new(_dbContext.GetCitiesAsync());
        }
    }
}
