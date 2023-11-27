namespace ProiectMaui
{
    public static class JsonFileReader
    {
        public static async Task<string> ReadJsonFileAsync(string fileName)
        {
            using StreamReader reader = new StreamReader(new FileStream(fileName, FileMode.Open));
            return reader.ReadToEnd();
            //var assembly = Assembly.GetExecutingAssembly();
            //var resourcePath = assembly.GetManifestResourceNames()
            //    .FirstOrDefault(name => name.EndsWith(fileName, StringComparison.OrdinalIgnoreCase));

            //if (resourcePath != null)
            //{
            //    using Stream stream = assembly.GetManifestResourceStream(resourcePath);
            //    using StreamReader reader = new StreamReader(stream);
            //    return await reader.ReadToEndAsync();
            //}
            //throw new FileNotFoundException(fileName);
            //return null;
        }
    }
}