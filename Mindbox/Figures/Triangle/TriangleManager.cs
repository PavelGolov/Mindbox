using Mindbox.Common;

namespace Mindbox.Figures.Triangle
{
    public class TriangleManager : FigureManager<Triangle>, ITriangleManager
    {
        protected override bool IsValid(Triangle figure)
        {
            var areSidesPositive = figure.A > 0 && figure.B > 0 && figure.C > 0;
            var isTriangleExist = figure.A + figure.B > figure.C && figure.A + figure.C > figure.B && figure.B + figure.C > figure.A;
            return areSidesPositive && isTriangleExist;
        }

        protected override double Square(Triangle figure)
        {
            double semiperimeter = GetSemiperimeter(figure.A, figure.B, figure.C);
            return GetHeronSquare(figure.A, figure.B, figure.C, semiperimeter);
        }
        public bool IsRight(Triangle figure)
        {
            var maxSide = Max(figure.A, figure.B, figure.C);
            
            if (figure.A == maxSide)
                return IsRight(figure.B, figure.C, maxSide);

            if (figure.B == maxSide)
                return IsRight(figure.A, figure.C, maxSide);

            return IsRight(figure.A, figure.B, maxSide);
        }

        private bool IsRight(double a, double b, double maxSide)
        {
            var hypotenuse = GetHypotenuse(a, b);

            return maxSide == hypotenuse;
        }

        private double Max(double a, double b) => a > b ? a : b;

        private double Max(double a, double b, double c) => Max(Max(a, b), c);

        private double GetHypotenuse(double a, double b) => Math.Sqrt(a * a + b * b);

        private double GetSemiperimeter(double a, double b, double c) => (a + b + c) / 2;

        private double GetHeronSquare(double a, double b, double c, double p) => Math.Sqrt(p * (p - a) * (p - b) * (p - c));
    }
}