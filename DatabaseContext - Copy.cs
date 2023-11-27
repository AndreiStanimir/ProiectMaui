//using SQLite;
//using System.Text.Json;

//namespace ProiectMaui;

//public class DatabaseContext 
//{
//    private readonly SQLiteAsyncConnection Database;

//    public DatabaseContext(string dbPath)
//    {
//        Database = new SQLiteAsyncConnection(dbPath);
//        Database.Trace= true;
//        InitializeDatabaseAsync().Wait();
//    }

//    private async Task InitializeDatabaseAsync()
//    {

//        //await Database.CreateTablesAsync(CreateFlags.AllImplicit, typeof(CityInfo), typeof(Weather));
//        // Optionally, include seed data or additional initialization here
//        string mainDir = FileSystem.Current.AppDataDirectory;
//        //string cityInfoJson = await JsonFileReader.ReadJsonFileAsync("C:\\Users\\andrei.stanimir\\source\\repos\\ProiectMaui\\Resources\\Raw\\city_region.json");
//        //string WeatherJson = await JsonFileReader.ReadJsonFileAsync("C:\\Users\\andrei.stanimir\\source\\repos\\ProiectMaui\\Resources\\Raw\\major_cities.json");

//        await InsertCitiesFromJsonAsync("C:\\Users\\andrei.stanimir\\source\\repos\\ProiectMaui\\Resources\\Raw\\city_region.json");
//        await InsertMajorCitiesFromJsonAsync("C:\\Users\\andrei.stanimir\\source\\repos\\ProiectMaui\\Resources\\Raw\\major_cities.json");
//    }

//    public Task<List<CityInfo>> GetCitiesAsync()
//    {
//        return Database.Table<CityInfo>().ToListAsync();
//    }

//    public Task<List<Weather>> GetMajorCitiesAsync()
//    {
//        return Database.Table<Weather>().ToListAsync();
//    }

//    public Task<CityInfo> GetCityInfoByWeatherIdAsync(int WeatherId)
//    {
//        return Database.Table<CityInfo>()
//                        .Where(ci => ci.WeatherId == WeatherId)
//                        .FirstOrDefaultAsync();
//    }

//    public async Task InsertCitiesFromJsonAsync(string cityInfoJsonPath)
//    {
//        string cityInfoJson = File.ReadAllText(cityInfoJsonPath);
//        var cities = JsonSerializer.Deserialize<List<CityInfo>>(cityInfoJson, new JsonSerializerOptions
//        {
//            PropertyNameCaseInsensitive = true
//        });

//        if (cities != null)
//        {
//            //await Database.InsertAllAsync(cities);
//            await Database.InsertAllAsync(cities);
//        }
//    }

//    public async Task InsertMajorCitiesFromJsonAsync(string WeatherJsonPath)
//    {
//        string WeatherJson = File.ReadAllText(WeatherJsonPath);
//        var majorCities = JsonSerializer.Deserialize<List<Weather>>(WeatherJson, new JsonSerializerOptions
//        {
//            PropertyNameCaseInsensitive = true
//        });

//        if (majorCities != null)
//        {
//            await Database.InsertAllAsync(majorCities);
//        }
//    }
//    // Add methods to insert, update, delete records
//}
