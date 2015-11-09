using System;
using System.Collections.Generic;

namespace OOP.Shapes
{
    // TODO: use Heron's formula for area
    public class Triangle : ShapeBase
    {
        double _edge1;
        double _edge2;
        double _edge3;

        public Triangle(double edge1, double edge2, double edge3)
            : this(new Dictionary<ParamKeys, object> { 
                {ParamKeys.Edge1, edge1},
                {ParamKeys.Edge2, edge2},
                {ParamKeys.Edge3, edge3},
                {ParamKeys.CoordX, 0},
                {ParamKeys.CoordY, 0},
            })
        {
        }

        public Triangle(IDictionary<ParamKeys, object> parameters) : base(parameters)
        {
            _edge1 = (double)parameters[ParamKeys.Edge1];
            _edge2 = (double)parameters[ParamKeys.Edge2];
            _edge3 = (double)parameters[ParamKeys.Edge3];
        }

        public override double GetPerimeter()
        {
            if (Multiplier > 0)
            {
                return Multiplier*(_edge1 + _edge2 + _edge3);
            }
            else
            {
                return _edge1 + _edge2 + _edge3;
            }
        }

        protected override double Area()
        {
            var halfPer = GetPerimeter()/2;
            return Math.Sqrt(halfPer*(halfPer - _edge1)*(halfPer - _edge2)*(halfPer - _edge3));
        }

        public override void Move(int deltaX, int deltaY)
        {
            CoordX += deltaX;
            CoordY += deltaY;
        }

        public override string ShapeName => "Triangle";
    }
}