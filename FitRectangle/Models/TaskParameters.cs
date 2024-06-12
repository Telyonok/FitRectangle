using System.Drawing;

namespace FitRectangle.Models
{
    public class TaskParameters
    {
        public Rectangle MainRectangle { get; set; }
        public List<Rectangle> SecondaryRectangles { get; set; } = new List<Rectangle>();
        public bool ExcludeOutsidePoints { get; set; } = false;  // If ExcludeOutsidePoints == True, all rectangles that are not whithin the original MainRectangle will be excluded.
        public List<Color> ExcludedColors { get; set; } = new List<Color>();
    }
}
