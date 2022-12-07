using Mindbox.Interfaces;

namespace Mindbox.BLL
{
    public class Circle : IFigure
    {
        private readonly double r;

        public Circle(double r)
        {
            this.r = r;
        }

        public double Square()
        {
            return Math.PI * r * r;
        }

        public bool isValid() => r > 0;
    }
}