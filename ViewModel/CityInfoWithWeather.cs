namespace ProiectMaui
{
    public class CityInfoWithWeather : CityInfo
    {
        public CityInfoWithWeather(CityInfo cityInfo) : base(cityInfo)
        {
        }
        public string CurrentTemp { get; set; }
    }
}