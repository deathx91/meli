using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Api.Models
{
    public class SatelliteData
    {
        public string Name { get; set; }

        public double Distance { get; set; }

        public string[] Message { get; set; }
    }
}