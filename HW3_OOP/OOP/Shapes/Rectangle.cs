using System.Collections.Generic;

namespace OOP.Shapes
{
    public class Rectangle : ShapeBase
    {
        double _edge1;
        double _edge2;

        public Rectangle(double edge1, double edge2)
            : this(new Dictionary<ParamKeys, object> { 
                {ParamKeys.Edge1, edge1},
                {ParamKeys.Edge2, edge2},
                {ParamKeys.CoordX, 0},
                {ParamKeys.CoordY, 0},
            })
        {
        }

        public Rectangle(IDictionary<ParamKeys, object> parameters) : base(parameters)
        {
            _edge1 = (double) parameters[ParamKeys.Edge1];
            _edge2 = (double) parameters[ParamKeys.Edge2];
        }


        public override double GetPerimeter()
        {
            if (Multiplier > 0)
            {
                return Multiplier*2*(_edge1 + _edge2);
            }
            else
            {
                return 2*(_edge1 + _edge2);
            }
        }

        protected override double Area()
        {
            if (Multiplier > 0)
            {
                return Multiplier * _edge1 * _edge2;
            }
            else
            {
                return _edge1 * _edge2;
            }
        }

        public override void Move(int deltaX, int deltaY)
        {
            CoordX += deltaX;
            CoordY += deltaY;
        }

        public override string ShapeName => "Rectangle";
    }
}