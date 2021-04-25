using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterSeg
{
    /// <summary>
    /// Класс, описывающий отрезок на плоскости XY
    /// </summary>
    class Segment
    {
        // начальная точка отрезка
        public Point First;
        // конечная точка отрезка
        public Point Second;
        // конструктор класса
        public Segment() 
        {
            First.X = -1;
            First.Y = -1;
            Second.X = -1;
            Second.Y = -1;
        }
        // конструктор класса
        public Segment(Point firstPoint, Point secondPoint)
        {
            First = firstPoint;
            Second = secondPoint;
        }
    }
}
