namespace FitRectangle.Exceptions
{
    public class NoSuitableSecondaryRectanglesException : Exception
    {
        public NoSuitableSecondaryRectanglesException() : base($"There were no secondary rectangles remaining after filtration to complete the task.") { }
    }
}
