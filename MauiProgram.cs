
/* Unmerged change from project 'ProiectMaui (net8.0-windows10.0.19041.0)'
Before:
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using ProiectMaui;
After:
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
*/

/* Unmerged change from project 'ProiectMaui (net8.0-maccatalyst)'
Before:
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using ProiectMaui;
After:
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
*/

/* Unmerged change from project 'ProiectMaui (net8.0-android)'
Before:
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using ProiectMaui;
After:
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
*/
using Microsoft.Extensions.Logging;

namespace ProiectMaui;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>()
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
            });

#if DEBUG
        builder.Logging.AddDebug();
#endif

        // Configure the database path
        string databasePath = GetDatabasePath("db_cities.db");

        // Register your database context
        builder.Services.AddSingleton(new DatabaseContext(databasePath));
        var app = builder.Build();
        //app.MainPage = new StartupPage()
        return app;
    }

    private static string GetDatabasePath(string databaseName)
    {
        // Define the folder path to store the database file
        string folderPath = "C:\\Users\\andrei.stanimir\\source\\repos\\ProiectMaui\\";//FileSystem.AppDataDirectory;

        // Combine the folder path and database name
        return Path.Combine(folderPath, databaseName);
    }
}