using System.Collections.Generic;

namespace OOP.Shapes.Triangles
{
    /// <summary>
    /// Triangle with one 90 degrees corner
    /// </summary>
    public class RightTriangle : Triangle
    {
        double _edge1;
        double _edge2;

        public RightTriangle(double edge1, double edge2)
            : this(new Dictionary<ParamKeys, object> { 
                {ParamKeys.Edge1, edge1},
                {ParamKeys.Edge2, edge2},
                {ParamKeys.CoordX, 0},
                {ParamKeys.CoordY, 0},
            })
        {
        }

        public RightTriangle(IDictionary<ParamKeys, object> parameters) : base(parameters)
        {
            _edge1 = (double) parameters[ParamKeys.Edge1];
            _edge2 = (double) parameters[ParamKeys.Edge2];
        }

        public override string ShapeName => "RightTriangle";
    }
}