namespace Project.UserInterface
{
    partial class CategoryForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CategoryForm));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.NameTextBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.SaveOrDeleteButton = new System.Windows.Forms.Button();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.MyCancelButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(24, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "ID :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(42, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(24, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "[ID]";
            // 
            // NameTextBox
            // 
            this.NameTextBox.Location = new System.Drawing.Point(59, 37);
            this.NameTextBox.MaxLength = 25;
            this.NameTextBox.Name = "NameTextBox";
            this.NameTextBox.Size = new System.Drawing.Size(275, 20);
            this.NameTextBox.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(12, 40);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Name :";
            // 
            // SaveOrDeleteButton
            // 
            this.SaveOrDeleteButton.ImageIndex = 0;
            this.SaveOrDeleteButton.ImageList = this.imageList1;
            this.SaveOrDeleteButton.Location = new System.Drawing.Point(45, 80);
            this.SaveOrDeleteButton.Name = "SaveOrDeleteButton";
            this.SaveOrDeleteButton.Size = new System.Drawing.Size(116, 40);
            this.SaveOrDeleteButton.TabIndex = 4;
            this.SaveOrDeleteButton.Text = "Save";
            this.SaveOrDeleteButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.SaveOrDeleteButton.UseVisualStyleBackColor = true;
            this.SaveOrDeleteButton.Click += new System.EventHandler(this.SaveOrDeleteButton_Click);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "filesave.png");
            this.imageList1.Images.SetKeyName(1, "agt_action_fail.png");
            this.imageList1.Images.SetKeyName(2, "button_cancel.png");
            // 
            // MyCancelButton
            // 
            this.MyCancelButton.ImageIndex = 1;
            this.MyCancelButton.ImageList = this.imageList1;
            this.MyCancelButton.Location = new System.Drawing.Point(167, 80);
            this.MyCancelButton.Name = "MyCancelButton";
            this.MyCancelButton.Size = new System.Drawing.Size(116, 40);
            this.MyCancelButton.TabIndex = 5;
            this.MyCancelButton.Text = "Cancel";
            this.MyCancelButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.MyCancelButton.UseVisualStyleBackColor = true;
            this.MyCancelButton.Click += new System.EventHandler(this.MyCancelButton_Click);
            // 
            // CategoryForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Maroon;
            this.ClientSize = new System.Drawing.Size(346, 156);
            this.Controls.Add(this.MyCancelButton);
            this.Controls.Add(this.SaveOrDeleteButton);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.NameTextBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CategoryForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "CategoryFrom";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox NameTextBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button SaveOrDeleteButton;
        private System.Windows.Forms.Button MyCancelButton;
        private System.Windows.Forms.ImageList imageList1;
    }
}