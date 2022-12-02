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
        public void Ctor_InvalidSideLengths_Exception()
        {
            // Arrange
            var sideLengths = new double[] { -1000, 0, 1000 };

            //Assert
            foreach (var firstSideLength in sideLengths)
                foreach (var secondSideLength in sideLengths)
                    foreach (var thirdSideLength in sideLengths)
                    {
                        if (firstSideLength > 0 && secondSideLength > 0 && thirdSideLength > 0)
                            break;

                        Assert.Throws<ArgumentOutOfRangeException>(() => new Triangle(firstSideLength, secondSideLength, thirdSideLength));
                    }
        }
    }
}