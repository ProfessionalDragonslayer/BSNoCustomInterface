using BSNoCustomMapMarkers.Model;

namespace BSNoCustomMapMarkers.Parser
{
    internal interface ISpreadsheetParser
    {
        public NoCustomMapMarkersSettings Settings { get; set; }

        public List<MapMarkerData> ParseDocument();
    }
}
