namespace Mindbox.Test.BLL
{
    public class CircleTest
    {
        [Test]
        public void Square_ValidRadius_Success()
        {
            // Arrange
            IFigure circle = new Circle(3);
            var expectedSquare = 9 * Math.PI;

            // Act
            var actualSquare = circle.Square();

            //Assert
            Assert.AreEqual(expectedSquare, actualSquare);
        }

        [Test]
        public void Ctor_InvalidRadius_Exception()
        {
            // Arrange
            var invalidRadiuses = new double[] { -1000, 0 };

            //Assert
            foreach (var radius in invalidRadiuses)
                Assert.Throws<ArgumentOutOfRangeException>(() => new Circle(radius));
        }
    }
}