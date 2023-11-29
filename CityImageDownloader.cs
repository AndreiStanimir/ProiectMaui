using System;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

public static class CityImageDownloader
{
    private const string TeleportUrbanAreasApi = "https://api.teleport.org/api/urban_areas/";
    private const string TeleportCitiesApi = "https://api.teleport.org/api/cities/?search=";

    public static async Task<string> DownloadCityImageAsync(string cityName)
    {
        string citySlug = await GetCitySlugAsync(cityName);
        if (string.IsNullOrEmpty(citySlug))
        {
            throw new InvalidOperationException("City slug not found.");
        }

        string imageUrl = await GetCityImageUrlAsync(citySlug);
        if (string.IsNullOrEmpty(imageUrl))
        {
            throw new InvalidOperationException("Image URL not found.");
        }

        // Download and save the image
        using (var httpClient = new HttpClient())
        {
            var imageResponse = await httpClient.GetAsync(imageUrl);
            if (!imageResponse.IsSuccessStatusCode)
            {
                throw new InvalidOperationException("Could not download the image.");
            }

            using (var stream = await imageResponse.Content.ReadAsStreamAsync())
            {
                string localPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), cityName + ".jpg");

                using (var fileStream = File.Create(localPath))
                {
                    await stream.CopyToAsync(fileStream);
                }

                return localPath;
            }
        }
    }

    private static async Task<string> GetCitySlugAsync(string cityName)
    {
        using (var client = new HttpClient() { })
        {
            var response = await client.GetAsync($"{TeleportCitiesApi}{Uri.EscapeDataString(cityName)}&embed=city:search-results/city:item");
            if (!response.IsSuccessStatusCode)
            {
                throw new InvalidOperationException("Could not retrieve city information.");
            }

            var json = await response.Content.ReadAsStringAsync();
            var jObject = JObject.Parse(json);
            var cityItemLink = jObject["_embedded"]?["city:search-results"]?[0]?["_embedded"]?["city:item"]?["_links"]?["city:urban_area"]?["href"]?.ToString();

            if (!string.IsNullOrEmpty(cityItemLink))
            {
                return cityItemLink.Split('/').LastOrDefault();
            }

            return null;
        }
    }

    private static async Task<string> GetCityImageUrlAsync(string citySlug)
    {
        using (var client = new HttpClient())
        {
            var response = await client.GetAsync($"{TeleportUrbanAreasApi}slug:{citySlug}/images/");
            if (!response.IsSuccessStatusCode)
            {
                throw new InvalidOperationException("Could not retrieve city image.");
            }

            var json = await response.Content.ReadAsStringAsync();
            var jObject = JObject.Parse(json);
            var imageUrl = jObject["photos"]?[0]?["image"]?["web"]?.ToString();

            return imageUrl;
        }
    }
}
