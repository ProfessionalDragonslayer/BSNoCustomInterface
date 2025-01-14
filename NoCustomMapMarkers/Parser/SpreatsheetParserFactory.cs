using System.Reflection;

namespace BSNoCustomMapMarkers.Parser
{
    internal class SpreatsheetParserFactory
    {

        public static ISpreadsheetParser GetParser(NoCustomMapMarkersSettings settings)
        {
            string filePath = GetLocalPath(settings.FilePath);
            string extension = Path.GetExtension(filePath).ToLower();

            switch(extension)
            {
                case ".csv":
                    return new CsvParser() { Settings = settings, FilePath = filePath };
                default:
                    throw new NotImplementedException($"BSNoCustomMapMarkers: Parser not implemented for filetype {extension}");
            }
        }

        private static string GetLocalPath(string path)
        {
            if (File.Exists(path))
                return path;


            var assemblyDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            return(Path.Combine(assemblyDirectory == null ? String.Empty : assemblyDirectory, path));
        }
    }
}
