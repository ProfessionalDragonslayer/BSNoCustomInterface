using BSNoCustomMapMarkers.Model;
using CsvHelper;
using CsvHelper.Configuration;
using Newtonsoft.Json;
using Noggog;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSNoCustomMapMarkers.Parser
{
    internal class CsvParser : ISpreadsheetParser
    {
        public required NoCustomMapMarkersSettings Settings {get; set; }

        public List<MapMarkerData> ParseDocument()
        {
            List<MapMarkerData> mapMarkers = [];

            using (var reader = new StreamReader(Settings.FilePath))
            using (var csvReader = new CsvReader(reader, new CsvConfiguration(CultureInfo.InvariantCulture) { Delimiter = ";", Encoding = Encoding.UTF8 }))
            {
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
