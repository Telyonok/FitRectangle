using FitRectangle.Models;
using Rectangle = FitRectangle.Models.Rectangle;
using Point = FitRectangle.Models.Point;
using Color = FitRectangle.Models.Color;
using FitRectangle.Services;
using FitRectangle.Helpers;

var parameters = new TaskParameters
{
    MainRectangle = new Rectangle(new Point(0, 0), new Point(0, 10), new Point(10, 10), new Point(10, 0)),
    SecondaryRectangles = new List<Rectangle>
    {
        new Rectangle(new Point(7, 7), new Point(7, 15), new Point(8, 15), new Point(8, 7), Color.Green),
        new Rectangle(new Point(5, 5), new Point(5, 6), new Point(6, 6), new Point(6, 5), Color.Purple),
        new Rectangle(new Point(4, 5), new Point(4, 6), new Point(6, 6), new Point(6, 5), Color.Green),
        new Rectangle(new Point(3, 3), new Point(3, 10), new Point(15, 10), new Point(15, 3), Color.Pink),
    },
    ExcludeOutsidePoints = true,
    ExcludedColors = new List<Color> { Color.Purple, Color.Green }
};

var processor = new RectangleProcessor(parameters, new ConsoleLogger());
var result = processor.ProcessRectangles();