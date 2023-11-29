namespace ProiectMaui;

public partial class CityListPage : ContentPage
{
    public CityListPage()
    {
        InitializeComponent();
        //BindingContext = new CityListViewModel();
    }

    private async void OnSelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        var selectedCity = e.CurrentSelection.FirstOrDefault() as CityInfo;
        if (selectedCity != null)
        {
            // Navigate to CityDetailPage with the selected city's WeatherId

            await Navigation.PushAsync(new CityDetailPage(selectedCity.City), true);
        }
    }
}