using SQLite;
using System.Text.Json;
/* Unmerged change from project 'ProiectMaui (net8.0-windows10.0.19041.0)'
Before:
using System.IO;
After:
using System.Text.Json;
*/

/* Unmerged change from project 'ProiectMaui (net8.0-maccatalyst)'
Before:
using System.IO;
After:
using System.Text.Json;
*/

/* Unmerged change from project 'ProiectMaui (net8.0-android)'
Before:
using System.IO;
After:
using System.Text.Json;
*/


namespace ProiectMaui;

public class DatabaseContext 
{
    private readonly SQLiteAsyncConnection Database;

    public DatabaseContext(string dbPath)
    {
        Database = new SQLiteAsyncConnection(dbPath);
        Database.Trace= true;
        InitializeDatabaseAsync().Wait();
    }

    private async Task InitializeDatabaseAsync()
    {
        
        await Database.CreateTablesAsync(CreateFlags.AllImplicit, typeof(CityInfo), typeof(MajorCity));
        // Optionally, include seed data or additional initialization here
        string cityInfoJson = await JsonFileReader.ReadJsonFileAsync("Data/city_region.json");
        string majorCityJson = await JsonFileReader.ReadJsonFileAsync("Data/major_cities.json");

        await InsertCitiesFromJsonAsync(cityInfoJson);
        await InsertMajorCitiesFromJsonAsync(majorCityJson);
    }

    public Task<List<CityInfo>> GetCitiesAsync()
    {
        return Database.Table<CityInfo>().ToListAsync();
    }

    public Task<List<MajorCity>> GetMajorCitiesAsync()
    {
        return Database.Table<MajorCity>().ToListAsync();
    }

    public Task<CityInfo> GetCityInfoByMajorCityIdAsync(int majorCityId)
    {
        return Database.Table<CityInfo>()
                        .Where(ci => ci.MajorCityId == majorCityId)
                        .FirstOrDefaultAsync();
    }

    public async Task InsertCitiesFromJsonAsync(string cityInfoJsonPath)
    {
        string cityInfoJson = File.ReadAllText(cityInfoJsonPath);
        var cities = JsonSerializer.Deserialize<List<CityInfo>>(cityInfoJson);

        if (cities != null)
        {
            await Database.InsertAllAsync(cities);
        }
    }

    public async Task InsertMajorCitiesFromJsonAsync(string majorCityJsonPath)
    {
        string majorCityJson = File.ReadAllText(majorCityJsonPath);
        var majorCities = JsonSerializer.Deserialize<List<MajorCity>>(majorCityJson);

        if (majorCities != null)
        {
            await Database.InsertAllAsync(majorCities);
        }
    }
    // Add methods to insert, update, delete records
}
