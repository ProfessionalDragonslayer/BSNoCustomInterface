namespace BSNoCustomMapMarkers.Model
{
    internal class MapMarkerData
    {
        public int TNAM { get; set; }
        public string? MarkerName { get; set; }
        public string? Province { get; set; }
        public string? Type { get; set; }
        public bool ArtComplete { get; set; }
        public bool MergedToSWF { get; set; } 
        public string? NonCustomMarkerName { get; set; }
        public bool MergedToComap { get; set; }
        public string? CoMAPFile { get; set; }
        public string? CoMAPShape { get; set; }
        public string? CoMAPIconName { get; set; }
        public decimal Scale { get; set; }
        public MapMarkerData? NonCustomMarker { get; set; }

        public MapMarkerData()
        {
        }
    }
}
