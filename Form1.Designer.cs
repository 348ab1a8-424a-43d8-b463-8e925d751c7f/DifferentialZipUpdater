namespace DifferentialZipUpdater
{
    partial class Form1
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
            this.updateButton = new System.Windows.Forms.Button();
            this.revertButton = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.forceUpdateButton = new System.Windows.Forms.Button();
            this.folderPath = new System.Windows.Forms.Label();
            this.folderPathUrl = new System.Windows.Forms.TextBox();
            this.BrowseButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // updateButton
            // 
            this.updateButton.Location = new System.Drawing.Point(13, 59);
            this.updateButton.Name = "updateButton";
            this.updateButton.Size = new System.Drawing.Size(425, 52);
            this.updateButton.TabIndex = 0;
            this.updateButton.Text = "Update to Latest Version";
            this.updateButton.UseVisualStyleBackColor = true;
            this.updateButton.Click += new System.EventHandler(this.updateButton_Click);
            // 
            // revertButton
            // 
            this.revertButton.Location = new System.Drawing.Point(13, 117);
            this.revertButton.Name = "revertButton";
            this.revertButton.Size = new System.Drawing.Size(425, 52);
            this.revertButton.TabIndex = 1;
            this.revertButton.Text = "Revert to Previous Version";
            this.revertButton.UseVisualStyleBackColor = true;
            this.revertButton.Click += new System.EventHandler(this.revertButton_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(13, 175);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(425, 52);
            this.button3.TabIndex = 2;
            this.button3.Text = "button3";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // forceUpdateButton
            // 
            this.forceUpdateButton.Location = new System.Drawing.Point(13, 233);
            this.forceUpdateButton.Name = "forceUpdateButton";
            this.forceUpdateButton.Size = new System.Drawing.Size(425, 52);
            this.forceUpdateButton.TabIndex = 3;
            this.forceUpdateButton.Text = "Force Update";
            this.forceUpdateButton.UseVisualStyleBackColor = true;
            this.forceUpdateButton.Click += new System.EventHandler(this.forceUpdateButton_Click);
            // 
            // folderPath
            // 
            this.folderPath.AutoSize = true;
            this.folderPath.Location = new System.Drawing.Point(14, 16);
            this.folderPath.Name = "folderPath";
            this.folderPath.Size = new System.Drawing.Size(68, 13);
            this.folderPath.TabIndex = 4;
            this.folderPath.Text = "Folder PATH";
            // 
            // folderPathUrl
            // 
            this.folderPathUrl.Enabled = false;
            this.folderPathUrl.Location = new System.Drawing.Point(88, 12);
            this.folderPathUrl.Name = "folderPathUrl";
            this.folderPathUrl.Size = new System.Drawing.Size(269, 20);
            this.folderPathUrl.TabIndex = 5;
            // 
            // BrowseButton
            // 
            this.BrowseButton.Location = new System.Drawing.Point(363, 11);
            this.BrowseButton.Name = "BrowseButton";
            this.BrowseButton.Size = new System.Drawing.Size(75, 23);
            this.BrowseButton.TabIndex = 6;
            this.BrowseButton.Text = "Browse";
            this.BrowseButton.UseVisualStyleBackColor = true;
            this.BrowseButton.Click += new System.EventHandler(this.BrowseButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(458, 301);
            this.Controls.Add(this.BrowseButton);
            this.Controls.Add(this.folderPathUrl);
            this.Controls.Add(this.folderPath);
            this.Controls.Add(this.forceUpdateButton);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.revertButton);
            this.Controls.Add(this.updateButton);
            this.Name = "Form1";
            this.Text = "Differential Zip Updater";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button updateButton;
        private System.Windows.Forms.Button revertButton;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button forceUpdateButton;
        private System.Windows.Forms.Label folderPath;
        private System.Windows.Forms.TextBox folderPathUrl;
        private System.Windows.Forms.Button BrowseButton;
    }
}

