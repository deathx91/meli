namespace Api.Models
{
    public class Coordinates
    {
        private double X { get; set; }
        private double Y { get; set; }
        public Coordinates(double x, double y)
        {
            X = x;
            Y = y;
        }
        public double GetX() { return X; }
        public double GetY() { return Y; }
    }
}