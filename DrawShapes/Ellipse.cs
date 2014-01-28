using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace DrawShapes
{
    public class Ellipse : Shape
    {
        public Ellipse(Rectangle rectangle, Color shapeColor, bool filled)
        {
            base.X = rectangle.X;
            base.Y = rectangle.Y;
            base.Width = rectangle.Width;
            base.Height = rectangle.Height;
            base.ShapeColor = shapeColor;
            base.Filled = filled;
        }

        public override void draw(Graphics graphics)
        {
            if (base.Filled)
                graphics.FillEllipse(new SolidBrush(base.ShapeColor), base.X, base.Y, base.Width, base.Height);
            else
                graphics.DrawEllipse(new Pen(base.ShapeColor), base.X, base.Y, base.Width, base.Height);
        }
    }
}