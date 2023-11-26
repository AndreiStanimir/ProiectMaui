using SQLite;

public class MajorCity
{
    [PrimaryKey, AutoIncrement]
    public int Id { get; set; }
    public string Name { get; set; }
    public string Datetime { get; set; } // or use DateTime if you parse the string into a DateTime object
    public double TempMax { get; set; }
    public double TempMin { get; set; }
    public double Temp { get; set; }
    public double Humidity { get; set; }
    public double Precip { get; set; }
    public string Sunrise { get; set; } // or use TimeSpan or DateTime
    public string Sunset { get; set; } // or use TimeSpan or DateTime
}