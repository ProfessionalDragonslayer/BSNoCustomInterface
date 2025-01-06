using BSNoCustomMapMarkers.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSNoCustomMapMarkers.Parser
{
    internal interface ISpreadsheetParser
    {
        public NoCustomMapMarkersSettings Settings { get; set; }

        public List<MapMarkerData> ParseDocument();
    }
}
