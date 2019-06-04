using LauncherLib.Lang.Event;
using LauncherLib.Configs;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using LauncherLib.Utilities;

namespace Hikaze_s_Launcher
{
    public partial class ConfigForm : FXForm
    {
        public event EventHandler<ConfigChangedEventArgs> ConfigChanged;
        public void OnConfigLoad(object sender, ConfigChangedEventArgs e)
        {
            config = e.config;
        }
        public Config config;
        public ConfigForm(Config _config)
        {
            InitializeComponent();
            config = _config;
            tbGamePath.Text = config.GamePath;
            tbJavaPath.Text = config.JavaPath;
            tbJVMArgs.Text = config.JVMArguments;
            tbMCArgs.Text = config.MCArguments;
            tbMemMax.Text = config.memory.y.ToString();
            tbMemMin.Text = config.memory.x.ToString();
            tbServer.Text = config.Server;
            tbSizeHeight.Text = config.windowSize.y.ToString();
            tbSizeWidth.Text = config.windowSize.x.ToString();
        }

        private void BtnConfirm_Click(object sender, EventArgs e)
        {

            SetConfigs();
            ConfigChanged?.Invoke(this, new ConfigChangedEventArgs(config));
            FXClose();
        }
        void SetConfigs()
        {
            config.GamePath = tbGamePath.Text;
            config.JavaPath = tbJavaPath.Text;
            config.JVMArguments = tbJVMArgs.Text;
            config.MCArguments = tbMCArgs.Text;
            config.memory.y = Convert.ToInt32(tbMemMax.Text);
            config.memory.x = Convert.ToInt32(tbMemMin.Text);
            config.Server=tbServer.Text;
            config.windowSize.x = Convert.ToInt32(tbSizeWidth.Text);
            config.windowSize.y = Convert.ToInt32(tbSizeHeight.Text);
        }
        private void ConfigForm_Load(object sender, EventArgs e)
        {
        }

        private void JavaPathDialog_FileOk(object sender, CancelEventArgs e)
        {
            tbJavaPath.Text = JavaPathDialog.FileName;
        }
        private void BtnOpenGamePath_Click(object sender, EventArgs e)
        {
            GamePathDialog.SelectedPath = @".\.minecraft";
            GamePathDialog.ShowDialog();
            tbGamePath.Text = GamePathDialog.SelectedPath;
        }

        private void BtnOpenJavaPath_Click(object sender, EventArgs e)
        {
            JavaPathDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles);
            JavaPathDialog.Filter = "JAVAW|javaw.exe";
            JavaPathDialog.FileName = "javaw.exe";
            JavaPathDialog.ShowDialog();
        }

        private void BtnGamePathAuto_Click(object sender, EventArgs e)
        {
            tbGamePath.Text = @".\.minecraft";
        }

        private void BtnJavaPathAuto_Click(object sender, EventArgs e)
        {
            string path = PathTools.GetJavaPath();
            if (path == "0")
            {
                tbJavaPath.Text = "Check Java installation? :-)";
            }
            else
            {
                tbJavaPath.Text = path;
            }
        }

        private void BtnQuit_Click(object sender, EventArgs e)
        {
            FXClose();
        }
    }
}
