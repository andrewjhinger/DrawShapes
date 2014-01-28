using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace DrawShapes
{
    class Line : Shape
    {

        public Line(Rectangle rectangle, Color shapeColor, bool filled)
        {
            base.X = rectangle.X;
            base.Y = rectangle.Y;
            base.Width = rectangle.Width;
            base.Height = rectangle.Height;
            base.ShapeColor = shapeColor;
            base.Filled = filled;

            //
        }

        public override void draw(Graphics graphics)
        {
            Point point1 = new Point(base.X, base.Y);
            Point point2 = new Point(base.X + base.Width, base.Y + base.Height);
            if (base.Filled == false)
            {
                graphics.DrawLine(new Pen(base.ShapeColor), point1, point2);
            }
        }
    }
}
