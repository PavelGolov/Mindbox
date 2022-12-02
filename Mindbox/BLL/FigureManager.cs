using Mindbox.Interfaces;

namespace Mindbox.BLL
{
    public class FigureManager : IFigureManager
    {
        public double GetSquare(IFigure figure)
        {
            if (figure is null)
                throw new ArgumentNullException();

            var square = figure.Square();

            if (square <= 0)
                throw new OverflowException();

            return square;
        }
    }
}
