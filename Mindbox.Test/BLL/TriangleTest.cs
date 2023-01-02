namespace Mindbox.Test.BLL
{
    public class TriangleTest
    {
        private const double RightTriangleSquare = 6;
        private const double NotRightTriangleSquare = 84;

        private ITriangle[] _rightTriangles;
        private ITriangle _notRightTriangle;

        [SetUp]
        public void Setup()
        {
            _rightTriangles = new Triangle[]
            {
            new Triangle(3, 4, 5),
            new Triangle(5, 4, 3),
            new Triangle(4, 5, 3),
            };

            _notRightTriangle = new Triangle(13, 14, 15);
        }

        [Test]
        public void Square_RightTriangles_Success()
        {
            //Assert
            foreach (var triangle in _rightTriangles)
                Assert.AreEqual(RightTriangleSquare, triangle.Square());
        }

        [Test]
        public void Square_NotRightTriangle_Success()
        {
            // Act
            var actualSquare = _notRightTriangle.Square();

            //Assert
            Assert.AreEqual(NotRightTriangleSquare, actualSquare);
        }

        [Test]
        public void IsRight_RightTriangles_Success()
        {
            //Assert
            foreach (var triangle in _rightTriangles)
                Assert.True(triangle.IsRight());
        }

        [Test]
        public void IsRight_NotRightTriangle_Failed()
        {
            // Act
            var isRightTriangle = _notRightTriangle.IsRight();

            //Assert
            Assert.False(isRightTriangle);
        }

        [Test]
        public void IsValid_NotRightTriangle_Success()
        {
            // Act
            var isValidTriangle = _notRightTriangle.isValid();

            //Assert
            Assert.True(isValidTriangle);
        }

        [Test]
        public void IsValid_RightTriangles_Success()
        {
            //Assert
            foreach (var triangle in _rightTriangles)
                Assert.True(triangle.isValid());
        }

        [Test]
        public void IsValid_NotPositiveSideLengths_Failed()
        {
            // Arrange
            var sides = new double[] { -1000, 0, 1000 };

            //Assert
            foreach (var a in sides)
                foreach (var b in sides)
                    foreach (var c in sides)
                    {
                        if (ArePositiveSides(a, b, c))
                            break;

                        Assert.False(new Triangle(a, b, c).isValid());
                    }
        }

        [Test]
        public void IsValid_NotExistTriangle_Failed()
        {
            // Arrange
            IFigure triangle = new Triangle(1, 1, 10);

            //Assert
            Assert.False(triangle.isValid());
        }

        private bool ArePositiveSides(double a, double b, double c) => a > 0 && b > 0 && c > 0;
    }
}