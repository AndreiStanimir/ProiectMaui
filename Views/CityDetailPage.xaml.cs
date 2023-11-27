namespace ProiectMaui;

public partial class CityDetailPage : ContentPage
{
    public CityDetailPage(string name)
    {
        InitializeComponent();
        BindingContext = new CityDetailViewModel(name);
    }
}
