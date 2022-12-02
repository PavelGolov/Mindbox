namespace Mindbox.Common
{
    public interface IGenericFigureManager
    {
        double GetSquare<T>(T figure) where T : IFigure;
    }
}
