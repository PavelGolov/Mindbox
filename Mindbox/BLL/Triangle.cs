using Mindbox.Interfaces;

namespace Mindbox.BLL
{
    public class Triangle : ITriangle
    {
        private readonly double a;
        private readonly double b;
        private readonly double c;

        public Triangle(double a, double b, double c)
        {
            this.a = a;
            this.b = b;
            this.c = c;
        }

        public bool IsRight()
        {
            var maxSide = Max(Max(a, b), c);

            double hypotenuse = 0;

            if (a == maxSide)
                hypotenuse = GetHypotenuse(b, c);

            if (b == maxSide)
                hypotenuse = GetHypotenuse(a, c);

            if (c == maxSide)
                hypotenuse = GetHypotenuse(a, b);

            return maxSide == hypotenuse;
        }

        public double Square()
        {
            double semiperimeter = GetSemiperimeter(a, b, c);
            return GetHeronSquare(a, b, c, semiperimeter);
        }

        public bool isValid()
        {
            var areSidesPositive = a > 0 && b > 0 && c > 0;
            var isTriangleExist = a + b > c && a + c > b && b + c > a;
            return areSidesPositive && isTriangleExist;
        }

        private double Max(double a, double b) => a > b ? a : b;

        private double GetHypotenuse(double a, double b) => Math.Sqrt(a * a + b * b);

        private double GetSemiperimeter(double a, double b, double c) => (a + b + c) / 2;

        private double GetHeronSquare(double a, double b, double c, double p) => Math.Sqrt(p * (p - a) * (p - b) * (p - c));
    }
}