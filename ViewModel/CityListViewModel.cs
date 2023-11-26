using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace ProiectMaui
{
    internal class CityListViewModel : ViewModelBase
    {
        public ObservableCollection<CityInfo> Cities { get; private set; }

        public CityListViewModel(DatabaseContext dbContext) : base(dbContext)
        {
            Cities = new ObservableCollection<CityInfo>();
            LoadCities();
        }

        private void LoadCities()
        {
            Cities = new(_dbContext.GetCitiesAsync().Result);
        }
    }
}
