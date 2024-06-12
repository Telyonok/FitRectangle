using FitRectangle.Models;
using FitRectangle.Services;

namespace FitRectangle.Helpers
{
    public class ConsoleLogger : ITaskResultLogger
    {
        public void Log(ProcessResults processResults)
        {
            Console.WriteLine($"Main rectangle (result state):\n{processResults.ResultMainRectangle.ToString()}");
            Console.WriteLine($"Secondary rectangles (remaining after filtration):");
            foreach (var secondaryRectangle in processResults.ResultSecondaryRectangles)
                Console.WriteLine(secondaryRectangle.ToString() + '\n');
        }
    }
}
