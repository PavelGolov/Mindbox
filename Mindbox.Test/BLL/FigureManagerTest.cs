using Moq;

namespace Mindbox.Test.BLL
{
    public class FigureManagerTest
    {
        private const double ValidSquare = 10;
        private const double InvalidSquare = 0;

        private IFigureManager figureManager;
        private Mock<IFigure> figure;

        [SetUp]
        public void Setup()
        {
            figureManager = new FigureManager();
            figure = new Mock<IFigure>();
        }

        [Test]
        public void GetSquare_ValidFigure_Success()
        {
            // Arrange
            double expectedSquare = ValidSquare;
            var isFigureValid = true;

            figure.Setup(x => x.Square()).Returns(expectedSquare);
            figure.Setup(x => x.isValid()).Returns(isFigureValid);

            // Act
            var actualSquare = figureManager.GetSquare(figure.Object);

            //Assert
            Assert.AreEqual(actualSquare, expectedSquare);
        }

        [Test]
        public void GetSquare_InvalidFigure_Exception()
        {
            // Arrange
            double expectedSquare = ValidSquare;
            var isFigureValid = false;

            figure.Setup(x => x.Square()).Returns(expectedSquare);
            figure.Setup(x => x.isValid()).Returns(isFigureValid);

            //Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => figureManager.GetSquare(figure.Object));
        }

        [Test]
        public void GetSquare_InvalidFigureSquare_Exception()
        {
            // Arrange
            double expectedSquare = InvalidSquare;
            var isFigureValid = true;

            figure.Setup(x => x.Square()).Returns(expectedSquare);
            figure.Setup(x => x.isValid()).Returns(isFigureValid);

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