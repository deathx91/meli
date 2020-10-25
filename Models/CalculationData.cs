using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Api.Models
{
    public class CalculationData
    {
        private double X;
        private double Y;
        private double Distance;
        private string[] Message;
        public CalculationData(double x, double y, double distance, string[] message)
        {
            X = x;
            Y = y;
            Distance = distance;
            Message = message;
        }
        public double GetX() { return X; }
        public double GetY() { return Y; }
        public double GetDistance() { return Distance; }
        public string[] GetMessage() { return Message; }
    }
}