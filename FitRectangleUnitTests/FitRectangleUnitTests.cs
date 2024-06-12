using FitRectangle.Models;
using Rectangle = FitRectangle.Models.Rectangle;
using Point = FitRectangle.Models.Point;
using Color = FitRectangle.Models.Color;
using FitRectangle.Services;
using FitRectangle.Helpers;
using FitRectangle.Exceptions;

namespace FitRectangleUnitTests
{
    [TestFixture]
    public class ProcessRectangleTests
    {
        [Test]
        public void ProcessRectangle_NoSuitableSecondaryRectangles_ThrowsNoSuitableSecondaryRectanglesException()
        {
            // Arrange
            var parameters = new TaskParameters
            {
                MainRectangle = new Rectangle(new Point(0, 0), new Point(0, 10), new Point(10, 10), new Point(10, 0)),
                SecondaryRectangles = new List<Rectangle>
                {
                },
            };
            var processor = new RectangleProcessor(parameters, new ConsoleLogger());

            // Act and Assert
            Assert.Throws<NoSuitableSecondaryRectanglesException>(() =>
            {
                var result = processor.ProcessRectangles();
            });
        }

        [Test]
        public void ProcessRectangle_NoFiltration_ReturnsValidResult()
        {
            // Arrange
            var parameters = new TaskParameters
            {
                MainRectangle = new Rectangle(new Point(2, 2), new Point(2, 8), new Point(8, 8), new Point(8, 2)),
                SecondaryRectangles = new List<Rectangle>
                {
                    new Rectangle(new Point(1, 7), new Point(1, 9), new Point(3, 9), new Point(3, 7), Color.Green),
                    new Rectangle(new Point(3, 3), new Point(3, 5), new Point(7, 5), new Point(7, 3), Color.Purple),
                    new Rectangle(new Point(4, 2), new Point(4, 8), new Point(6, 8), new Point(6, 2), Color.Pink),
                    new Rectangle(new Point(7, 6), new Point(7, 7), new Point(9, 7), new Point(9, 6), Color.Pink)
                },
            };
            var processor = new RectangleProcessor(parameters, new ConsoleLogger());

            // Act
            var result = processor.ProcessRectangles();

            // Assert
            var expectedResultMainRectangle = new Rectangle(new Point(1, 2), new Point(1, 9), new Point(9, 9), new Point(9, 2));
            Assert.That(expectedResultMainRectangle.Equals(result.ResultMainRectangle));
        }

        [Test]
        public void ProcessRectangle_ExcludedPinkRectangles_ReturnsValidResult()
        {
            // Arrange
            var parameters = new TaskParameters
            {
                MainRectangle = new Rectangle(new Point(2, 2), new Point(2, 8), new Point(8, 8), new Point(8, 2)),
                SecondaryRectangles = new List<Rectangle>
                {
                    new Rectangle(new Point(1, 7), new Point(1, 9), new Point(3, 9), new Point(3, 7), Color.Green),
                    new Rectangle(new Point(3, 3), new Point(3, 5), new Point(7, 5), new Point(7, 3), Color.Purple),
                    new Rectangle(new Point(4, 2), new Point(4, 8), new Point(6, 8), new Point(6, 2), Color.Pink),
                    new Rectangle(new Point(7, 6), new Point(7, 7), new Point(9, 7), new Point(9, 6), Color.Pink),
                },
                ExcludedColors = new List<Color>() { Color.Pink }
            };
            var processor = new RectangleProcessor(parameters, new ConsoleLogger());

            // Act
            var result = processor.ProcessRectangles();

            // Assert
            var expectedResultMainRectangle = new Rectangle(new Point(1, 3), new Point(1, 9), new Point(7, 9), new Point(7, 3));
            Assert.That(expectedResultMainRectangle.Equals(result.ResultMainRectangle));
        }

        [Test]
        public void ProcessRectangle_ExcludedOutlyingRectangles_ReturnsValidResult()
        {
            // Arrange
            var parameters = new TaskParameters
            {
                MainRectangle = new Rectangle(new Point(2, 2), new Point(2, 8), new Point(8, 8), new Point(8, 2)),
                SecondaryRectangles = new List<Rectangle>
                {
                    new Rectangle(new Point(1, 7), new Point(1, 9), new Point(3, 9), new Point(3, 7), Color.Green),
                    new Rectangle(new Point(3, 3), new Point(3, 5), new Point(7, 5), new Point(7, 3), Color.Purple),
                    new Rectangle(new Point(4, 2), new Point(4, 8), new Point(6, 8), new Point(6, 2), Color.Pink),
                    new Rectangle(new Point(7, 6), new Point(7, 7), new Point(9, 7), new Point(9, 6), Color.Pink),
                },
                ExcludeOutsidePoints = true
            };
            var processor = new RectangleProcessor(parameters, new ConsoleLogger());

            // Act
            var result = processor.ProcessRectangles();

            // Assert
            var expectedResultMainRectangle = new Rectangle(new Point(3, 2), new Point(3, 8), new Point(7, 8), new Point(7, 2));
            Assert.That(expectedResultMainRectangle.Equals(result.ResultMainRectangle));
        }

        [Test]
        public void ProcessRectangle_ExcludedOutlyingAndPinkRectangles_ReturnsValidResult()
        {
            // Arrange
            var parameters = new TaskParameters
            {
                MainRectangle = new Rectangle(new Point(2, 2), new Point(2, 8), new Point(8, 8), new Point(8, 2)),
                SecondaryRectangles = new List<Rectangle>
                {
                    new Rectangle(new Point(1, 7), new Point(1, 9), new Point(3, 9), new Point(3, 7), Color.Green),
                    new Rectangle(new Point(3, 3), new Point(3, 5), new Point(7, 5), new Point(7, 3), Color.Purple),
                    new Rectangle(new Point(4, 2), new Point(4, 8), new Point(6, 8), new Point(6, 2), Color.Pink),
                    new Rectangle(new Point(7, 6), new Point(7, 7), new Point(9, 7), new Point(9, 6), Color.Pink),
                },
                ExcludeOutsidePoints = true,
                ExcludedColors = new List<Color>() { Color.Pink }
            };
            var processor = new RectangleProcessor(parameters, new ConsoleLogger());

            // Act
            var result = processor.ProcessRectangles();

            // Assert
            var expectedResultMainRectangle = new Rectangle(new Point(3, 3), new Point(3, 5), new Point(7, 5), new Point(7, 3));
            Assert.That(expectedResultMainRectangle.Equals(result.ResultMainRectangle));
        }
    }
}