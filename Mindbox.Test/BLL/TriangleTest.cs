namespace Mindbox.Test.BLL
{
    public class TriangleTest
    {
        private const double RightTriangleSquare = 6;
        private const double NotRightTriangleSquare = 84;

        private ITriangle rightTriangle;
        private ITriangle notRightTriangle;

        [SetUp]
        public void Setup()
        {
            rightTriangle = new Triangle(3, 4, 5);
            notRightTriangle = new Triangle(13, 14, 15);
        }

        [Test]
        public void Square_RightTriangle_Success()
        {
            // Act
            var actualSquare = rightTriangle.Square();

            //Assert
            Assert.AreEqual(RightTriangleSquare, actualSquare);
        }

        [Test]
        public void Square_NotRightTriangle_Success()
        {
            // Act
            var actualSquare = notRightTriangle.Square();

            //Assert
            Assert.AreEqual(NotRightTriangleSquare, actualSquare);
        }

        [Test]
        public void IsRight_RightTriangle_Success()
        {
            // Act
            var isRightTriangle = rightTriangle.IsRight();

            //Assert
            Assert.True(isRightTriangle);
        }

        [Test]
        public void IsRight_NotRightTriangle_Failed()
        {
            // Act
            var isRightTriangle = notRightTriangle.IsRight();

            //Assert
            Assert.False(isRightTriangle);
        }

        [Test]
        public void IsValid_NotRightTriangle_Success()
        {
            // Act
            var isValidTriangle = notRightTriangle.isValid();

            //Assert
            Assert.True(isValidTriangle);
        }

        [Test]
        public void IsValid_RightTriangle_Success()
        {
            // Act
            var isValidTriangle = rightTriangle.isValid();

            //Assert
            Assert.True(isValidTriangle);
        }

        [Test]
        public void IsValid_NotPositiveSideLengths_Exception()
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
        public void IsValid_NotExistTriangle_Exception()
        {
            // Arrange
            IFigure triangle = new Triangle(1, 1, 10);

            //Assert
            Assert.False(triangle.isValid());
        }

        private bool ArePositiveSides(double a, double b, double c) => a > 0 && b > 0 && c > 0;
    }
}