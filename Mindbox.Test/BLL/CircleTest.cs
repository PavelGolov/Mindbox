namespace Mindbox.Test.BLL
{
    public class CircleTest
    {
        private const double ValidRadius = 3;

        [Test]
        public void Square_ValidRadius_Success()
        {
            // Arrange
            var r = ValidRadius;
            IFigure circle = new Circle(r);
            var expectedSquare = r * r * Math.PI;

            // Act
            var actualSquare = circle.Square();

            //Assert
            Assert.AreEqual(expectedSquare, actualSquare);
        }

        [Test]
        public void IsValid_ValidRadius_Success()
        {
            // Arrange
            IFigure circle = new Circle(ValidRadius);

            // Act
            var isValid = circle.isValid();

            //Assert
            Assert.True(isValid);
        }

        [Test]
        public void IsValid_NotPositiveRadius_Failed()
        {
            // Arrange
            var radiuses = new double[] { -1000, 0 };
            IFigure circle = new Circle(0);

            //Assert
            foreach (var radius in radiuses)
                Assert.False(new Circle(radius).isValid());
        }
    }
}