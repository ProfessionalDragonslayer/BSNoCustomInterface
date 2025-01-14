using BSNoCustomMapMarkers.Model;
using CsvHelper;
using CsvHelper.Configuration;
using Noggog;
using System.Globalization;
using System.Text;

namespace BSNoCustomMapMarkers.Parser
{
    internal class CsvParser : ISpreadsheetParser
    {
        public required NoCustomMapMarkersSettings Settings {get; set; }

        public List<MapMarkerData> ParseDocument()
        {
            List<MapMarkerData> mapMarkers = [];

            var exactPath = Path.GetFullPath(Settings.FilePath);

            if (!File.Exists(exactPath))
            {
                Console.WriteLine($"Failed to find map marker config file: {exactPath}");
                return mapMarkers;
            } 

            using (var reader = new StreamReader(exactPath))
            using (var csvReader = new CsvReader(reader, new CsvConfiguration(CultureInfo.InvariantCulture) { Delimiter = ";", Encoding = Encoding.UTF8 }))
            {
                Console.WriteLine($"Read from map marker config file: {exactPath}");
                csvReader.Read();
                csvReader.ReadHeader();

                while (csvReader.Read())
                {
                    var mapMarker = new MapMarkerData()
                    {
                        TNAM = csvReader.GetField<int>(@"TNAM #"),
                        MarkerName = csvReader.GetField("Marker Name"),
                        Province = csvReader.GetField("Province"),
                        Type = csvReader.GetField("Type"),
                        ArtComplete = csvReader.GetField<bool>("Art Complete"),
                        MergedToSWF = csvReader.GetField<bool>("Merged to hudmenu and mapMarkerArt SWFs"),
                        Scale = csvReader.GetField<decimal>("Scale")
                    };

                    if (mapMarker.TNAM >= Settings.CustomMarkerRowsStart)
                    {
                        mapMarker.NonCustomMarkerName = csvReader.GetField("Non-Custom Marker Name");
                        if (!mapMarker.NonCustomMarkerName.IsNullOrEmpty())
                            mapMarker.NonCustomMarker = mapMarkers.Where(m => m.MarkerName == mapMarker.NonCustomMarkerName).FirstOrDefault();
                        mapMarker.MergedToComap = csvReader.GetField<bool>("Merged to CoMAP Resource File");
                        mapMarker.CoMAPFile = csvReader.GetField("CoMAP File");
                        mapMarker.CoMAPShape = csvReader.GetField(@"CoMAP Shape#");
                        mapMarker.CoMAPIconName = csvReader.GetField("CoMAP iconName");
                    }

                    mapMarkers.Add(mapMarker);
                }
            }

            return mapMarkers;
        }
    }
}
