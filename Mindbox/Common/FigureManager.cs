namespace Mindbox.Common
{
    public abstract class FigureManager<TFigure> : IFigureManager<TFigure>
        where TFigure : IFigure
    {
        public double GetSquare(TFigure figure)
        {
            if (figure is null)
                throw new ArgumentNullException();

            if (!IsValid(figure))
                throw new ArgumentOutOfRangeException();

            var square = Square(figure);

            if (square <= 0)
                throw new OverflowException();

            return square;
        }

        protected abstract bool IsValid(TFigure figure);

        protected abstract double Square(TFigure figure);
    }
}