using Mindbox.Interfaces;

namespace Mindbox.BLL
{
    public class Circle : IFigure
    {
        private readonly double _radiusLength;
        public Circle(double radiusLength)
        {
            if (radiusLength <= 0)
                throw new ArgumentOutOfRangeException();

            _radiusLength = radiusLength;
        }

        public double Square()
        {
            return Math.PI * _radiusLength * _radiusLength;
        }
    }
}