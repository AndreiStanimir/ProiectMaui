using System.Reflection;

public static class JsonFileReader
{
    public static async Task<string> ReadJsonFileAsync(string fileName)
    {
        var assembly = Assembly.GetExecutingAssembly();
        var resourcePath = assembly.GetManifestResourceNames()
            .FirstOrDefault(name => name.EndsWith(fileName, StringComparison.OrdinalIgnoreCase));

        if (resourcePath != null)
        {
            using Stream stream = assembly.GetManifestResourceStream(resourcePath);
            using StreamReader reader = new StreamReader(stream);
            return await reader.ReadToEndAsync();
        }
        throw new FileNotFoundException(fileName);
        return null;
    }
}