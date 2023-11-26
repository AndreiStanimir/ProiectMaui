namespace ProiectMaui;

public partial class CityDetailPage : ContentPage
{
    public CityDetailPage(DatabaseContext dbContext, int majorCityId)
    {
        InitializeComponent();
        BindingContext = new CityDetailViewModel(dbContext, majorCityId);
    }
}
