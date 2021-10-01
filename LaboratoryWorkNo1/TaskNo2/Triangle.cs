using System;
using static System.Math;

namespace TaskNo2
{
    class Triangle
    {
        public Point VertexA {  get; set; }
        public Point VertexB { get; set; }
        public Point VertexC { get; set; }

        public bool IncludesPoint(Point point)
        {
            double partOneArea = TriangleArea(VertexA, VertexB, point);
            double partTwoArea = TriangleArea(VertexB, VertexC, point);
            double partThreeArea = TriangleArea(VertexC, VertexA, point);

            double summaryArea = partOneArea + partTwoArea + partThreeArea;
            double triangeArea = TriangleArea(VertexA, VertexB, VertexC);

            return summaryArea <= triangeArea;
        }

        private double TriangleArea(Point A, Point B, Point C) =>
            0.5 * Abs((B.X - A.X) * (C.Y - A.Y) - (C.X - A.X) * (B.Y - A.Y));
    }
}
