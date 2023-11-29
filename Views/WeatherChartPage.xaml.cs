using Microcharts;
using System.Collections.ObjectModel;

namespace ProiectMaui;

public partial class WeatherChartPage : ContentPage
{
    WeatherChartViewModel WeatherChartViewModel => (WeatherChartViewModel)BindingContext;
    public WeatherChartPage()
    {
        BindingContext = new WeatherChartViewModel();
        InitializeComponent();
        // cityPicker.ItemsSource = new List<string> { "aa", "Bb" };
        cityPicker.ItemsSource = new ObservableCollection<CityInfo>(WeatherChartViewModel.CitiesWithWeather).ToArray();
        cityPicker.ItemDisplayBinding = new Binding(nameof(CityInfo.City));
        fromDatePicker.Date = new DateTime(2022, 01, 01);
        toDatePicker.Date = DateTime.Now;
        cityPicker.SelectedIndex = 0;
    }

    private void toDatePicker_DateSelected(object sender, DateChangedEventArgs e)
    {
        UpdateChart();
    }

    private void cityPicker_SelectedIndexChanged(object sender, EventArgs e)
    {
        UpdateChart();
    }

    private void UpdateChart()
    {
        if (cityPicker.SelectedItem is null or -1) return;
        if (fromDatePicker.Date >= toDatePicker.Date) return;
        var cityInfo = cityPicker.SelectedItem as CityInfo;
        var weather = WeatherChartViewModel.LoadData(cityInfo.City, fromDatePicker.Date, toDatePicker.Date);
        if (!weather.Any()) return;
        chartView.Chart = new LineChart()
        {
            Entries = weather.Select(x => new ChartEntry((float)x.Temp)
            {
                Label = x.Datetime.ToString("MMM dd"), // X-axis label (e.g., date)
                ValueLabel = x.Temp.ToString(), // Y-axis value label
            }).ToArray(),
            ValueLabelOption = ValueLabelOption.TopOfElement,
            ValueLabelOrientation=Orientation.Horizontal,
            LabelOrientation=Orientation.Horizontal,
            MinValue =(float) weather.Min(x => x.TempMin), 
            MaxValue =(float) weather.Max(x => x.TempMax)
        };
    }
}
