using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hikaze_s_Launcher
{
    public class FXForm : Form
    {
        bool bMouseDown;
        Point point;
        Point nowLocaton;
        Point Offset;
        Action action;
        public delegate void Initialization();
        internal FXForm()
        {
            InitializeEvents();
        }
        internal FXForm(Action _action)
        {
            action = _action;
            InitializeEvents();
        }
        void InitializeEvents()
        {
            this.MouseDown += FXForm_MouseDown;
            this.MouseMove += FXForm_MouseMove;
            this.MouseUp += FXForm_MouseUp;
            this.Load += FXForm_LoadingFX;
        }
        internal void FXClose()
        {
            Point newLocation = new Point(Location.X, Location.Y);
            Point oldLocation = new Point(Location.X, Location.Y);
            for (double i = Opacity; i >= 0; i -= 0.05)
            {
                newLocation.Y = oldLocation.Y + (int)(12.5f * (1 - Math.Sqrt(i)));
                this.Location = newLocation;
                this.Opacity = i;
                this.Refresh();
                System.Threading.Thread.Sleep(7);
            }
            Close();
        }
        private void FXForm_MouseDown(object sender, MouseEventArgs e)
        {
            bMouseDown = true;
            point = new Point(e.X, e.Y);
            nowLocaton = this.Location;
            Offset = new Point(0, 0);
        }
        private void FXForm_MouseMove(object sender, MouseEventArgs e)
        {

            if (bMouseDown)
            {
                Offset.X = e.X - point.X;
                Offset.Y = e.Y - point.Y;
                nowLocaton.X += Offset.X;
                nowLocaton.Y += Offset.Y;
                this.Location = nowLocaton;
            }
        }

        private void FXForm_MouseUp(object sender, MouseEventArgs e)
        {
            bMouseDown = false;
        }
        private void FXForm_LoadingFX(object sender, System.EventArgs e)
        {
            if (action != null) { action(); }
            #region Visible FX
            Point newLocation = new Point(Location.X, Location.Y);
            Point oldLocation = new Point(Location.X, Location.Y);
            for (double i = 0; i < 1; i += 0.05)
            {
                newLocation.Y = oldLocation.Y + (int)(12.5f * (1 - Math.Sqrt(i)));
                this.Location = newLocation;
                this.Opacity = i;
                this.Refresh();
                System.Threading.Thread.Sleep(7);
            }
            Location = oldLocation;
            Opacity = 1;
            #endregion
        }
    }
}
