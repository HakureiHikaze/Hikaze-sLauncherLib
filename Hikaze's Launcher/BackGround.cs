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
    public partial class BackGround : Form
    {
        public BackGround()
        {
            InitializeComponent();
        }

        private void BackGround_Load(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            form1.ShowDialog();
        }
        public void MouseMovingOnForeGround(object sender, System.Windows.Forms.MouseEventArgs e)
        {

        }
    }
}
