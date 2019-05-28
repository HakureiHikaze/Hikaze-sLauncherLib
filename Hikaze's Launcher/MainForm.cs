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
    
    public partial class MainForm : FXForm
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, System.EventArgs e)
        {
        }

        private void Exit_Click(object sender, EventArgs e)
        {
            FXClose();
        }
        
    }
}
