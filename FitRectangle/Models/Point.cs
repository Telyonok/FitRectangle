namespace FitRectangle.Models
{
    public class Point
    {
        public Point(double x, double y)
        {
            X = x; Y = y;
        }

        public override string ToString()
        {
            return  $"X:{X} Y:{Y}";
        }

        public override bool Equals(object? obj)
        {
            if (obj == null || GetType() != obj.GetType())
                return false;

            var other = (Point)obj;

            return X == other.X && Y == other.Y;
        }

        public double X { get; set; }
        public double Y { get; set; }
    }
}
