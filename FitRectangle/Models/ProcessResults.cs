namespace FitRectangle.Models
{
    public class ProcessResults
    {
        public Rectangle ResultMainRectangle { get; set; }
        public List<Rectangle> ResultSecondaryRectangles { get; set; } = new List<Rectangle>();
    }
}
