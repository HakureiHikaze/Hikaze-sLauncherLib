using Launcher.Configs;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System;

namespace Hikaze_s_Launcher
{
    public partial class MainForm : Form
    {
        bool bMouseDown;
        Point point;
        Point nowLocaton;
        Point Offset;
        public MainForm()
        {
            InitializeComponent();
            HLConfig hLConfig = new HLConfig(null);
            //ReadConfig();
            bMouseDown = false;
        }
        #region FormDragging
        private void MainForm_MouseDown(object sender, MouseEventArgs e)
        {
            bMouseDown = true;
            point = new Point(e.X, e.Y);
            nowLocaton = this.Location;
            Offset = new Point(0, 0);
        }
        private void MainForm_MouseMove(object sender, MouseEventArgs e)
        {

            if (bMouseDown)
            {
                Offset.X = e.X - point.X;
                Offset.Y = e.Y - point.Y;
                nowLocaton.X += Offset.X;
                nowLocaton.Y += Offset.Y;
                this.Location = nowLocaton;
                //Debug.WriteLine("Offset = ({0},{1})", e.X - point.X, e.Y - point.Y);
            }
        }

        private void MainForm_MouseUp(object sender, MouseEventArgs e)
        {
            bMouseDown = false;
        }
        #endregion

        private void MainForm_Load(object sender, System.EventArgs e)
        {
            #region Visible FX
            Point newLocation = new Point(Location.X, Location.Y);
            Point oldLocation = new Point(Location.X, Location.Y);
            for (double i = 0; i < 1; i += 0.05)
            {
                newLocation.Y = oldLocation.Y + (int)(12.5f * (1 - Math.Sqrt(i)));
                this.Location = newLocation;
                this.Opacity = i;
                this.Refresh();
                System.Threading.Thread.Sleep(10);
            }
            Location = oldLocation;
            Opacity = 1;
            #endregion

        }
    }
}
