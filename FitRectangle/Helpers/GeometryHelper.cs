using FitRectangle.Models;

namespace FitRectangle.Helpers
{
    public static class GeometryHelper
    {
        public static bool IsRectangleInside(Rectangle mainRectangle, Rectangle rectangle)
        {
            bool topLeftIsInside = rectangle.TopLeft.X >= mainRectangle.TopLeft.X && rectangle.TopLeft.Y <= mainRectangle.TopLeft.Y;

            bool topRightIsInside = rectangle.TopRight.X <= mainRectangle.TopRight.X && rectangle.TopRight.Y <= mainRectangle.TopRight.Y;

            bool bottomRightIsInside = rectangle.BotRight.X <= mainRectangle.BotRight.X && rectangle.BotRight.Y >= mainRectangle.BotRight.Y;

            bool bottomLeftIsInside = rectangle.BotLeft.X >= mainRectangle.BotLeft.X && rectangle.BotLeft.Y >= mainRectangle.BotLeft.Y;

            return topLeftIsInside && topRightIsInside && bottomRightIsInside && bottomLeftIsInside;
        }

        public static bool DoPointsRepresentRectangle(Point botLeft, Point topLeft, Point topRight, Point botRight)
        {
            return (topLeft.X == botLeft.X && topRight.X == botRight.X &&
                    topLeft.Y == topRight.Y && botLeft.Y == botRight.Y && 
                    topLeft.Y > botLeft.Y && topRight.Y > botRight.Y);
        }
    }
}
