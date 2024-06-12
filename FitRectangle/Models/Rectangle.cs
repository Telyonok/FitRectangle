using FitRectangle.Helpers;

namespace FitRectangle.Models
{
    public class Rectangle
    {
        public Rectangle(Point botLeft, Point topLeft, Point topRight, Point botRight, Color color = Color.Green)
        {
            if (!GeometryHelper.DoPointsRepresentRectangle(botLeft, topLeft, topRight, botRight))
                throw new ArgumentException("Provided points do not represent a rectangle.");
            TopLeft = topLeft;
            TopRight = topRight;
            BotRight = botRight;
            BotLeft = botLeft;
            Color = color;
        }

        public override string ToString()
        {
            return  $"--------------------------Rectangle--------------------------\n" +
                    $"Color: {Color.ToString()}\n" +
                    $"Top Left: {TopLeft.ToString()}    Top Right: {TopRight.ToString()}\n" +
                    $"Bot Left: {BotLeft.ToString()}    Bot Right: {BotRight.ToString()}\n" +
                    $"-------------------------------------------------------------\n";
        }

        public override bool Equals(object? obj)
        {
            if (obj == null || GetType() != obj.GetType())
                return false;

            var other = (Rectangle)obj;

            return TopLeft.Equals(other.TopLeft) &&
                   TopRight.Equals(other.TopRight) &&
                   BotRight.Equals(other.BotRight) &&
                   BotLeft.Equals(other.BotLeft) &&
                   Color == other.Color;
        }

        public Point TopLeft { get; set; }
        public Point TopRight { get; set; }
        public Point BotRight { get; set; }
        public Point BotLeft { get; set; }
        public Color Color { get; set; }
    }
}
