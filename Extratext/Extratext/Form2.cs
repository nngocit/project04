using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Extratext
{
    public partial class Form2 : Form
    {
        private HalloForm _hallo;
        private Timer _timer;

        Point startPos;      // mouse-down position
        Point currentPos;    // current mouse position
        bool drawing;        // busy drawing
        List<Rectangle> rectangles = new List<Rectangle>();  // previous rectangles
        [DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
        public static extern void mouse_event(uint dwFlags, uint dx, uint dy, uint cButtons, uint dwExtraInfo);
        //Mouse actions
        private const int MOUSEEVENTF_LEFTDOWN = 0x02;
        private const int MOUSEEVENTF_LEFTUP = 0x04;
        private const int MOUSEEVENTF_RIGHTDOWN = 0x08;
        private const int MOUSEEVENTF_RIGHTUP = 0x10;
        private Rectangle getRectangle()
        {
            return new Rectangle(
                Math.Min(startPos.X, currentPos.X),
                Math.Min(startPos.Y, currentPos.Y),
                Math.Abs(startPos.X - currentPos.X),
                Math.Abs(startPos.Y - currentPos.Y));
        }
        public Form2()
        {
            InitializeComponent();
            _hallo = new HalloForm();
            _timer = new Timer() { Interval = 20, Enabled = true };
            _timer.Tick += new EventHandler(Timer_Tick);
         
        }
        void Timer_Tick(object sender, EventArgs e)
        {
            Point pt = Cursor.Position;
            pt.Offset(-(_hallo.Width / 2), -(_hallo.Height / 2));
            _hallo.Location = pt;
            
            if (!_hallo.Visible)
            {
               
                _hallo.Show();
            }
        }
        public void DoMouseClick()
        {
            //Call the imported function with the cursor's current position
            uint X = (uint)Cursor.Position.X;
            uint Y = (uint)Cursor.Position.Y;
            mouse_event(MOUSEEVENTF_LEFTDOWN | MOUSEEVENTF_LEFTUP, X, Y, 0, 0);
        }

    }
    public class HalloForm : Form
    {
        public HalloForm()
        {
            TopMost = true;
            ShowInTaskbar = false;
            FormBorderStyle = FormBorderStyle.None;
            BackColor = Color.LightGreen;
            TransparencyKey = Color.LightGreen;
            Width = 100;
            Height = 100;

            Paint += new PaintEventHandler(HalloForm_Paint);
        }

        void HalloForm_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawEllipse(Pens.Black, (Width - 25) / 2, (Height - 25) / 2, 25, 25);
        }
    }
}
