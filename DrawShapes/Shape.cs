using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace DrawShapes
{
    public class Shape
    {
        public Color ShapeColor;
        public bool Filled;
        public int X;
        public int Y;
        public int Width;
        public int Height;

        public virtual void draw(Graphics graphics)
        {
            // Override this method in the child class
        }
    }
}