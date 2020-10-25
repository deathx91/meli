using Api.Models;
using Api.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Caching;

namespace Api.Services
{
    public class TopSecretRepository
    {
        private Coordinates ShipCoordinates;
        private string ShipMessage;
        private static Satellites SatellitesDictionary = new Satellites();
        private Cache cache = new Cache();

        public TopSecretRepository() { }
        public Response GetSecret(object json)
        {
            SatellitesBatch satellites = Newtonsoft.Json.JsonConvert.DeserializeObject<SatellitesBatch>(json.ToString());
            bool validation = false;

            if (satellites != null && satellites.Satellites.Count == 3)
                foreach (SatelliteData sat in satellites.Satellites)
                {
                    validation = ValidateSatelliteData(sat);
                    if (!validation) break;
                }

            if (validation)
                Calculate(satellites.Satellites);

            return new Response((ShipCoordinates != null && ShipMessage != null) ? 200 : 404, ShipCoordinates, ShipMessage);
        }
        private bool ValidateSatelliteData(SatelliteData satellite)
        {
            if (satellite.Distance < 0)
                return false;
            if (string.Join(string.Empty, satellite.Message).Equals(string.Empty))
                return false;

            return true;
        }

        private void Calculate(List<SatelliteData> satellites)
        {
            CalculationRepository calc = new CalculationRepository();

            foreach (SatelliteData sat in satellites)
            {
                Satellite satFound = SatellitesDictionary.GetSatellites().First(x => x.Value.GetName().ToUpper().Equals(sat.Name.ToUpper())).Value;

                if (satFound != null)
                    calc.AddData(new CalculationData(satFound.GetLocation().GetX(), satFound.GetLocation().GetY(), sat.Distance, sat.Message));
            }

            ShipCoordinates = calc.CalculateCoordinates();
            ShipMessage = calc.CalculateMessage();
        }
        public Response SaveDataSplit(object json, string name)
        {
            SatellitesBatch satellites = (SatellitesBatch)(cache.Get("satellites"));

            SatelliteData data = new SatelliteData();
            data = Newtonsoft.Json.JsonConvert.DeserializeObject<SatelliteData>(json.ToString());
            data.Name = name;

            if (satellites != null)
            {
                int index = satellites.Satellites.FindIndex(x => x.Name.ToUpper().Equals(name.ToUpper()));
                if (index > -1)
                    satellites.Satellites.RemoveAt(index);
                satellites.Satellites.Add(data);
            }
            else
            {
                satellites = new SatellitesBatch();
                satellites.Satellites.Add(data);
            }
            cache.Insert("satellites", satellites);

            return new Response(200, null, null);
        }
        public Response GetDataSplit()
        {
            SatellitesBatch satellites = (SatellitesBatch)(cache.Get("satellites"));
            bool validation = false;

            if (satellites != null && satellites.Satellites.Count == 3)
                foreach (SatelliteData sat in satellites.Satellites)
                {
                    validation = ValidateSatelliteData(sat);
                    if (!validation) break;
                }

            if (validation)
                Calculate(satellites.Satellites);

            int intCode = (ShipCoordinates != null && ShipMessage != null) ? 200 : 404;
            return new Response(intCode, ShipCoordinates, (intCode == 404 ? "Falta información" : ShipMessage));
        }
    }
}