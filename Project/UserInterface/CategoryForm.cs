//Copyright © 2010-2012 , Farshad Barahimi . All rights reserved
//This software is licensed under the Apache License, Version 2.0

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Project.ModelClasses;

namespace Project.UserInterface
{
    public partial class CategoryForm : Form
    {
        private ActionType actionType;
        private RecordType categoryType;
        private int ID;
        public bool IsOK = false;
        public CategoryForm(int ID,ActionType actionType,RecordType categoryType,Category category)
        {
            this.ID = ID;
            this.actionType = actionType;
            this.categoryType = categoryType;
            InitializeComponent();

            switch (actionType)
            {
                case ActionType.Add:
                    this.Text = "New ";
                    break;
                case ActionType.Modify:
                    this.Text = "Modify ";
                    break;
                case ActionType.Remove:
                    this.Text = "Remove ";
                    SaveOrDeleteButton.ImageIndex = 2;
                    foreach (Control control in this.Controls)
                    {
                        if (!(control is Label))
                            control.Enabled = false;
                    }
                    SaveOrDeleteButton.Enabled = true;
                    SaveOrDeleteButton.Text = "Delete";
                    MyCancelButton.Enabled = true;
                    break;
            }

            switch (categoryType)
            {
                case RecordType.Income:
                    this.Text += "Income Category";
                    label2.Text = "IC-" + ID.ToString();
                    break;
                case RecordType.Expense:
                    this.Text += "Expense Category";
                    label2.Text = "EC-" + ID.ToString();
                    break;
            }

            if ((actionType == ActionType.Modify || actionType == ActionType.Remove))
            {
                NameTextBox.Text = category.Name;
            }

        }

        private void MyCancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void SaveOrDeleteButton_Click(object sender, EventArgs e)
        {
            if (NameTextBox.Text.IndexOf("'") != -1)
            {
                MessageBox.Show("Name cannot have ' character");
                return;
            }

            if (actionType == ActionType.Add)
            {
                switch (categoryType)
                {
                    case RecordType.Income:
                        Statics.DataMapper.AddIncomeCategory(new Category(ID,NameTextBox.Text));
                        break;
                    case RecordType.Expense:
                        Statics.DataMapper.AddExpenseCategory(new Category(ID, NameTextBox.Text));
                        break;
                }
                IsOK = true;
                this.Close();
            }

            if ((actionType == ActionType.Modify || actionType == ActionType.Remove) && ID == 1)
            {
                MessageBox.Show("General category cannot be modified or deleted");
                return;
            }

            if (actionType == ActionType.Modify)
            {
                switch (categoryType)
                {
                    case RecordType.Income:
                        Statics.DataMapper.UpdateIncomeCategory(new Category(ID, NameTextBox.Text));
                        break;
                    case RecordType.Expense:
                        Statics.DataMapper.UpdateExpenseCategory(new Category(ID, NameTextBox.Text));
                        break;
                }
                this.Close();
            }

            if (actionType == ActionType.Remove)
            {
                switch (categoryType)
                {
                    case RecordType.Income:
                        if (Statics.DataMapper.IsIncomeCategoryEmpty(ID))
                            Statics.DataMapper.RemoveIncomeCategory(ID);
                        else
                        {
                            MessageBox.Show("This category is not empty, it cannot be deleted.");
                            return;
                        }
                        break;
                    case RecordType.Expense:
                        if (Statics.DataMapper.IsExpenseCategoryEmpty(ID))
                            Statics.DataMapper.RemoveExpenseCategory(ID);
                        else
                        {
                            MessageBox.Show("This category is not empty, it cannot be deleted.");
                            return;
                        }
                        break;
                }
                this.Close();
            }
        }
    }
}
