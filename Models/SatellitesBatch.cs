using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Api.Models
{
    public class SatellitesBatch
    {
        public List<SatelliteData> Satellites { get; set; }
        public SatellitesBatch()
        {
            Satellites = new List<SatelliteData>();
        }
    }
}