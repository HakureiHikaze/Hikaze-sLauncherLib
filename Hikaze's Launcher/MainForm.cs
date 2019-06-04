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
using LauncherLib.Lang.Event;

namespace Hikaze_s_Launcher
{
    
    public partial class MainForm : FXForm
    {

        public event EventHandler<ConfigChangedEventArgs> ConfigLoad;
        ThisGame thisGame;
        ConfigForm configForm;
        public void OnConfigChanged(object sender,ConfigChangedEventArgs e)
        {
            thisGame.CurrentConfig = e.config;
            thisGame.MakeConfig(@".\HikazeLauncher\Config.json");
        }
        public MainForm()
        {
            InitializeComponent();
            Initialize();
            cbbxVersionList.SelectedItem = cbbxVersionList.Items[0];
        }

        private void MainForm_Load(object sender, EventArgs e)
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
            configForm = new ConfigForm(thisGame.CurrentConfig);
            configForm.ConfigChanged += OnConfigChanged;
            //ConfigLoad += configForm.OnConfigLoad;
            ConfigLoad?.Invoke(this, new ConfigChangedEventArgs(thisGame.CurrentConfig));
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

        private void BtnOpenConfig_Click(object sender, EventArgs e)
        {
            configForm.ShowDialog();
        }
    }
}
