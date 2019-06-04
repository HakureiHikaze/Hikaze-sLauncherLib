namespace Hikaze_s_Launcher
{
    partial class ConfigForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnConfirm = new System.Windows.Forms.Button();
            this.tbGamePath = new System.Windows.Forms.TextBox();
            this.tbMemMin = new System.Windows.Forms.TextBox();
            this.tbJavaPath = new System.Windows.Forms.TextBox();
            this.tbJVMArgs = new System.Windows.Forms.TextBox();
            this.tbMCArgs = new System.Windows.Forms.TextBox();
            this.tbMemMax = new System.Windows.Forms.TextBox();
            this.tbServer = new System.Windows.Forms.TextBox();
            this.tbSizeHeight = new System.Windows.Forms.TextBox();
            this.tbSizeWidth = new System.Windows.Forms.TextBox();
            this.cbEnterServer = new System.Windows.Forms.CheckBox();
            this.btnOpenGamePath = new System.Windows.Forms.Button();
            this.btnGamePathAuto = new System.Windows.Forms.Button();
            this.btnOpenJavaPath = new System.Windows.Forms.Button();
            this.btnJavaPathAuto = new System.Windows.Forms.Button();
            this.JavaPathDialog = new System.Windows.Forms.OpenFileDialog();
            this.lbGamePath = new System.Windows.Forms.Label();
            this.lbJavaPath = new System.Windows.Forms.Label();
            this.lbMCArgs = new System.Windows.Forms.Label();
            this.lbJVMArgs = new System.Windows.Forms.Label();
            this.lbServer = new System.Windows.Forms.Label();
            this.lbMemory = new System.Windows.Forms.Label();
            this.lbSize = new System.Windows.Forms.Label();
            this.lbMemMid = new System.Windows.Forms.Label();
            this.lbSizeMid = new System.Windows.Forms.Label();
            this.GamePathDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.btnQuit = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnConfirm
            // 
            this.btnConfirm.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnConfirm.FlatAppearance.BorderSize = 0;
            this.btnConfirm.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Green;
            this.btnConfirm.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.btnConfirm.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnConfirm.Font = new System.Drawing.Font("黑体", 11F);
            this.btnConfirm.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btnConfirm.Location = new System.Drawing.Point(578, 149);
            this.btnConfirm.Name = "btnConfirm";
            this.btnConfirm.Size = new System.Drawing.Size(134, 45);
            this.btnConfirm.TabIndex = 0;
            this.btnConfirm.Text = "&Save and quit";
            this.btnConfirm.UseVisualStyleBackColor = true;
            this.btnConfirm.Click += new System.EventHandler(this.BtnConfirm_Click);
            // 
            // tbGamePath
            // 
            this.tbGamePath.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.tbGamePath.Location = new System.Drawing.Point(89, 11);
            this.tbGamePath.Name = "tbGamePath";
            this.tbGamePath.Size = new System.Drawing.Size(511, 21);
            this.tbGamePath.TabIndex = 1;
            // 
            // tbMemMin
            // 
            this.tbMemMin.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.tbMemMin.Location = new System.Drawing.Point(89, 146);
            this.tbMemMin.Name = "tbMemMin";
            this.tbMemMin.Size = new System.Drawing.Size(100, 21);
            this.tbMemMin.TabIndex = 1;
            // 
            // tbJavaPath
            // 
            this.tbJavaPath.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.tbJavaPath.Location = new System.Drawing.Point(89, 38);
            this.tbJavaPath.Name = "tbJavaPath";
            this.tbJavaPath.Size = new System.Drawing.Size(511, 21);
            this.tbJavaPath.TabIndex = 1;
            // 
            // tbJVMArgs
            // 
            this.tbJVMArgs.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.tbJVMArgs.Location = new System.Drawing.Point(89, 92);
            this.tbJVMArgs.Name = "tbJVMArgs";
            this.tbJVMArgs.Size = new System.Drawing.Size(622, 21);
            this.tbJVMArgs.TabIndex = 1;
            // 
            // tbMCArgs
            // 
            this.tbMCArgs.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.tbMCArgs.Location = new System.Drawing.Point(89, 65);
            this.tbMCArgs.Name = "tbMCArgs";
            this.tbMCArgs.Size = new System.Drawing.Size(622, 21);
            this.tbMCArgs.TabIndex = 1;
            // 
            // tbMemMax
            // 
            this.tbMemMax.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.tbMemMax.Location = new System.Drawing.Point(207, 146);
            this.tbMemMax.Name = "tbMemMax";
            this.tbMemMax.Size = new System.Drawing.Size(100, 21);
            this.tbMemMax.TabIndex = 1;
            // 
            // tbServer
            // 
            this.tbServer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.tbServer.Location = new System.Drawing.Point(89, 119);
            this.tbServer.Name = "tbServer";
            this.tbServer.Size = new System.Drawing.Size(511, 21);
            this.tbServer.TabIndex = 1;
            // 
            // tbSizeHeight
            // 
            this.tbSizeHeight.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.tbSizeHeight.Location = new System.Drawing.Point(207, 173);
            this.tbSizeHeight.Name = "tbSizeHeight";
            this.tbSizeHeight.Size = new System.Drawing.Size(100, 21);
            this.tbSizeHeight.TabIndex = 1;
            // 
            // tbSizeWidth
            // 
            this.tbSizeWidth.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.tbSizeWidth.Location = new System.Drawing.Point(89, 173);
            this.tbSizeWidth.Name = "tbSizeWidth";
            this.tbSizeWidth.Size = new System.Drawing.Size(100, 21);
            this.tbSizeWidth.TabIndex = 1;
            // 
            // cbEnterServer
            // 
            this.cbEnterServer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cbEnterServer.AutoSize = true;
            this.cbEnterServer.Location = new System.Drawing.Point(606, 122);
            this.cbEnterServer.Name = "cbEnterServer";
            this.cbEnterServer.Size = new System.Drawing.Size(84, 16);
            this.cbEnterServer.TabIndex = 2;
            this.cbEnterServer.Text = "Auto Enter";
            this.cbEnterServer.UseVisualStyleBackColor = true;
            // 
            // btnOpenGamePath
            // 
            this.btnOpenGamePath.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOpenGamePath.Location = new System.Drawing.Point(606, 10);
            this.btnOpenGamePath.Name = "btnOpenGamePath";
            this.btnOpenGamePath.Size = new System.Drawing.Size(23, 23);
            this.btnOpenGamePath.TabIndex = 3;
            this.btnOpenGamePath.Text = "...";
            this.btnOpenGamePath.UseVisualStyleBackColor = true;
            this.btnOpenGamePath.Click += new System.EventHandler(this.BtnOpenGamePath_Click);
            // 
            // btnGamePathAuto
            // 
            this.btnGamePathAuto.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGamePathAuto.Location = new System.Drawing.Point(636, 10);
            this.btnGamePathAuto.Name = "btnGamePathAuto";
            this.btnGamePathAuto.Size = new System.Drawing.Size(75, 23);
            this.btnGamePathAuto.TabIndex = 4;
            this.btnGamePathAuto.Text = "auto";
            this.btnGamePathAuto.UseVisualStyleBackColor = true;
            this.btnGamePathAuto.Click += new System.EventHandler(this.BtnGamePathAuto_Click);
            // 
            // btnOpenJavaPath
            // 
            this.btnOpenJavaPath.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOpenJavaPath.Location = new System.Drawing.Point(606, 37);
            this.btnOpenJavaPath.Name = "btnOpenJavaPath";
            this.btnOpenJavaPath.Size = new System.Drawing.Size(23, 23);
            this.btnOpenJavaPath.TabIndex = 3;
            this.btnOpenJavaPath.Text = "...";
            this.btnOpenJavaPath.UseVisualStyleBackColor = true;
            this.btnOpenJavaPath.Click += new System.EventHandler(this.BtnOpenJavaPath_Click);
            // 
            // btnJavaPathAuto
            // 
            this.btnJavaPathAuto.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnJavaPathAuto.Location = new System.Drawing.Point(636, 38);
            this.btnJavaPathAuto.Name = "btnJavaPathAuto";
            this.btnJavaPathAuto.Size = new System.Drawing.Size(75, 23);
            this.btnJavaPathAuto.TabIndex = 4;
            this.btnJavaPathAuto.Text = "auto";
            this.btnJavaPathAuto.UseVisualStyleBackColor = true;
            this.btnJavaPathAuto.Click += new System.EventHandler(this.BtnJavaPathAuto_Click);
            // 
            // JavaPathDialog
            // 
            this.JavaPathDialog.FileName = "openFileDialog1";
            this.JavaPathDialog.FileOk += new System.ComponentModel.CancelEventHandler(this.JavaPathDialog_FileOk);
            // 
            // lbGamePath
            // 
            this.lbGamePath.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lbGamePath.AutoSize = true;
            this.lbGamePath.Location = new System.Drawing.Point(18, 15);
            this.lbGamePath.Name = "lbGamePath";
            this.lbGamePath.Size = new System.Drawing.Size(65, 12);
            this.lbGamePath.TabIndex = 5;
            this.lbGamePath.Text = "Game path:";
            // 
            // lbJavaPath
            // 
            this.lbJavaPath.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lbJavaPath.AutoSize = true;
            this.lbJavaPath.Location = new System.Drawing.Point(18, 43);
            this.lbJavaPath.Name = "lbJavaPath";
            this.lbJavaPath.Size = new System.Drawing.Size(65, 12);
            this.lbJavaPath.TabIndex = 5;
            this.lbJavaPath.Text = "Java path:";
            // 
            // lbMCArgs
            // 
            this.lbMCArgs.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lbMCArgs.AutoSize = true;
            this.lbMCArgs.Location = new System.Drawing.Point(30, 68);
            this.lbMCArgs.Name = "lbMCArgs";
            this.lbMCArgs.Size = new System.Drawing.Size(53, 12);
            this.lbMCArgs.TabIndex = 5;
            this.lbMCArgs.Text = "MC args:";
            // 
            // lbJVMArgs
            // 
            this.lbJVMArgs.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lbJVMArgs.AutoSize = true;
            this.lbJVMArgs.Location = new System.Drawing.Point(24, 95);
            this.lbJVMArgs.Name = "lbJVMArgs";
            this.lbJVMArgs.Size = new System.Drawing.Size(59, 12);
            this.lbJVMArgs.TabIndex = 5;
            this.lbJVMArgs.Text = "JVM args:";
            // 
            // lbServer
            // 
            this.lbServer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lbServer.AutoSize = true;
            this.lbServer.Location = new System.Drawing.Point(36, 122);
            this.lbServer.Name = "lbServer";
            this.lbServer.Size = new System.Drawing.Size(47, 12);
            this.lbServer.TabIndex = 5;
            this.lbServer.Text = "Server:";
            // 
            // lbMemory
            // 
            this.lbMemory.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lbMemory.AutoSize = true;
            this.lbMemory.Location = new System.Drawing.Point(36, 149);
            this.lbMemory.Name = "lbMemory";
            this.lbMemory.Size = new System.Drawing.Size(47, 12);
            this.lbMemory.TabIndex = 5;
            this.lbMemory.Text = "Memory:";
            // 
            // lbSize
            // 
            this.lbSize.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lbSize.AutoSize = true;
            this.lbSize.Location = new System.Drawing.Point(6, 176);
            this.lbSize.Name = "lbSize";
            this.lbSize.Size = new System.Drawing.Size(77, 12);
            this.lbSize.TabIndex = 5;
            this.lbSize.Text = "Window size:";
            // 
            // lbMemMid
            // 
            this.lbMemMid.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lbMemMid.AutoSize = true;
            this.lbMemMid.Location = new System.Drawing.Point(193, 151);
            this.lbMemMid.Name = "lbMemMid";
            this.lbMemMid.Size = new System.Drawing.Size(11, 12);
            this.lbMemMid.TabIndex = 5;
            this.lbMemMid.Text = "-";
            // 
            // lbSizeMid
            // 
            this.lbSizeMid.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lbSizeMid.AutoSize = true;
            this.lbSizeMid.Location = new System.Drawing.Point(193, 178);
            this.lbSizeMid.Name = "lbSizeMid";
            this.lbSizeMid.Size = new System.Drawing.Size(11, 12);
            this.lbSizeMid.TabIndex = 5;
            this.lbSizeMid.Text = "x";
            // 
            // btnQuit
            // 
            this.btnQuit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnQuit.FlatAppearance.BorderSize = 0;
            this.btnQuit.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Maroon;
            this.btnQuit.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnQuit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnQuit.Font = new System.Drawing.Font("黑体", 11F);
            this.btnQuit.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btnQuit.Location = new System.Drawing.Point(466, 149);
            this.btnQuit.Name = "btnQuit";
            this.btnQuit.Size = new System.Drawing.Size(106, 45);
            this.btnQuit.TabIndex = 6;
            this.btnQuit.Text = "&Quit only";
            this.btnQuit.UseVisualStyleBackColor = true;
            this.btnQuit.Click += new System.EventHandler(this.BtnQuit_Click);
            // 
            // ConfigForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(140)))), ((int)(((byte)(235)))));
            this.ClientSize = new System.Drawing.Size(724, 208);
            this.Controls.Add(this.btnQuit);
            this.Controls.Add(this.lbSize);
            this.Controls.Add(this.lbSizeMid);
            this.Controls.Add(this.lbMemMid);
            this.Controls.Add(this.lbMemory);
            this.Controls.Add(this.lbServer);
            this.Controls.Add(this.lbJVMArgs);
            this.Controls.Add(this.lbMCArgs);
            this.Controls.Add(this.lbJavaPath);
            this.Controls.Add(this.lbGamePath);
            this.Controls.Add(this.btnJavaPathAuto);
            this.Controls.Add(this.btnGamePathAuto);
            this.Controls.Add(this.btnOpenJavaPath);
            this.Controls.Add(this.btnOpenGamePath);
            this.Controls.Add(this.cbEnterServer);
            this.Controls.Add(this.tbSizeWidth);
            this.Controls.Add(this.tbSizeHeight);
            this.Controls.Add(this.tbServer);
            this.Controls.Add(this.tbMemMax);
            this.Controls.Add(this.tbMCArgs);
            this.Controls.Add(this.tbJVMArgs);
            this.Controls.Add(this.tbJavaPath);
            this.Controls.Add(this.tbMemMin);
            this.Controls.Add(this.tbGamePath);
            this.Controls.Add(this.btnConfirm);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ConfigForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Config";
            this.Load += new System.EventHandler(this.ConfigForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnConfirm;
        private System.Windows.Forms.TextBox tbGamePath;
        private System.Windows.Forms.TextBox tbMemMin;
        private System.Windows.Forms.TextBox tbJavaPath;
        private System.Windows.Forms.TextBox tbJVMArgs;
        private System.Windows.Forms.TextBox tbMCArgs;
        private System.Windows.Forms.TextBox tbMemMax;
        private System.Windows.Forms.TextBox tbServer;
        private System.Windows.Forms.TextBox tbSizeHeight;
        private System.Windows.Forms.TextBox tbSizeWidth;
        private System.Windows.Forms.CheckBox cbEnterServer;
        private System.Windows.Forms.Button btnOpenGamePath;
        private System.Windows.Forms.Button btnGamePathAuto;
        private System.Windows.Forms.Button btnOpenJavaPath;
        private System.Windows.Forms.Button btnJavaPathAuto;
        private System.Windows.Forms.OpenFileDialog JavaPathDialog;
        private System.Windows.Forms.Label lbGamePath;
        private System.Windows.Forms.Label lbJavaPath;
        private System.Windows.Forms.Label lbMCArgs;
        private System.Windows.Forms.Label lbJVMArgs;
        private System.Windows.Forms.Label lbServer;
        private System.Windows.Forms.Label lbMemory;
        private System.Windows.Forms.Label lbSize;
        private System.Windows.Forms.Label lbMemMid;
        private System.Windows.Forms.Label lbSizeMid;
        private System.Windows.Forms.FolderBrowserDialog GamePathDialog;
        private System.Windows.Forms.Button btnQuit;
    }
}