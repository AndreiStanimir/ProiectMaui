using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using SQLite;
using SQLiteNetExtensions.Attributes;
using System.Globalization;
using System.Runtime.Serialization;
using JsonConverter = Newtonsoft.Json.JsonConverter;

public class Weather
{
    [PrimaryKey, AutoIncrement]
    public int Id { get; set; }
    public string Name { get; set; }
    [JsonConverter(typeof(DateFormatConverter))]
    public DateTime Datetime { get; set; } // or use DateTime if you parse the string into a DateTime object
    public double TempMax { get; set; }
    public double TempMin { get; set; }
    public double Temp { get; set; }
    public double Humidity { get; set; }
    public double Precip { get; set; }
    [JsonConverter(typeof(TimeSpanFormatConverter), "h:mm:ss tt")]
    public TimeSpan Sunrise { get; set; } // or use TimeSpan or DateTime
    [JsonConverter(typeof(TimeSpanFormatConverter), "h:mm:ss tt")]

    public TimeSpan Sunset { get; set; } // or use TimeSpan or DateTime

    [ForeignKey(typeof(CityInfo))]
    public int CityInfoId { get; set; }
}
public class DateFormatConverter : IsoDateTimeConverter
{
    public DateFormatConverter()
    {
        DateTimeFormat = "M/d/yyyy";
    }
}
public class TimeSpanFormatConverter : JsonConverter
{
    private readonly string _format;

    public TimeSpanFormatConverter(string format)
    {
        _format = format;
    }

    public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
    {
        var timespan = (TimeSpan)value;
        writer.WriteValue(timespan.ToString(_format));
    }

    public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
    {
        if (reader.TokenType == JsonToken.Null) return null;
        var timeString = reader.Value.ToString().Trim();
        var dateTime = DateTime.ParseExact(timeString, _format, CultureInfo.InvariantCulture);
        return dateTime.TimeOfDay;
    }

    public override bool CanConvert(Type objectType)
    {
        return objectType == typeof(TimeSpan);
    }
}