using System.Collections.ObjectModel;

namespace ProiectMaui;

public partial class WeatherChartPage : ContentPage
{
    WeatherChartViewModel WeatherChartViewModel => (WeatherChartViewModel)BindingContext;
    public WeatherChartPage()
    {
        BindingContext = new WeatherChartViewModel();
        InitializeComponent();
        cityPicker.ItemsSource = new ObservableCollection<CityInfo>(WeatherChartViewModel.Cities).ToList();
        cityPicker.ItemDisplayBinding = new Binding(nameof(CityInfo.City));
    }

    private void toDatePicker_DateSelected(object sender, DateChangedEventArgs e)
    {
        WeatherChartViewModel.LoadData(cityPicker.SelectedItem.ToString(), fromDatePicker.Date, toDatePicker.Date);
    }
}