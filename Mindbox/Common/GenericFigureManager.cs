namespace Mindbox.Common
{
    public class GenericFigureManager : IGenericFigureManager
    {
        private IEnumerable<IFigureManager> _figureManagers;

        public GenericFigureManager(IEnumerable<IFigureManager> figureManagers)
        {
            _figureManagers = figureManagers;
        }

        public double GetSquare<T>(T figure)
            where T : IFigure
        {
            var figureManagers = _figureManagers.OfType<IFigureManager<T>>();

            if (!figureManagers.Any())
                throw new ArgumentOutOfRangeException();

            var figureManager = figureManagers.First();

            return figureManager.GetSquare(figure);
        }
    }
}
