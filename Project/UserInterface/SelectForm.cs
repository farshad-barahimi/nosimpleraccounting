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
    public partial class SelectForm : Form
    {
        public object ReturnItem;
        public bool IsOK = false;
        private RecordType selectType;
        public SelectForm(RecordType selectType)
        {
            InitializeComponent();
            this.selectType=selectType;

            switch (selectType)
            {
                case RecordType.Income:
                    this.Text = "Select Income Category";
                    List<Category> incomeCategories = Statics.DataMapper.GetIncomeCategories();
                    foreach (Category incomeCategory in incomeCategories)
                    {
                        dataGridView1.Rows.Add();
                        int lastIndex = dataGridView1.Rows.Count - 1;
                        dataGridView1.Rows[lastIndex].Cells[0].Value = "IC-" + incomeCategory.ID.ToString();
                        dataGridView1.Rows[lastIndex].Cells[1].Value = incomeCategory.Name;
                    }
                    break;
                case RecordType.Expense:
                    this.Text = "Select Expense Category";
                    List<Category> expenseCategories = Statics.DataMapper.GetExpenseCategories();
                    foreach (Category expenseCategory in expenseCategories)
                    {
                        dataGridView1.Rows.Add();
                        int lastIndex = dataGridView1.Rows.Count - 1;
                        dataGridView1.Rows[lastIndex].Cells[0].Value = "EC-" + expenseCategory.ID.ToString();
                        dataGridView1.Rows[lastIndex].Cells[1].Value = expenseCategory.Name;
                    }
                    break;
            }

        }

        private void SelectButton_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
                return;
            string s = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            int id;
            switch (selectType)
            {
                case RecordType.Income:
                    s = s.Substring(3);
                    id = int.Parse(s);
                    ReturnItem = Statics.DataMapper.GetIncomeCategoryByID(id);
                    IsOK = true;
                    this.Close();
                    break;
                case RecordType.Expense:
                    s = s.Substring(3);
                    id = int.Parse(s);
                    ReturnItem = Statics.DataMapper.GetExpenseCategoryByID(id);
                    IsOK = true;
                    this.Close();
                    break;
            }
        }

        private void MyCancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            SelectButton_Click(sender, e);
        }

        private void SearchTextBox_TextChanged(object sender, EventArgs e)
        {
            if (SearchTextBox.Text.Length == 0)
            {
                if (dataGridView1.Rows.Count != 0)
                    dataGridView1.Rows[0].Selected = true;
                return;
            }
            string strToFind = SearchTextBox.Text.ToLower();
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                string s = row.Cells[1].Value.ToString().ToLower();
                if (s.IndexOf(SearchTextBox.Text) != -1)
                    row.Selected = true;
            }
        }
    }
}
