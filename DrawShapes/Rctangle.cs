using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace DrawShapes
{
    class Rctangle : Shape
    {

        public Rctangle(Rectangle rectangle, Color shapeColor, bool filled)
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
                graphics.FillRectangle(new SolidBrush(base.ShapeColor), base.X, base.Y, base.Width, base.Height);
            else
                graphics.DrawRectangle(new Pen(base.ShapeColor), base.X, base.Y, base.Width, base.Height);
        }
    }
}
