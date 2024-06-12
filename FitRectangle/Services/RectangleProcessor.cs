using FitRectangle.Exceptions;
using FitRectangle.Helpers;
using FitRectangle.Models;

namespace FitRectangle.Services
{
    public interface ITaskResultLogger
    {
        public void Log(ProcessResults processResults);
    }

    public class RectangleProcessor
    {
        private readonly TaskParameters _parameters;
        private readonly ITaskResultLogger _logger;

        public RectangleProcessor(TaskParameters parameters, ITaskResultLogger logger)
        {
            _parameters = parameters;
            _logger = logger;
        }


        /// <summary>
        /// Filters secondary rectangles (removes according to parameters), refits MainRectangle to encapsulate all remaining rectangles.
        /// </summary>
        public ProcessResults ProcessRectangles()
        {
            var filteredRectangles = FilterRectangles(_parameters.SecondaryRectangles);

            if (filteredRectangles.Count == 0)
                throw new NoSuitableSecondaryRectanglesException();

            var mainRectangle = CalculateMainRectangle(filteredRectangles);

            var processResults = new ProcessResults() { ResultMainRectangle = mainRectangle, ResultSecondaryRectangles = filteredRectangles};

            _logger.Log(processResults);
            return processResults;
        }

        private List<Rectangle> FilterRectangles(List<Rectangle> rectangles)
        {
            if (rectangles.Count == 0)
                return rectangles;

            List<Rectangle> filteredRectangles = rectangles;

            if (_parameters.ExcludedColors.Any())
                filteredRectangles = FilterByColor(rectangles);

            if (_parameters.ExcludeOutsidePoints)
                filteredRectangles = FilterOutliers(filteredRectangles);

            return filteredRectangles;
        }
        private List<Rectangle> FilterOutliers(List<Rectangle> rectangles)
        {
            return rectangles.Where(rectangle => GeometryHelper.IsRectangleInside(_parameters.MainRectangle, rectangle)).ToList();
        }

        private List<Rectangle> FilterByColor(List<Rectangle> rectangles)
        {
            return rectangles.Where(r => !_parameters.ExcludedColors.Contains(r.Color)).ToList();
        }

        private Rectangle CalculateMainRectangle(List<Rectangle> rectangles)
        {
            var points = rectangles.SelectMany(r => new[] { r.TopLeft, r.TopRight, r.BotLeft, r.BotRight }).ToList();

            double minX = points.Min(p => p.X);
            double minY = points.Min(p => p.Y);
            double maxX = points.Max(p => p.X);
            double maxY = points.Max(p => p.Y);

            return new Rectangle(new Point(minX, minY), new Point(minX, maxY), new Point(maxX, maxY), new Point(maxX, minY));
        }
    }
}
