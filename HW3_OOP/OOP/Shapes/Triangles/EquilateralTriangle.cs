using System.Collections.Generic;

namespace OOP.Shapes.Triangles
{
    /// <summary>
    /// triangle where all edges are equal
    /// </summary>
    public class EquilateralTriangle : Triangle
    {
        double _edge1;

        public EquilateralTriangle(double edge1)
            : this(new Dictionary<ParamKeys, object> { 
                {ParamKeys.Edge1, edge1},
                {ParamKeys.CoordX, 0},
                {ParamKeys.CoordY, 0},
            })
        {
        }

        public EquilateralTriangle(IDictionary<ParamKeys, object> parameters) : base(parameters)
        {
            _edge1 = (double)parameters[ParamKeys.Edge1];
        }

        public override double GetPerimeter()
        {
            if (Multiplier > 0)
            {
                return Multiplier * 3 * _edge1;
            }
            else
            {
                return 3 * _edge1;
            }
        }

        public override string ShapeName => "EquilateralTriangle";
    }
}