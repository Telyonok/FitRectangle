using System.Drawing;

namespace FitRectangle
{
    public class Rectangle
    {
        public Rectangle(Point topLeft, Point topRight, Point botRight, Point botLeft, Color color)
        {
            TopLeft = topLeft;
            TopRight = topRight;
            BotRight = botRight;
            BotLeft = botLeft;
            Color = color;
        }

        public Point TopLeft { get; set; }
        public Point TopRight { get; set; }
        public Point BotRight { get; set; }
        public Point BotLeft { get; set; }
        public Color Color { get; set; }
    }
}
