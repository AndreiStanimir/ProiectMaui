using SQLite;
using System.Text.Json;

namespace ProiectMaui;

public class DatabaseContext
{
    private readonly SQLiteConnection Database;

    public DatabaseContext(string dbPath)
    {
        Database = new SQLiteConnection(dbPath, SQLiteOpenFlags.ReadWrite);
        Database.Trace = true;
        InitializeDatabaseAsync().Wait();
    }

    private async Task InitializeDatabaseAsync()
    {
        Database.DeleteAll<CityInfo>();
        Database.DeleteAll<MajorCity>();
        Database.CreateTables(CreateFlags.ImplicitIndex, typeof(CityInfo), typeof(MajorCity));
        // Optionally, include seed data or additional initialization here
        string mainDir = FileSystem.Current.AppDataDirectory;
        //string cityInfoJson = await JsonFileReader.ReadJsonFileAsync("C:\\Users\\andrei.stanimir\\source\\repos\\ProiectMaui\\Resources\\Raw\\city_region.json");
        //string majorCityJson = await JsonFileReader.ReadJsonFileAsync("C:\\Users\\andrei.stanimir\\source\\repos\\ProiectMaui\\Resources\\Raw\\major_cities.json");

        await InsertCitiesFromJsonAsync("C:\\Users\\andrei.stanimir\\source\\repos\\ProiectMaui\\Resources\\Raw\\city_region.json");
        await InsertMajorCitiesFromJsonAsync("C:\\Users\\andrei.stanimir\\source\\repos\\ProiectMaui\\Resources\\Raw\\major_cities.json");
    }

    public List<CityInfo> GetCitiesAsync()
    {
        return Database.Table<CityInfo>().ToList();
    }

    public List<MajorCity> GetMajorCitiesAsync()
    {
        return Database.Table<MajorCity>().ToList();
    }

    public CityInfo GetCityInfoByMajorCityIdAsync(int majorCityId)
    {
        return Database.Table<CityInfo>()
                        .Where(ci => ci.MajorCityId == majorCityId)
                        .FirstOrDefault();
    }

    public async Task InsertCitiesFromJsonAsync(string cityInfoJsonPath)
    {
        string cityInfoJson = File.ReadAllText(cityInfoJsonPath);
        var cities = JsonSerializer.Deserialize<List<CityInfo>>(cityInfoJson, new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        });

        if (cities != null)
        {
            //await Database.InsertAllAsync(cities);
            Database.InsertAll(cities);
        }
    }

    public async Task InsertMajorCitiesFromJsonAsync(string majorCityJsonPath)
    {
        string majorCityJson = File.ReadAllText(majorCityJsonPath);
        var majorCities = JsonSerializer.Deserialize<List<MajorCity>>(majorCityJson, new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        });

        if (majorCities != null)
        {
            Database.InsertAll(majorCities);
        }
    }
    // Add methods to insert, update, delete records
}
