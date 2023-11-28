using Newtonsoft.Json;
using SQLite;
using SQLiteNetExtensions.Extensions;

namespace ProiectMaui;

public class DatabaseContext
{
    private readonly SQLiteConnection Database;
    private TableQuery<CityInfo> Cities => Database.Table<CityInfo>();
    private TableQuery<Weather> Weathers => Database.Table<Weather>();
    public DatabaseContext(string dbPath)
    {
        //if (Path.Exists(dbPath))
        //    new SQLiteConnection(dbPath);
        Database = new SQLiteConnection(dbPath);
        Database.Trace = true;
        //InitializeDatabaseAsync().Wait();
    }

    private async Task InitializeDatabaseAsync()
    {
        Database.DeleteAll<CityInfo>();
        Database.DeleteAll<Weather>();
        Database.CreateTables(CreateFlags.ImplicitIndex, typeof(CityInfo), typeof(Weather));
        // Optionally, include seed data or additional initialization here
        string mainDir = FileSystem.Current.AppDataDirectory;
        //string cityInfoJson = await JsonFileReader.ReadJsonFileAsync("C:\\Users\\andrei.stanimir\\source\\repos\\ProiectMaui\\Resources\\Raw\\city_region.json");
        //string WeatherJson = await JsonFileReader.ReadJsonFileAsync("C:\\Users\\andrei.stanimir\\source\\repos\\ProiectMaui\\Resources\\Raw\\major_cities.json");

        await InsertCitiesFromJsonAsync("C:\\Users\\andrei.stanimir\\source\\repos\\ProiectMaui\\Resources\\Raw\\city_region.json");
        await InsertMajorCitiesFromJsonAsync("C:\\Users\\andrei.stanimir\\source\\repos\\ProiectMaui\\Resources\\Raw\\major_cities.json");
    }

    public List<CityInfo> GetCitiesAsync()
    {
        return Database.Table<CityInfo>().ToList();
    }

    public List<Weather> GetMajorCitiesAsync()
    {
        return Database.Table<Weather>().ToList();
    }

    public CityInfo GetCityInfoByWeatherIdAsync(int WeatherId)
    {
        return Database.Table<CityInfo>()
                        .Where(ci => ci.Weather.First().Id == WeatherId)
                        .FirstOrDefault();
    }

    public async Task InsertCitiesFromJsonAsync(string cityInfoJsonPath)
    {
        string cityInfoJson = File.ReadAllText(cityInfoJsonPath);
        var cities = JsonConvert.DeserializeObject<List<CityInfo>>(cityInfoJson);

        if (cities != null)
        {
            //await Database.InsertAllAsync(cities);
            Database.InsertAll(cities);
        }
    }

    public async Task InsertMajorCitiesFromJsonAsync(string WeatherJsonPath)
    {
        string WeatherJson = File.ReadAllText(WeatherJsonPath);
        var weathers = JsonConvert.DeserializeObject<List<Weather>>(WeatherJson);

        if (weathers != null)
        {
            foreach (var weather in weathers)
            {
                Database.Insert(weather);
                var city = Database.Table<CityInfo>().FirstOrDefault(x => x.City == weather.Name);
                city.Weather.Add(weather);
                Database.UpdateWithChildren(city);
            }
        }
    }
    // Add methods to insert, update, delete records
}
