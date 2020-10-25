using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Api.Models
{
    public class Satellite
    {
        private string Name { get; set; }
        private Coordinates Location { get; set; }
        public Satellite(string name, Coordinates location)
        {
            Name = name;
            Location = location;
        }
        public string GetName() { return Name; }
        public Coordinates GetLocation() { return Location; }
    }
}