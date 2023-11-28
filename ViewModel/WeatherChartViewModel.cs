using System.Collections.ObjectModel;
/* Unmerged change from project 'ProiectMaui (net8.0-windows10.0.22621.0)'
Before:
using System.Threading.Tasks;
After:
using System.Windows.Input;
*/


namespace ProiectMaui
{
    public class WeatherChartViewModel : ViewModelBase
    {
        public ObservableCollection<CityInfo> Cities { get; private set; }
        public Command LoadDataCommand { get; }

        public WeatherChartViewModel()
        {
            Cities = new(_dbContext.GetCitiesAsync());
            LoadDataCommand = new Command(async () => await LoadData());
        }

        private async Task LoadData()
        {
            // Load city data and other initialization logic
        }

        // Add methods to handle date and city selection and update the chart
    }
}
