using LiveChartsCore.SkiaSharpView.Painting;
using LiveChartsCore.SkiaSharpView;
using LiveChartsCore;
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
        LoadDataCommand = new Command(async () => await LoadData());
    }

    private async Task LoadData()
    {
    }
    //public async Task LoadData(datet)
    internal void LoadData(string cityName, DateTime start, DateTime end)
    {
        Weathers = new ObservableCollection<Weather>(Cities.FirstOrDefault(x => x.City == cityName).Weather.Where(x => x.Datetime.IsBewteenTwoDates(start, end)).ToList());
        UpdateChart();
    }
    // Add methods to handle date and city selection and update the chart

    private void UpdateChart()
    {
    }
    public ISeries[] Series { get; set; } =
   {
        new ColumnSeries<double>
        {
            Name = "Mary",
            Values = new double[] { 2, 5, 4 }
        },
        new ColumnSeries<double>
        {
            Name = "Ana",
            Values = new double[] { 3, 1, 6 }
        }
    };

    public Axis[] XAxes { get; set; } =
    {
        new Axis
        {
            Labels = new string[] { "Category 1", "Category 2", "Category 3" },
            LabelsRotation = 0,
            SeparatorsPaint = new SolidColorPaint(new SKColor(200, 200, 200)),
            SeparatorsAtCenter = false,
            TicksPaint = new SolidColorPaint(new SKColor(35, 35, 35)),
            TicksAtCenter = true,
            // By default the axis tries to optimize the number of // mark
            // labels to fit the available space, // mark
            // when you need to force the axis to show all the labels then you must: // mark
            ForceStepToMin = true, // mark
            MinStep = 1 // mark
        }
    };
}
public static partial class Extensions
{
    public static bool IsBewteenTwoDates(this DateTime dt, DateTime start, DateTime end)
    {
        return dt >= start && dt <= end;
    }
}