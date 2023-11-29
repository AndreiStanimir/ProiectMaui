using SQLite;
using SQLiteNetExtensions.Attributes;

public class CityInfo
{
    [PrimaryKey, AutoIncrement]
    public int Id { get; set; }
    public string City { get; set; }
    public string Region { get; set; }

    public string? Temperature { get => Weather.OrderByDescending(weather => weather.Datetime).FirstOrDefault()?.Temp.ToString(); }
    // Foreign key reference to Weather
    [OneToMany]
    public List<Weather> Weather { get; set; } = new();
}