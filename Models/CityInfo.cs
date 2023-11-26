using SQLite;

public class CityInfo
{
    [PrimaryKey, AutoIncrement]
    public int Id { get; set; }
    public string City { get; set; }
    public string Region { get; set; }

    // Foreign key reference to MajorCity
    public int MajorCityId { get; set; }
}