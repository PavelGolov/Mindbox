using Mindbox.Common;
using Mindbox.Figures;

namespace Mindbox.Figures.Triangle
{
    public interface ITriangleManager : IFigureManager<Triangle>
    {
        public bool IsRight(Triangle triangle);
    }
}