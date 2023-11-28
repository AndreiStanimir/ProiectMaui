namespace ProiectMaui;

public partial class App : Application
{
    public App()
    {
        InitializeComponent();
        var dbContext = MauiProgram.CreateMauiApp().Services.GetService<DatabaseContext>();
        //MainPage = new NavigationPage(new CityListPage());
        MainPage = new NavigationPage(new WeatherChartPage());
    }
}
