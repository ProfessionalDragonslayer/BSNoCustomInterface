using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSNoCustomMapMarkers.Parser
{
    internal class SpreatsheetParserFactory
    {

        public static ISpreadsheetParser GetParser(NoCustomMapMarkersSettings settings)
        {
            string extension = Path.GetExtension(settings.FilePath).ToLower();

            switch(extension)
            {
                case ".csv":
                    return new CsvParser() { Settings = settings };
                default:
                    throw new NotImplementedException($"BSNoCustomMapMarkers: Parser not implemented for filetype {extension}");
            }
        }
    }
}
