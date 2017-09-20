using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Patagames.Ocr;
using Patagames.Ocr.Enums;
using System.Reflection;
namespace Extratext
{
    public partial class Form1 : Form
    {
        Point startPos;      // mouse-down position
        Point currentPos;    // current mouse position
        bool drawing;        // busy drawing
        List<Rectangle> rectangles = new List<Rectangle>();  // previous rectangles

        private Rectangle getRectangle()
        {
            return new Rectangle(
                Math.Min(startPos.X, currentPos.X),
                Math.Min(startPos.Y, currentPos.Y),
                Math.Abs(startPos.X - currentPos.X),
                Math.Abs(startPos.Y - currentPos.Y));
        }
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ExtractTextFromImage();
        }
    
        public void ExtractTextFromBitmap()
        {
            using (var api = OcrApi.Create())
            {
                api.Init(Languages.Vietnamese);
                using (var bmp = Bitmap.FromFile(@"D:\1123123123.png") as Bitmap)
                {
                    string plainText = api.GetTextFromImage(bmp);
                }
            }
        }
        public void ExtractTextFromImage()
        {
            using (var api = OcrApi.Create())
            {
                api.Init(Languages.Vietnamese);
                string plainText = api.GetTextFromImage(@"D:\1123123123.png");

            }
        }

        private void canevas_MouseDown(object sender, MouseEventArgs e)
        {
            currentPos = startPos = e.Location;
            drawing = true;
        }

        private void canevas_MouseMove(object sender, MouseEventArgs e)
        {
            currentPos = e.Location;
            if (drawing) canevas.Invalidate();
        }

        private void canevas_MouseUp(object sender, MouseEventArgs e)
        {
            if (drawing)
            {
                drawing = false;
                var rc = getRectangle();
                if (rc.Width > 0 && rc.Height > 0) rectangles.Add(rc);
                canevas.Invalidate();
            }
        }

        private void canevas_Paint(object sender, PaintEventArgs e)
        {
            if (rectangles.Count > 0) e.Graphics.DrawRectangles(Pens.Aqua, rectangles.ToArray());
            if (drawing) e.Graphics.DrawRectangle(Pens.Red, getRectangle());
        }

    }
}
