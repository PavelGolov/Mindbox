using Mindbox.Common;
using Mindbox.Figures.Circle;
using Mindbox.Figures.Triangle;
using Moq;

namespace Mindbox.Test.Common
{
    public class GenericFigureManagerTest
    {
        private readonly IFigureManager<Circle> _circleManager;
        private readonly ITriangleManager _triangleManager;
        private readonly IGenericFigureManager _genericFigureManager;

        public GenericFigureManagerTest()
        {
            _circleManager = new CircleManager();
            _triangleManager = new TriangleManager();

            var figureManagers = new IFigureManager[] { _circleManager, _triangleManager };
            _genericFigureManager = new GenericFigureManager(figureManagers);
        }

        [Test]
        public void GetSquare_Circle_Success()
        {
            // Arrange
            var circle = new Circle(3);
            var expectedSquare = _circleManager.GetSquare(circle);

            // Act
            var actualSquare = _genericFigureManager.GetSquare(circle);

            //Assert
            Assert.AreEqual(expectedSquare, actualSquare);
        }

        [Test]
        public void GetSquare_Triangle_Success()
        {
            // Arrange
            var triangle = new Triangle(3, 4, 5);
            var expectedSquare = _triangleManager.GetSquare(triangle);

            // Act
            var actualSquare = _genericFigureManager.GetSquare(triangle);

            //Assert
            Assert.AreEqual(expectedSquare, actualSquare);
        }

        [Test]
        public void GetSquare_InvalidFigure_Success()
        {
            // Arrange
            var invalidFigure = new Mock<IFigure>().Object;

            //Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => _genericFigureManager.GetSquare(invalidFigure));
        }
    }
}