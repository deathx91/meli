﻿namespace Api.Models
{
    public class Coordinates
    {
        public double X { get; set; }
        public double Y { get; set; }
        public Coordinates(double x, double y)
        {
            X = x;
            Y = y;
        }
        public double GetX() { return X; }
        public double GetY() { return Y; }
    }
}