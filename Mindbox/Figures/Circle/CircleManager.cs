using Mindbox.Common;

namespace Mindbox.Figures.Circle
{
    public class CircleManager : FigureManager<Circle>
    {
        protected override bool IsValid(Circle figure) => figure.R > 0;

        protected override double Square(Circle figure) => Math.PI * figure.R * figure.R;
    }
}