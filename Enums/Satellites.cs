using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Api.Models;

namespace Api.Enums
{
    class Satellites
    {
        private Dictionary<string, Satellite> SatellitesDictionary = new Dictionary<string, Satellite>();
        public Satellites()
        {
            SatellitesDictionary.Add("Kenobi", new Satellite("Kenobi", new Coordinates(-500, -200)));
            SatellitesDictionary.Add("Skywalker", new Satellite("Skywalker", new Coordinates(100, -100)));
            SatellitesDictionary.Add("Sato", new Satellite("Sato", new Coordinates(500, 100)));
        }
        public Dictionary<string, Satellite> GetSatellites()
        {
            return SatellitesDictionary;
        }
    }
}