using SkiaSharp;
using System.Collections.ObjectModel;
/* Unmerged change from project 'ProiectMaui (net8.0-windows10.0.22621.0)'
Before:
using System.Threading.Tasks;
After:
using System.Windows.Input;
*/


namespace ProiectMaui;

public class WeatherChartViewModel : ViewModelBase
{
    public ObservableCollection<CityInfo> Cities { get; private set; }
    public ObservableCollection<Weather> Weathers { get; private set; }
    public Command LoadDataCommand { get; }

    public WeatherChartViewModel()
    {
        Cities = new(_dbContext.GetCitiesAsync());
        Weathers = new(_dbContext.GetWeathersAsync());
        LoadDataCommand = new Command(async () => await LoadData());
    }

    private async Task LoadData()
    {
    }
    //public async Task LoadData(datet)
    internal ObservableCollection<Weather> LoadData(string cityName, DateTime start, DateTime end)
    {
        var weather = Weathers.Where(x => x.Name == cityName);
        Weathers = new ObservableCollection<Weather>(weather.Where(x => x.Datetime.IsBewteenTwoDates(start, end)).ToList());
        UpdateChart();
        return Weathers;
    }
    // Add methods to handle date and city selection and update the chart

    private void UpdateChart()
    {
    }
}
public static partial class Extensions
{
    public static bool IsBewteenTwoDates(this DateTime dt, DateTime start, DateTime end)
    {
        return dt >= start && dt <= end;
    }
}