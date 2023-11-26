namespace ProiectMaui;

public partial class CityListPage : ContentPage
{
    private readonly DatabaseContext DbContext;

    public CityListPage(DatabaseContext dbContext)
    {
        InitializeComponent();
        BindingContext = new CityListViewModel(dbContext);
        DbContext = dbContext;
    }

    private async void OnSelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        var selectedCity = e.CurrentSelection.FirstOrDefault() as CityInfo;
        if (selectedCity != null)
        {
            // Navigate to CityDetailPage with the selected city's MajorCityId
            await Navigation.PushAsync(new CityDetailPage(DbContext, selectedCity.MajorCityId));
        }
    }
}