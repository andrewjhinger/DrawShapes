using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DrawShapes
{
    public class ShapesList
    {
        private Shape[] _shapes = null;     // One-dimensional array of shape objects

        // Indexer
        public Shape this[int index]
        {
            get { return _shapes != null ? _shapes[index] : null; }
        }

        // Count of shapes
        public int Length
        {
            get { return _shapes != null ? _shapes.Length : 0; }
        }

        // Add a shape
        public int Add(Shape shape)
        {
            // Create or resize our shapes array
            if (_shapes == null)
                _shapes = new Shape[1];
            else
                Array.Resize(ref _shapes, _shapes.Length + 1);

            _shapes[_shapes.Length - 1] = shape;
            return _shapes.Length;
        }

        // Clear all shapes
        public void Clear()
        {
            if (_shapes != null)
            {
                Array.Clear(_shapes, 0, _shapes.Length);
                _shapes = null;
            }
        }
    }
}