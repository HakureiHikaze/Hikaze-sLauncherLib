using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestForm
{
    public partial class Form2 : Form
    {
        Point loc;
        Point nowLoc;
        Rectangle rectangle;
        public Form2()
        {
            InitializeComponent();
            loc = new Point();
            nowLoc = new Point();
        }

        public void Form2_MouseMove(object sender, MouseEventArgs e)
        {
            //Debug.WriteLine("({0},{1})", e.X, e.Y);
            loc.X =nowLoc.X+ 24 - Convert.ToInt32((double)e.X / 15.0f);
            loc.Y = nowLoc.Y + 14 - Convert.ToInt32((double)e.Y / 14.5f);
            this.Location = loc;
            System.Drawing.Drawing2D.GraphicsPath shape = new System.Drawing.Drawing2D.GraphicsPath();
            rectangle = new Rectangle(-loc.X+ nowLoc.X+24, -loc.Y+ nowLoc.Y+14, 720, 404);
            Debug.WriteLine("({0},{1})", loc.X, loc.Y);
            shape.AddRectangle(rectangle);
            this.Region = new Region(shape);
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            nowLoc = this.Location;
            int x = Location.X;
            int y = Location.Y;
        }
    }
}
