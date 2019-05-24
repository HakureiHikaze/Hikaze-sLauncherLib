using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hikaze_s_Launcher
{
    public partial class Form1 : Form
    {
        bool MouseEntered = false;
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_MouseEnter(object sender, System.EventArgs e)
        {
            MouseEntered = true;
        }
        private void Form1_MouseLeave(object sender, System.EventArgs e)
        {
            MouseEntered = false;
        }
        private void Form1_MouseMove(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            throw new System.NotImplementedException();
        }

    }
}
