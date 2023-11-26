namespace ProiectMaui;

public partial class CityDetailPage : ContentPage
{
    public CityDetailPage(int majorCityId)
    {
        InitializeComponent();
        BindingContext = new CityDetailViewModel(majorCityId);
    }
}