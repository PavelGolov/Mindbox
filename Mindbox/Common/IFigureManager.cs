namespace Mindbox.Common
{
    public interface IFigureManager<TFigure> : IFigureManager
        where TFigure : IFigure
    {
        public double GetSquare(TFigure figure);
    }

    public interface IFigureManager
    {
    }
}