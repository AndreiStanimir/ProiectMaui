namespace ProiectMaui
{
    public class CityInfoWithWeather : CityInfo
    {
        public CityInfoWithWeather(CityInfo cityInfo) : base(cityInfo)
        {
            ImagePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Resources", "Images", City, ".jpg");
            ImagePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "tokyo.scale-100.jpg");
        }
        public string CurrentTemp { get; set; }
        public string ImagePath { get; set; }
    }
}