namespace ProiectMaui;

public partial class WeatherChartPage : ContentPage
{
    public WeatherChartPage()
    {
        BindingContext = new WeatherChartViewModel();
        InitializeComponent();
    }
}