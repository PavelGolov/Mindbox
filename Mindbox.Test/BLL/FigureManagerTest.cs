using Moq;

namespace Mindbox.Test.BLL
{
    public class FigureManagerTest
    {
        private const double ValidSquare = 10;
        private const double InvalidSquare = 0;

        private IFigureManager _figureManager;
        private Mock<IFigure> _figure;

        [SetUp]
        public void Setup()
        {
            _figureManager = new FigureManager();
            _figure = new Mock<IFigure>();
        }

        [Test]
        public void GetSquare_ValidFigure_Success()
        {
            // Arrange
            double expectedSquare = ValidSquare;
            var isFigureValid = true;

            _figure.Setup(x => x.Square()).Returns(expectedSquare);
            _figure.Setup(x => x.isValid()).Returns(isFigureValid);

            // Act
            var actualSquare = _figureManager.GetSquare(_figure.Object);

            //Assert
            Assert.AreEqual(actualSquare, expectedSquare);
        }

        [Test]
        public void GetSquare_InvalidFigure_Exception()
        {
            // Arrange
            double expectedSquare = ValidSquare;
            var isFigureValid = false;

            _figure.Setup(x => x.Square()).Returns(expectedSquare);
            _figure.Setup(x => x.isValid()).Returns(isFigureValid);

            //Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => _figureManager.GetSquare(_figure.Object));
        }

        [Test]
        public void GetSquare_InvalidFigureSquare_Exception()
        {
            // Arrange
            double expectedSquare = InvalidSquare;
            var isFigureValid = true;

            _figure.Setup(x => x.Square()).Returns(expectedSquare);
            _figure.Setup(x => x.isValid()).Returns(isFigureValid);

            //Assert
            Assert.Throws<OverflowException>(() => _figureManager.GetSquare(_figure.Object));
        }

        [Test]
        public void GetSquare_NullFigure_Exception()
        {
            // Arrange
            IFigure figure = null;

            //Assert
            Assert.Throws<ArgumentNullException>(() => _figureManager.GetSquare(figure));
        }
    }
}