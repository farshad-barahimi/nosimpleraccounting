//Copyright © 2010-2012 , Farshad Barahimi . All rights reserved
//This software is licensed under the Apache License, Version 2.0

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Xml;

namespace Project.UserInterface
{
    public partial class ReportForm : Form
    {
        public ReportForm()
        {
            InitializeComponent();
        }

        private void ViewInBrowserButton_Click(object sender, EventArgs e)
        {
            string reportPath=Application.StartupPath+"\\report.htm";
            string lastText = ViewInBrowserButton.Text;
            ViewInBrowserButton.Text = "Please wait...";
            foreach (Control control in Controls)
                if (control is Button)
                    control.Enabled = false;

            try
            {
                StreamWriter writer = new StreamWriter(reportPath);
                writer.WriteLine(@"<HTML>");
                writer.WriteLine(@"<Header>");
                writer.WriteLine(@"<Title>" + HeaderLabel.Text + @"</Title>");
                writer.WriteLine(@"</Header>");
                writer.WriteLine(@"<body>");
                writer.WriteLine(@"<Table width=""99%"" border=""1"" style=""border-collapse:collapse"" >");
                writer.WriteLine(@"<TR>");
                foreach (DataGridViewColumn col in dataGridView1.Columns)
                {
                    int width = col.Width * 100 / dataGridView1.Width;
                    writer.WriteLine(@"<TD width=" + width + "%>" + col.HeaderText + @"</TD>");
                }
                writer.WriteLine(@"</TR>");

                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    writer.WriteLine(@"<TR>");
                    foreach (DataGridViewCell cell in row.Cells)
                    {
                        int width1 = cell.OwningColumn.Width * 100 / dataGridView1.Width;
                        writer.WriteLine(@"<TD width=" + width1 + "%>" + cell.Value + @"</TD>");
                    }
                    writer.WriteLine(@"</TR>");
                }


                writer.WriteLine(@"</Table>");
                writer.WriteLine(@"</body>");
                writer.WriteLine(@"</HTML>");
                writer.Close();
                System.Diagnostics.Process.Start(reportPath);
            }
            catch
            {
                MessageBox.Show("Error");
            }
            finally
            {
                ViewInBrowserButton.Text = lastText;
                foreach (Control control in Controls)
                    if (control is Button)
                        control.Enabled = true;
            }
        }

        private void ExportToXMLButton_Click(object sender, EventArgs e)
        {
            SaveFileDialog form = new SaveFileDialog();
            form.DefaultExt = ".csv";
            form.Filter = "CSV File(*.csv)|*.csv";

            if (form.ShowDialog() == DialogResult.OK)
            {
                string lastText = ExportToXMLButton.Text;
                ExportToXMLButton.Text = "Please wait...";
                foreach (Control control in Controls)
                    if (control is Button)
                        control.Enabled = false;

                try
                {
                    StreamWriter writer = new StreamWriter(form.FileName);

                    foreach (DataGridViewColumn col in dataGridView1.Columns)
                    {
                        writer.Write("\"" + col.HeaderText.Replace("\"","\"\"") + "\",");
                    }
                    writer.WriteLine();
                    foreach (DataGridViewRow row in dataGridView1.Rows)
                    {
                        foreach (DataGridViewCell cell in row.Cells)
                        {
                            if (cell.Value != null)
                                writer.Write("\"" + cell.Value.ToString().Replace("\"", "\"\"") + "\",");
                            else
                                writer.Write("\"\",");
                        }
                        writer.WriteLine();
                    }

                    writer.Close();

                    MessageBox.Show("Report exported successfully");
                }
                catch
                {
                    MessageBox.Show("Error");
                }
                finally
                {
                    ExportToXMLButton.Text = lastText;
                    foreach (Control control in Controls)
                        if (control is Button)
                            control.Enabled = true;
                }
            }
        }
    }
}
