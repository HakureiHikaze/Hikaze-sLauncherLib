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
using LauncherLib.ArgHandler;

namespace Hikaze_s_Launcher
{
    
    public partial class MainForm : FXForm
    {
        ThisGame thisGame;
        public MainForm()
        {
            InitializeComponent();
            Initialize();
        }

        private void MainForm_Load(object sender, System.EventArgs e)
        {
            
        }

        private void Initialize()
        {
            if(!Directory.Exists(@".\HikazeLauncher"))
            {
                Directory.CreateDirectory(@".\HikazeLauncher");
            }
            if (!Directory.Exists(@"D:\mc\.minecraft"))
            {
                Directory.CreateDirectory(@"D:\mc\.minecraft");
            }
            thisGame = new ThisGame(@"D:\mc\.minecraft", @".\HikazeLauncher");
            thisGame.MakeConfig(@".\HikazeLauncher\Config.json");
            cbbxVersionList.Items.AddRange(thisGame.VersionList.ToArray());
            unchecked
            {
                
            }
        }
        private void Exit_Click(object sender, EventArgs e)
        {
            FXClose();
        }

        private void BtnStart_Click(object sender, EventArgs e)
        {
            //thisGame.SetPlayerName("Hikaze");
            //thisGame.MakeConfig(@".\HikazeLauncher\Config.json");
            Debug.WriteLine(thisGame.ToString());
        }
    }
}
