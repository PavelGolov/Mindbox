using Mindbox.Figures.Triangle;

namespace Mindbox.Test.Figures
{
    public class TriangleManagerTest
    {
        private const double RightTriangleSquare = 6;
        private const double NotRightTriangleSquare = 84;

        private Triangle[] _rightTriangles;
        private Triangle _notRightTriangle;

        private readonly ITriangleManager _triangleManager;

        public TriangleManagerTest()
        {
            _triangleManager = new TriangleManager();
        }

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
                Assert.AreEqual(RightTriangleSquare, _triangleManager.GetSquare(triangle));
        }

        [Test]
        public void Square_NotRightTriangle_Success()
        {
            // Act
            var actualSquare = _triangleManager.GetSquare(_notRightTriangle);

            //Assert
            Assert.AreEqual(NotRightTriangleSquare, actualSquare);
        }

        [Test]
        public void IsRight_RightTriangles_Success()
        {
            //Assert
            foreach (var triangle in _rightTriangles)
                Assert.True(_triangleManager.IsRight(triangle));
        }

        [Test]
        public void IsRight_NotRightTriangle_Failed()
        {
            // Act
            var isRightTriangle = _triangleManager.IsRight(_notRightTriangle);

            //Assert
            Assert.False(isRightTriangle);
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

                        Assert.Throws<ArgumentOutOfRangeException>(() => _triangleManager.GetSquare(new Triangle(a, b, c)));
                    }
        }

        [Test]
        public void IsValid_NotExistTriangle_Failed()
        {
            // Arrange
            Triangle triangle = new Triangle(1, 1, 10);

            //Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => _triangleManager.GetSquare(triangle));
        }


        [Test]
        public void GetSquare_NullFigure_Exception()
        {
            // Arrange
            Triangle figure = null;

            //Assert
            Assert.Throws<ArgumentNullException>(() => _triangleManager.GetSquare(figure));
        }

        private bool ArePositiveSides(double a, double b, double c) => a > 0 && b > 0 && c > 0;
    }
}