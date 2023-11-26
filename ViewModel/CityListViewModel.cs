using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace ProiectMaui
{
    internal class CityListViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<CityInfo> Cities { get; private set; }

        public event PropertyChangedEventHandler PropertyChanged;

        public CityListViewModel()
        {
            Cities = new ObservableCollection<CityInfo>();
            LoadCities();
        }

        private void LoadCities()
        {
            // Assuming you have a method to get cities from the database
            // var cities = databaseContext.GetCitiesAsync().Result;
            // foreach (var city in cities)
            // {
            //     Cities.Add(city);
            // }

            // Replace the above with actual database call
        }

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
