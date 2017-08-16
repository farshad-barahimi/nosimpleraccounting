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
    public partial class WarningForm : Form
    {
        public bool IsOK = false;
        public WarningForm()
        {
            InitializeComponent();
        }

        private void DeclineButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void AcceptButton_Click(object sender, EventArgs e)
        {
            IsOK = true;
            this.Close();
        }
    }
}
