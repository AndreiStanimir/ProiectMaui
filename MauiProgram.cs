using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using ProiectMaui;
using Microsoft.Extensions.Logging;

namespace ProiectMaui
{
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
            builder.Services.AddDbContext<DatabaseContext>(options =>
                options.UseSqlite($"Data Source={databasePath}"));

            return builder.Build();
        }

        private static string GetDatabasePath(string databaseName)
        {
            // Define the folder path to store the database file
            string folderPath = FileSystem.AppDataDirectory;

            // Combine the folder path and database name
            return Path.Combine(folderPath, databaseName);
        }
    }
}