namespace Project.UserInterface
{
    partial class IDForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.IDTextBox = new System.Windows.Forms.TextBox();
            this.MyOkButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(34, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(86, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Please enter ID :";
            // 
            // IDTextBox
            // 
            this.IDTextBox.Location = new System.Drawing.Point(37, 48);
            this.IDTextBox.Name = "IDTextBox";
            this.IDTextBox.Size = new System.Drawing.Size(100, 20);
            this.IDTextBox.TabIndex = 1;
            // 
            // MyOkButton
            // 
            this.MyOkButton.Location = new System.Drawing.Point(154, 37);
            this.MyOkButton.Name = "MyOkButton";
            this.MyOkButton.Size = new System.Drawing.Size(90, 40);
            this.MyOkButton.TabIndex = 2;
            this.MyOkButton.Text = "OK";
            this.MyOkButton.UseVisualStyleBackColor = true;
            this.MyOkButton.Click += new System.EventHandler(this.MyOkButton_Click);
            // 
            // IDForm
            // 
            this.AcceptButton = this.MyOkButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Maroon;
            this.ClientSize = new System.Drawing.Size(296, 104);
            this.Controls.Add(this.MyOkButton);
            this.Controls.Add(this.IDTextBox);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "IDForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Please enter ID";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox IDTextBox;
        private System.Windows.Forms.Button MyOkButton;
    }
}