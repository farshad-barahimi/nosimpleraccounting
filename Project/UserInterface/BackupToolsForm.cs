//Copyright © 2010-2012 , Farshad Barahimi . All rights reserved
//This software is licensed under the Apache License, Version 2.0

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;

namespace Project.UserInterface
{
    public partial class BackupToolsForm : Form
    {
        public BackupToolsForm()
        {
            InitializeComponent();
        }

        private void BackupButton_Click(object sender, EventArgs e)
        {
            SaveFileDialog form = new SaveFileDialog();
            form.DefaultExt = ".nsa";
            form.Filter = "Backup files(*.nsa)|*.nsa";
            if (form.ShowDialog() == DialogResult.OK)
            {
                string lastText = BackupButton.Text;
                BackupButton.Enabled = false;
                RestoreButton.Enabled = false;
                BackupButton.Text = "Please wait ...";

                try
                {
                    System.IO.File.Copy(Statics.ApplicationPath + "\\Database.mdb", form.FileName);
                    MessageBox.Show("Backup created successfuly");
                }
                catch
                {
                    MessageBox.Show("Error in creating backup");
                }
                finally
                {
                    BackupButton.Text = lastText;
                    BackupButton.Enabled = true;
                    RestoreButton.Enabled = true;
                }
            }
        }

        private void RestoreButton_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("By restoring database , All current data will be deleted. Are you sure", "Warning", MessageBoxButtons.YesNo) != DialogResult.Yes)
                return;
            OpenFileDialog form = new OpenFileDialog();
            form.Filter = "Backup files(*.nsa,*.bak)|*.nsa;*.bak";
            if (form.ShowDialog() == DialogResult.OK)
            {
                int DBVersion = Statics.DataMapper.GetFileDBVersion(form.FileName);
                if (DBVersion==-1)
                {
                    MessageBox.Show("The file you selected is not a NoSimplerAccounting backup or it is from newer version of software");
                    return;
                }
                if (DBVersion == 1)
                {
                    string s = "The file you selected is a backup for previous versions of NosimplerAccounting (version <= 3.0).\n";
                    s += "All expenses will be moved to General Expense category. Continue ?";
                    if (MessageBox.Show(s, "Warning", MessageBoxButtons.YesNo) != DialogResult.Yes)
                        return;
                    if(Statics.DataMapper.ImportFromDBVersion1(form.FileName))
                        MessageBox.Show("Backup imported successfuly");
                    else
                        MessageBox.Show("There was an error in importing data.");
                    return;
                }

                if (DBVersion != 2)
                {
                    MessageBox.Show("The file you selected is from newer version of software. It can't be restored.");
                    return;
                }

                string lastText = RestoreButton.Text;
                BackupButton.Enabled = false;
                RestoreButton.Enabled = false;
                RestoreButton.Text = "Please wait ...";
                
                Statics.DataMapper.CloseConnection();

                try
                {
                    System.IO.File.Copy(form.FileName, Statics.ApplicationPath + "\\Database.mdb",true);
                    MessageBox.Show("Backup restored successfuly");
                }
                catch
                {
                    MessageBox.Show("Error in restoring backup");
                }
                finally
                {
                    Statics.DataMapper.OpenConnection();
                    RestoreButton.Text = lastText;
                    BackupButton.Enabled = true;
                    RestoreButton.Enabled = true;
                }
            }
        }
    }
}
