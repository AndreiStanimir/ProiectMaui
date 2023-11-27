namespace ProiectMaui
{
    public class CityDetailViewModel : ViewModelBase
    {

        private Weather _Weather;
        public Weather Weather
        {
            get => _Weather;
            set
            {
                _Weather = value;
                OnPropertyChanged();
            }
        }

        private string Name;

        public CityDetailViewModel(string name) : base()
        {
            Name = name;
            LoadWeatherDetails();
        }

        private void LoadWeatherDetails()
        {
            Weather = _dbContext.GetMajorCitiesAsync().Find(x => x.Name == Name);
        }
    }
}
