namespace Project.UserInterface
{
    partial class ReportForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ReportForm));
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Icons = new System.Windows.Forms.ImageList(this.components);
            this.ViewInBrowserButton = new System.Windows.Forms.Button();
            this.HeaderLabel = new System.Windows.Forms.Label();
            this.ExportToXMLButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.Gainsboro;
            this.dataGridView1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.BackgroundColor = System.Drawing.Color.Maroon;
            this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 71);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(694, 342);
            this.dataGridView1.TabIndex = 0;
            // 
            // Icons
            // 
            this.Icons.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("Icons.ImageStream")));
            this.Icons.TransparentColor = System.Drawing.Color.Transparent;
            this.Icons.Images.SetKeyName(0, "fileprint.png");
            this.Icons.Images.SetKeyName(1, "spreadsheet_document.png");
            this.Icons.Images.SetKeyName(2, "kexi_kexi.png");
            // 
            // ViewInBrowserButton
            // 
            this.ViewInBrowserButton.ImageIndex = 0;
            this.ViewInBrowserButton.ImageList = this.Icons;
            this.ViewInBrowserButton.Location = new System.Drawing.Point(12, 12);
            this.ViewInBrowserButton.Name = "ViewInBrowserButton";
            this.ViewInBrowserButton.Size = new System.Drawing.Size(145, 40);
            this.ViewInBrowserButton.TabIndex = 2;
            this.ViewInBrowserButton.Text = "Print in web browser";
            this.ViewInBrowserButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.ViewInBrowserButton.UseVisualStyleBackColor = true;
            this.ViewInBrowserButton.Click += new System.EventHandler(this.ViewInBrowserButton_Click);
            // 
            // HeaderLabel
            // 
            this.HeaderLabel.AutoSize = true;
            this.HeaderLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.HeaderLabel.ForeColor = System.Drawing.Color.White;
            this.HeaderLabel.Location = new System.Drawing.Point(303, 21);
            this.HeaderLabel.Name = "HeaderLabel";
            this.HeaderLabel.Size = new System.Drawing.Size(70, 20);
            this.HeaderLabel.TabIndex = 3;
            this.HeaderLabel.Text = "[Header]";
            // 
            // ExportToXMLButton
            // 
            this.ExportToXMLButton.ImageIndex = 1;
            this.ExportToXMLButton.ImageList = this.Icons;
            this.ExportToXMLButton.Location = new System.Drawing.Point(163, 12);
            this.ExportToXMLButton.Name = "ExportToXMLButton";
            this.ExportToXMLButton.Size = new System.Drawing.Size(122, 40);
            this.ExportToXMLButton.TabIndex = 4;
            this.ExportToXMLButton.Text = "Export to Excel";
            this.ExportToXMLButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.ExportToXMLButton.UseVisualStyleBackColor = true;
            this.ExportToXMLButton.Click += new System.EventHandler(this.ExportToXMLButton_Click);
            // 
            // ReportForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Maroon;
            this.ClientSize = new System.Drawing.Size(718, 425);
            this.Controls.Add(this.ExportToXMLButton);
            this.Controls.Add(this.HeaderLabel);
            this.Controls.Add(this.ViewInBrowserButton);
            this.Controls.Add(this.dataGridView1);
            this.Name = "ReportForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Report Form";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ImageList Icons;
        private System.Windows.Forms.Button ViewInBrowserButton;
        public System.Windows.Forms.DataGridView dataGridView1;
        public System.Windows.Forms.Label HeaderLabel;
        private System.Windows.Forms.Button ExportToXMLButton;
    }
}