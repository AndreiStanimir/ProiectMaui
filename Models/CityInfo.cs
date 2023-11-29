using SQLite;
using SQLiteNetExtensions.Attributes;

public class CityInfo
{
    public CityInfo()
    {
        
    }
    public CityInfo(CityInfo cityInfo)
    {
        Id = cityInfo.Id;
        City= cityInfo.City;
        Region = cityInfo.Region;
        Weather= cityInfo.Weather;
    }

    [PrimaryKey, AutoIncrement]
    public int Id { get; set; }
    public string City { get; set; }
    public string Region { get; set; }

    // Foreign key reference to Weather
    [OneToMany]
    public List<Weather> Weather { get; set; } = new();
}