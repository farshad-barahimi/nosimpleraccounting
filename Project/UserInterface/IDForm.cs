//Copyright © 2010-2012 , Farshad Barahimi . All rights reserved
//This software is licensed under the Apache License, Version 2.0

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Project.UserInterface
{
    public partial class IDForm : Form
    {
        private RecordType IDType;
        public object ReturnItem;
        public bool IsOK = false;
        public IDForm(RecordType IDType)
        {
            this.IDType = IDType;
            InitializeComponent();

            switch (IDType)
            {
                case RecordType.Income:
                    IDTextBox.Text = "I-";
                    IDTextBox.SelectionStart = 2;
                    IDTextBox.SelectionLength = 0;
                    break;
                case RecordType.Expense:
                    IDTextBox.Text = "E-";
                    IDTextBox.SelectionStart = 2;
                    IDTextBox.SelectionLength = 0;
                    break;
            }
        }

        private void MyOkButton_Click(object sender, EventArgs e)
        {
            if (IDType == RecordType.Income)
            {
                if (IDTextBox.Text.Substring(0, 2) != "I-")
                {
                    MessageBox.Show("Please enter ID in currect fromat");
                    return;
                }

                string s = IDTextBox.Text.Substring(2);
                int id;
                try
                {
                    id = int.Parse(s);
                }
                catch
                {
                    MessageBox.Show("Please enter ID in currect fromat");
                    return;
                }
                ReturnItem = Statics.DataMapper.GetIncomeByID(id);
                if (ReturnItem != null)
                {
                    IsOK = true;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("There is no record with this ID");
                    return;
                }
            }

            if (IDType == RecordType.Expense)
            {
                if (IDTextBox.Text.Substring(0, 2) != "E-")
                {
                    MessageBox.Show("Please enter ID in currect fromat");
                    return;
                }

                string s = IDTextBox.Text.Substring(2);
                int id;
                try
                {
                    id = int.Parse(s);
                }
                catch
                {
                    MessageBox.Show("Please enter ID in currect fromat");
                    return;
                }
                ReturnItem = Statics.DataMapper.GetExpenseByID(id);
                if (ReturnItem != null)
                {
                    IsOK = true;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("There is no record with this ID");
                    return;
                }
            }
        }
    }
}
