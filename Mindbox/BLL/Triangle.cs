using Mindbox.Interfaces;

namespace Mindbox.BLL
{
    public class Triangle : ITriangle
    {
        private readonly double _firstSideLength;
        private readonly double _secondSideLength;
        private readonly double _thirdSideLength;

        public Triangle(double firstSideLength, double secondSideLength, double thirdSideLength)
        {
            if (firstSideLength <= 0 || secondSideLength <= 0 || thirdSideLength <= 0)
                throw new ArgumentOutOfRangeException();

            _firstSideLength = firstSideLength;
            _secondSideLength = secondSideLength;
            _thirdSideLength = thirdSideLength;
        }

        public bool IsRight()
        {
            var expectedHypotenuseLength = Max(Max(_firstSideLength, _secondSideLength), _thirdSideLength);

            double actualHypotenuseLength = 0;

            if (_firstSideLength == expectedHypotenuseLength)
                actualHypotenuseLength = GetHypotenuseLength(_secondSideLength, _thirdSideLength);

            if (_secondSideLength == expectedHypotenuseLength)
                actualHypotenuseLength = GetHypotenuseLength(_firstSideLength, _thirdSideLength);

            if (_thirdSideLength == expectedHypotenuseLength)
                actualHypotenuseLength = GetHypotenuseLength(_firstSideLength, _secondSideLength);

            return expectedHypotenuseLength == actualHypotenuseLength;
        }

        public double Square()
        {
            double semiperimeter = GetSemiperimeter(_firstSideLength, _secondSideLength, _thirdSideLength);
            return GetHeronSquare(_firstSideLength, _secondSideLength, _thirdSideLength, semiperimeter);
        }

        private double GetSemiperimeter(double a, double b, double c) => (a + b + c) / 2;

        private double GetHeronSquare(double a, double b, double c, double p) => Math.Sqrt(p * (p - a) * (p - b) * (p - c));

        private double Max(double a, double b) => a > b ? a : b;
        private double GetHypotenuseLength(double a, double b) => Math.Sqrt(a * a + b * b);
    }
}
