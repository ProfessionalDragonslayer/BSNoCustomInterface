namespace BSNoCustomMapMarkers
{
    public class NoCustomMapMarkersSettings
    {
        public string FilePath { get; set; } = @"BSMapMarkers.CSV";

        public bool GenerateCoMAPData { get; set; } = false;
        public int CustomMarkerRowsStart { get; set; } = 67;
    }
}
