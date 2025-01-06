using Noggog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSNoCustomMapMarkers
{
    public class NoCustomMapMarkersSettings
    {
        public string FilePath { get; set; } = @"D:\Modding\BS\MapMarkers.CSV";

        public bool GenerateCoMAPData { get; set; } = true;
        public int CustomMarkerRowsStart { get; set; } = 67;
    }
}
