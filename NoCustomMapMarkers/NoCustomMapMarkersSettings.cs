namespace BSNoCustomMapMarkers
{
    public class NoCustomMapMarkersSettings
    {
        public string FilePath { get; set; } = @"D:\Modding\BS\MapMarkers.CSV";

        public bool GenerateCoMAPData { get; set; } = true;
        public int CustomMarkerRowsStart { get; set; } = 67;
    }
}
