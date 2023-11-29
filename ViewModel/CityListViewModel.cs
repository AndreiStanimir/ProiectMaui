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
            LoadCities().Wait();
        }

        private async Task LoadCities()
        {
            Cities = new(_dbContext.GetCitiesAsync());
            CitiesWithWeather = new ObservableCollection<CityInfoWithWeather>(Cities.Select(c => new CityInfoWithWeather(c)
            {
                CurrentTemp = _dbContext.GetCurrentTemp(c.City),
            }));
            //foreach (var city in CitiesWithWeather)
            //{
            //    city.ImagePath = await CityImageDownloader.DownloadCityImageAsync(city.City);
            //}
            //CitiesWithWeather.Add(new(new()));
            //CitiesWithWeather.RemoveAt(CitiesWithWeather.Count - 1);
        }
    }
}
