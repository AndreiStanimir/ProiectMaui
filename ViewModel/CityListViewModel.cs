using System.Collections.ObjectModel;

namespace ProiectMaui
{
    public class CityListViewModel : ViewModelBase
    {
        public ObservableCollection<CityInfo> Cities { get; private set; }
        public ObservableCollection<CityInfoWithWeather> CitiesWithWeather { get; private set; }

        public CityListViewModel() : base()
        {
            Cities = new ObservableCollection<CityInfo>();
            LoadCities();
        }

        private void LoadCities()
        {
            Cities = new(_dbContext.GetCitiesAsync());
            CitiesWithWeather = new ObservableCollection<CityInfoWithWeather>(Cities.Select(c=>new CityInfoWithWeather(c) { CurrentTemp=_dbContext.GetCurrentTemp(c.City)}));
        }
    }
}
