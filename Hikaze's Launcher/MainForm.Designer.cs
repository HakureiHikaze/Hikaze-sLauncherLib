namespace Hikaze_s_Launcher
{
    partial class MainForm
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
            this.Exit = new System.Windows.Forms.Button();
            this.btnStart = new System.Windows.Forms.Button();
            this.cbbxVersionList = new System.Windows.Forms.ComboBox();
            this.btnOpenConfig = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Exit
            // 
            this.Exit.FlatAppearance.BorderColor = System.Drawing.SystemColors.Highlight;
            this.Exit.FlatAppearance.BorderSize = 0;
            this.Exit.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.Exit.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Red;
            this.Exit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Exit.Font = new System.Drawing.Font("Nueva Std", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Exit.ForeColor = System.Drawing.SystemColors.Info;
            this.Exit.Location = new System.Drawing.Point(720, 12);
            this.Exit.Name = "Exit";
            this.Exit.Size = new System.Drawing.Size(36, 36);
            this.Exit.TabIndex = 0;
            this.Exit.Text = "×";
            this.Exit.UseVisualStyleBackColor = false;
            this.Exit.Click += new System.EventHandler(this.Exit_Click);
            // 
            // btnStart
            // 
            this.btnStart.FlatAppearance.BorderSize = 0;
            this.btnStart.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStart.Font = new System.Drawing.Font("DejaVu Sans Mono", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStart.ForeColor = System.Drawing.SystemColors.Info;
            this.btnStart.Location = new System.Drawing.Point(542, 354);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(214, 66);
            this.btnStart.TabIndex = 1;
            this.btnStart.Text = "Link Start!!";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.BtnStart_Click);
            // 
            // cbbxVersionList
            // 
            this.cbbxVersionList.BackColor = System.Drawing.SystemColors.Window;
            this.cbbxVersionList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbxVersionList.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbbxVersionList.ForeColor = System.Drawing.SystemColors.Highlight;
            this.cbbxVersionList.FormattingEnabled = true;
            this.cbbxVersionList.Location = new System.Drawing.Point(542, 328);
            this.cbbxVersionList.Name = "cbbxVersionList";
            this.cbbxVersionList.Size = new System.Drawing.Size(214, 20);
            this.cbbxVersionList.Sorted = true;
            this.cbbxVersionList.TabIndex = 2;
            // 
            // btnOpenConfig
            // 
            this.btnOpenConfig.FlatAppearance.BorderSize = 0;
            this.btnOpenConfig.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOpenConfig.ForeColor = System.Drawing.SystemColors.Info;
            this.btnOpenConfig.Location = new System.Drawing.Point(681, 285);
            this.btnOpenConfig.Name = "btnOpenConfig";
            this.btnOpenConfig.Size = new System.Drawing.Size(75, 23);
            this.btnOpenConfig.TabIndex = 3;
            this.btnOpenConfig.Text = "Config";
            this.btnOpenConfig.UseVisualStyleBackColor = true;
            this.btnOpenConfig.Click += new System.EventHandler(this.BtnOpenConfig_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(215)))));
            this.ClientSize = new System.Drawing.Size(768, 432);
            this.Controls.Add(this.btnOpenConfig);
            this.Controls.Add(this.cbbxVersionList);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.Exit);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MainForm";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button Exit;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.ComboBox cbbxVersionList;
        private System.Windows.Forms.Button btnOpenConfig;
    }
}