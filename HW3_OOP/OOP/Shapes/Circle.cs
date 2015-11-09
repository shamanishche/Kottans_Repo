using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace OOP.Shapes
{
	public class Circle : ShapeBase
	{
	    public const double Pi = Math.PI;
        double _radius;

        public Circle(double radius)
            : this(new Dictionary<ParamKeys, object> { 
                {ParamKeys.Radius, radius},
                {ParamKeys.CoordX, 0},
                {ParamKeys.CoordY, 0},
            })
        {
        }

        public Circle(IDictionary<ParamKeys, object> parameters) : base(parameters)
		{
            _radius = (double) parameters[ParamKeys.Radius];
		}

	    public override double GetPerimeter()
	    {
	        if (this.Multiplier > 0)
	        {
	            return _radius * Multiplier * Pi * 2; 
	        }
	        else
	        {
                return _radius * Pi * 2;
            }
	    }

	    protected override double Area()
	    {
            if (this.Multiplier > 0)
            {
                return Math.Pow(_radius * Multiplier, 2) * Pi;
            }
            else
            {
                return _radius * _radius * Pi;
            }
	    }

	    public override void Move(int deltaX, int deltaY)
	    {
	       CoordX += deltaX;
	       CoordY += deltaY;
	    }

	    public override string ShapeName => "Circle";
	}
}