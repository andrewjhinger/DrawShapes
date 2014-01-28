using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DrawShapes
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void resetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Clear the shapes and raise Paint event
            _shapeList.Clear();
            canvasPictureBox.Invalidate();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Exit the application
            this.Close();
        }

        private ShapesList _shapeList = new ShapesList();   // List of shapes
        private Shape _draggingCurrentShape;                // Current shape
        private bool _dragging = false;                     // Are we rubber banding
        private int _startingX = 0;                         // Starting X location
        private int _startingY = 0;                         // Starting Y location
        private Color _shapeColor = Color.Red;              // Shape color

        private void MainForm_Load(object sender, EventArgs e)
        {
            // Populate shape ComboBox and select first entry
            shapeComboBox.Items.Add("Ellipse");
            shapeComboBox.Items.Add("Rectangle");
            shapeComboBox.Items.Add("Line");
            shapeComboBox.SelectedIndex = 0;
            // Set the default color
            shapeColorPictureBox.BackColor = _shapeColor;
        }

        private void colorButton_Click(object sender, EventArgs e)
        {
            // Display a ColorDialog
            ColorDialog colorDialog = new ColorDialog();
            colorDialog.AllowFullOpen = false;
            colorDialog.ShowHelp = false;
            colorDialog.Color = _shapeColor;
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                // Set current color, and update UI displaying current color
                _shapeColor = colorDialog.Color;
                shapeColorPictureBox.BackColor = colorDialog.Color;
            }
        }

        private void canvasPictureBox_MouseDown(object sender, MouseEventArgs e)
        {
            if (!_dragging)
            {
                // Save starting point, convert to rectangle
                _startingX = e.X;
                _startingY = e.Y;
                Rectangle rectangle = new Rectangle(e.X, e.Y, 0, 0);

                // Create current Shape
                switch (shapeComboBox.Text)
                {
                    case "Ellipse":
                        _draggingCurrentShape = new Ellipse(rectangle, _shapeColor, filledCheckBox.Checked);
                        _dragging = true;
                        break;
                    case "Rectangle":
                        _draggingCurrentShape = new Rctangle(rectangle, _shapeColor, filledCheckBox.Checked);
                        _dragging = true;
                        break;
                    case "Line":
                        _draggingCurrentShape = new Line(rectangle, _shapeColor, filledCheckBox.Checked);
                        _dragging = true;
                        break;



                }

                // Indicate we're drawing by "rubber-banding"

            }
        }

        private void canvasPictureBox_MouseMove(object sender, MouseEventArgs e)
        {
            if (_dragging)
            {
                // Determine and set current shape dimension based on current position
                _draggingCurrentShape.Width = e.X - _startingX;
                _draggingCurrentShape.Height = e.Y - _startingY;

                // Invalidate to raise Paint event
                canvasPictureBox.Invalidate();
            }
        }

        private void canvasPictureBox_MouseUp(object sender, MouseEventArgs e)
        {
            // Add to shape list
            if (_dragging)
            {
                // Add new shape and turn drag off
                _shapeList.Add(_draggingCurrentShape);
                _dragging = false;

                // Invalidate to raise Paint event
                canvasPictureBox.Invalidate();
            }
        }

        private void canvasPictureBox_Paint(object sender, PaintEventArgs e)
        {
            // Clear everything 
            e.Graphics.Clear(canvasPictureBox.BackColor);

            // Draw all previous shapes
            for (int i = 0; i < _shapeList.Length; i++)
                _shapeList[i].draw(e.Graphics);

            // Draw current
            if (_dragging)
                _draggingCurrentShape.draw(e.Graphics);
        }
    }
}
