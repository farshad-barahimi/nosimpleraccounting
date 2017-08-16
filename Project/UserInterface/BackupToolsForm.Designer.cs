namespace Project.UserInterface
{
    partial class BackupToolsForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BackupToolsForm));
            this.BackupButton = new System.Windows.Forms.Button();
            this.Icons = new System.Windows.Forms.ImageList(this.components);
            this.RestoreButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // BackupButton
            // 
            this.BackupButton.ImageIndex = 0;
            this.BackupButton.ImageList = this.Icons;
            this.BackupButton.Location = new System.Drawing.Point(42, 38);
            this.BackupButton.Name = "BackupButton";
            this.BackupButton.Size = new System.Drawing.Size(149, 40);
            this.BackupButton.TabIndex = 0;
            this.BackupButton.Text = "Backup database";
            this.BackupButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.BackupButton.UseVisualStyleBackColor = true;
            this.BackupButton.Click += new System.EventHandler(this.BackupButton_Click);
            // 
            // Icons
            // 
            this.Icons.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("Icons.ImageStream")));
            this.Icons.TransparentColor = System.Drawing.Color.Transparent;
            this.Icons.Images.SetKeyName(0, "redo.png");
            this.Icons.Images.SetKeyName(1, "undo.png");
            // 
            // RestoreButton
            // 
            this.RestoreButton.ImageIndex = 1;
            this.RestoreButton.ImageList = this.Icons;
            this.RestoreButton.Location = new System.Drawing.Point(42, 102);
            this.RestoreButton.Name = "RestoreButton";
            this.RestoreButton.Size = new System.Drawing.Size(149, 40);
            this.RestoreButton.TabIndex = 1;
            this.RestoreButton.Text = "Restore database";
            this.RestoreButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.RestoreButton.UseVisualStyleBackColor = true;
            this.RestoreButton.Click += new System.EventHandler(this.RestoreButton_Click);
            // 
            // BackupToolsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Maroon;
            this.ClientSize = new System.Drawing.Size(241, 185);
            this.Controls.Add(this.RestoreButton);
            this.Controls.Add(this.BackupButton);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "BackupToolsForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Backup Tools";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button BackupButton;
        private System.Windows.Forms.Button RestoreButton;
        private System.Windows.Forms.ImageList Icons;
    }
}