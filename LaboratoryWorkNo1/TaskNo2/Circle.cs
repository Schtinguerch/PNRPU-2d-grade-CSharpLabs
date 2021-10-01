using System;
using static System.Math;

namespace TaskNo2
{
    class Circle
    {
        private double _radius = 0;
        public double Radius
        {
            get => _radius;
            set
            {
                if (value < 0)
                    throw new ArgumentOutOfRangeException();
                
                _radius = value;
            }
        }

        public Point CenterPoint { get; set; }

        public bool IncludesPoint(Point point) =>
            Pow(point.X - CenterPoint.X, 2) +
            Pow(point.Y - CenterPoint.Y, 2) -
            Pow(Radius, 2) <= 0;
    }
}
