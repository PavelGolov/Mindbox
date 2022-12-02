using Mindbox.Common;
using Mindbox.Figures.Circle;

namespace Mindbox.Test.Figures
{
    public class CircleManagerTest
    {
        private const double ValidRadius = 3;
        private readonly IFigureManager<Circle> _circleManager;

        public CircleManagerTest()
        {
            _circleManager = new CircleManager();
        }

        [Test]
        public void GetSquare_ValidRadius_Success()
        {
            // Arrange
            var r = ValidRadius;
            var circle = new Circle(r);
            var expectedSquare = r * r * Math.PI;

            // Act
            var actualSquare = _circleManager.GetSquare(circle);

            //Assert
            Assert.AreEqual(expectedSquare, actualSquare);
        }

        [Test]
        public void GetSquare_NotPositiveRadius_Failed()
        {
            // Arrange
            var radiuses = new double[] { -1000, 0 };

            //Assert
            foreach (var radius in radiuses)
                Assert.Throws<ArgumentOutOfRangeException>(() => _circleManager.GetSquare(new Circle(radius)));
        }

        [Test]
        public void GetSquare_NullFigure_Exception()
        {
            // Arrange
            Circle figure = null;

            //Assert
            Assert.Throws<ArgumentNullException>(() => _circleManager.GetSquare(figure));
        }
    }
}