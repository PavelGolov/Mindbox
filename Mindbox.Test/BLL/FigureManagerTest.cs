using Moq;

namespace Mindbox.Test.BLL
{
    public class FigureManagerTest
    {
        private IFigureManager figureManager;
        private Mock<IFigure> figure;

        [SetUp]
        public void Setup()
        {
            figureManager = new FigureManager();
            figure = new Mock<IFigure>();
        }

        [Test]
        public void GetSquare_ValidFigureSquare_Success()
        {
            // Arrange
            double expectedSquare = 10;
            figure.Setup(x => x.Square()).Returns(expectedSquare);

            // Act
            var actualSquare = figureManager.GetSquare(figure.Object);

            //Assert
            Assert.AreEqual(actualSquare, expectedSquare);
        }

        [Test]
        public void GetSquare_InvalidFigureSquare_Exception()
        {
            // Arrange
            double squareResult = 0;
            figure.Setup(x => x.Square()).Returns(squareResult);

            //Assert
            Assert.Throws<OverflowException>(() => figureManager.GetSquare(figure.Object));
        }

        [Test]
        public void GetSquare_NullFigure_Exception()
        {
            // Arrange
            IFigure figure = null;

            //Assert
            Assert.Throws<ArgumentNullException>(() => figureManager.GetSquare(figure));
        }
    }
}