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
using System.IO;

namespace Project.UserInterface
{
    public partial class MainForm : Form
    {
        const int LeftButtonsNormalWidth = 246;
        const int LeftButtonsNormalHeight = 61;
        const int LeftButtonsExtendedWidth = 264;
        private Label WaitLabel;

        public MainForm()
        {
            InitializeComponent();
            init();
        }
        private void MainForm_Load(object sender, EventArgs e)
        {
            Statics.ApplicationPath = Application.StartupPath;

            WarningForm form = new WarningForm();
            form.Icon = this.Icon;
            form.ShowDialog();
            if (!form.IsOK)
            {
                this.Close();
                return;
            }
            
            Statics.Today = new MyDate(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
            Statics.LastUsedDate = new MyDate(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
            string connectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + Statics.ApplicationPath + "\\Database.mdb;Jet OLEDB:Database Password=1;";
            Statics.DataMapper = new Project.DataLayer.DataMapper(connectionString);

            if (Statics.DataMapper.IsError)
                this.Close();
        }
        
        private void init()
        {
            tabControl1.Location = new Point(tabControl1.Location.X, -40);

            WaitLabel = new Label();
            WaitLabel.Text = "Please wait ...";
            Font font = new Font(WaitLabel.Font.FontFamily, 20);
            WaitLabel.Font = font;
            WaitLabel.Location = new Point(400, 250);
            WaitLabel.Visible = true;
            WaitLabel.AutoSize = true;
            this.Controls.Add(WaitLabel);
        }


        #region Tabs

        private void updateTabs(int selectedTab)
        {
            foreach (Control control in panel1.Controls)
            {
                if (control is Button)
                {
                    control.BackColor = Color.SteelBlue;
                    control.ForeColor = Color.White;
                    control.Size = new Size(LeftButtonsNormalWidth, LeftButtonsNormalHeight);
                }
            }

            tabControl1.SelectedIndex = selectedTab - 1;
            
            Button button = null;
            switch (selectedTab)
            {
                case 1:
                    button = HomeTabButton;
                    break;
                case 2:
                    button = EnterTabButton;
                    break;
                case 3:
                    button = ModifyTabButton;
                    break;
                case 4:
                    button = RemoveTabButton;
                    break;
                case 5:
                    button = ReportsTabButton;
                    break;
                case 6:
                    button = AboutTabButton;
                    break;
            }

            if (button != null)
            {
                button.Size = new Size(LeftButtonsExtendedWidth, LeftButtonsNormalHeight);
                button.BackColor = Color.White;
                button.ForeColor = Color.Black;
            }
        }
        private void HomeTabButton_Click(object sender, EventArgs e)
        {
            updateTabs(1);
        }
        private void EnterTabButton_Click(object sender, EventArgs e)
        {
            updateTabs(2);
        }
        private void ModifyTabButton_Click(object sender, EventArgs e)
        {
            updateTabs(3);
        }
        private void RemoveTabButton_Click(object sender, EventArgs e)
        {
            updateTabs(4);
        }
        private void ReportsTabButton_Click(object sender, EventArgs e)
        {
            updateTabs(5);
        }
        private void AboutTabButton_Click(object sender, EventArgs e)
        {
            updateTabs(6);
        }
        
        #endregion

        private void MainForm_Resize(object sender, EventArgs e)
        {
            this.Refresh();
        }

        private void NewIncomeButton_Click(object sender, EventArgs e)
        {
            int id = Statics.DataMapper.GenerateIncomeID();
            IncomeExpenseForm form = new IncomeExpenseForm(ActionType.Add,RecordType.Income,id,null,null);
            form.ShowDialog();
        }

        private void NewExpenseButton_Click(object sender, EventArgs e)
        {
            int id = Statics.DataMapper.GenerateExpenseID();
            IncomeExpenseForm form = new IncomeExpenseForm(ActionType.Add, RecordType.Expense, id, null, null);
            form.ShowDialog();
        }

        private void ModifyIncomeButton_Click(object sender, EventArgs e)
        {
            IDForm form = new IDForm(RecordType.Income);
            form.ShowDialog();
            if (form.IsOK)
            {
                Income income = (Income)form.ReturnItem;
                IncomeExpenseForm form1 = new IncomeExpenseForm(ActionType.Modify, RecordType.Income, income.ID,income,null);
                form1.ShowDialog();
            }
        }

        private void ModifyExpenseButton_Click(object sender, EventArgs e)
        {
            IDForm form = new IDForm(RecordType.Expense);
            form.ShowDialog();
            if (form.IsOK)
            {
                Expense expense = (Expense)form.ReturnItem;
                IncomeExpenseForm form1 = new IncomeExpenseForm(ActionType.Modify, RecordType.Expense, expense.ID, null, expense);
                form1.ShowDialog();
            }
        }

        private void RemoveIncomeButton_Click(object sender, EventArgs e)
        {
            IDForm form = new IDForm(RecordType.Income);
            form.ShowDialog();
            if (form.IsOK)
            {
                Income income = (Income)form.ReturnItem;
                IncomeExpenseForm form1 = new IncomeExpenseForm(ActionType.Remove, RecordType.Income,income.ID, income, null);
                form1.ShowDialog();
            }
        }

        private void RemoveExpenseButton_Click(object sender, EventArgs e)
        {
            IDForm form = new IDForm(RecordType.Expense);
            form.ShowDialog();
            if (form.IsOK)
            {
                Expense expense = (Expense)form.ReturnItem;
                IncomeExpenseForm form1 = new IncomeExpenseForm(ActionType.Remove, RecordType.Expense, expense.ID, null, expense);
                form1.ShowDialog();
            }
        }

        private void NewIncomeCatButton_Click(object sender, EventArgs e)
        {
            int id = Statics.DataMapper.GenerateIncomeCategoryID();
            CategoryForm form = new CategoryForm(id, ActionType.Add, RecordType.Income, null);
            form.ShowDialog();
        }

        private void NewExpenseCatButton_Click(object sender, EventArgs e)
        {
            int id = Statics.DataMapper.GenerateExpenseCategoryID();
            CategoryForm form = new CategoryForm(id, ActionType.Add, RecordType.Expense, null);
            form.ShowDialog();
        }

        private void ModifyIncomeCatButton_Click(object sender, EventArgs e)
        {
            SelectForm form = new SelectForm(RecordType.Income);
            form.ShowDialog();
            if (form.IsOK)
            {
                Category category = (Category)form.ReturnItem;
                CategoryForm form1 = new CategoryForm(category.ID, ActionType.Modify, RecordType.Income, category);
                form1.ShowDialog();
            }
        }

        private void ModifyExpenseCatButton_Click(object sender, EventArgs e)
        {
            SelectForm form = new SelectForm(RecordType.Expense);
            form.ShowDialog();
            if (form.IsOK)
            {
                Category category = (Category)form.ReturnItem;
                CategoryForm form1 = new CategoryForm(category.ID, ActionType.Modify, RecordType.Expense, category);
                form1.ShowDialog();
            }
        }

        private void RemoveIncomeCatButton_Click(object sender, EventArgs e)
        {
            SelectForm form = new SelectForm(RecordType.Income);
            form.ShowDialog();
            if (form.IsOK)
            {
                Category category = (Category)form.ReturnItem;
                CategoryForm form1 = new CategoryForm(category.ID, ActionType.Remove, RecordType.Income, category);
                form1.ShowDialog();
            }
        }

        private void RemoveExpenseCatButton_Click(object sender, EventArgs e)
        {
            SelectForm form = new SelectForm(RecordType.Expense);
            form.ShowDialog();
            if (form.IsOK)
            {
                Category category = (Category)form.ReturnItem;
                CategoryForm form1 = new CategoryForm(category.ID, ActionType.Remove, RecordType.Expense, category);
                form1.ShowDialog();
            }
        }

        private void IncomeReportButton_Click(object sender, EventArgs e)
        {
            ReportDetailsForm form=new ReportDetailsForm();
            form.ShowDialog();
            if(form.IsOK)
            {
                StartWait();

                ReportDetail reportDetais = form.ReturnItem;
                ReportForm form1 = new ReportForm();
                form1.HeaderLabel.Text=" Income report";
                form1.Text = form1.HeaderLabel.Text;
                form1.dataGridView1.Columns.Add("ID", "ID");
                form1.dataGridView1.Columns.Add("Year", "Year");
                form1.dataGridView1.Columns.Add("Month", "Month");
                form1.dataGridView1.Columns.Add("Day", "Day");
                form1.dataGridView1.Columns.Add("Description", "Description");
                form1.dataGridView1.Columns.Add("Amount", "Amount");
                form1.dataGridView1.Columns.Add("Category", "Category");
                
                form1.dataGridView1.Columns["ID"].FillWeight = 1;
                form1.dataGridView1.Columns["Year"].FillWeight = 1;
                form1.dataGridView1.Columns["Month"].FillWeight = 1;
                form1.dataGridView1.Columns["Day"].FillWeight = 1;
                form1.dataGridView1.Columns["Description"].FillWeight = 10;
                form1.dataGridView1.Columns["Amount"].FillWeight = 2;
                form1.dataGridView1.Columns["Category"].FillWeight = 4;

                form1.dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                foreach (DataGridViewColumn col in form1.dataGridView1.Columns)
                    col.SortMode = DataGridViewColumnSortMode.NotSortable;

                double sum = 0;

                List<Income> incomes = Statics.DataMapper.IncomeReport(reportDetais);
                foreach (Income income in incomes)
                {
                    Category category = Statics.DataMapper.GetIncomeCategoryByID(income.CategoryID);
                    form1.dataGridView1.Rows.Add();
                    int lastIndex = form1.dataGridView1.Rows.Count - 1;
                    form1.dataGridView1.Rows[lastIndex].Cells[0].Value = "I-"+income.ID;
                    form1.dataGridView1.Rows[lastIndex].Cells[1].Value = income.Date.Year;
                    form1.dataGridView1.Rows[lastIndex].Cells[2].Value = income.Date.Month;
                    form1.dataGridView1.Rows[lastIndex].Cells[3].Value = income.Date.Day;
                    form1.dataGridView1.Rows[lastIndex].Cells[4].Value = income.Description;
                    form1.dataGridView1.Rows[lastIndex].Cells[5].Value = Math.Round(income.Amount,3);
                    form1.dataGridView1.Rows[lastIndex].Cells[6].Value = category.Name;
                    sum += income.Amount;
                }
                
                form1.dataGridView1.Rows.Add();
                int lastIndex1 = form1.dataGridView1.Rows.Count - 1;
                form1.dataGridView1.Rows[lastIndex1].Cells[0].Value = "Sum";
                form1.dataGridView1.Rows[lastIndex1].Cells[5].Value = Math.Round(sum,3);
                
                foreach (DataGridViewCell cell in form1.dataGridView1.Rows[lastIndex1].Cells)
                    cell.Style.BackColor = Color.Bisque;

                EndWait();
                form1.Show();
            }
        }

        private void ExpenseReportButton_Click(object sender, EventArgs e)
        {
            ReportDetailsForm form = new ReportDetailsForm();
            form.ShowDialog();
            if (form.IsOK)
            {
                StartWait();

                ReportDetail reportDetais = form.ReturnItem;
                ReportForm form1 = new ReportForm();
                form1.HeaderLabel.Text = " Expense report";
                form1.Text = form1.HeaderLabel.Text;
                form1.dataGridView1.Columns.Add("ID", "ID");
                form1.dataGridView1.Columns.Add("Year", "Year");
                form1.dataGridView1.Columns.Add("Month", "Month");
                form1.dataGridView1.Columns.Add("Day", "Day");
                form1.dataGridView1.Columns.Add("Description", "Description");
                form1.dataGridView1.Columns.Add("Amount", "Amount");
                form1.dataGridView1.Columns.Add("Category", "Category");

                form1.dataGridView1.Columns["ID"].FillWeight = 1;
                form1.dataGridView1.Columns["Year"].FillWeight = 1;
                form1.dataGridView1.Columns["Month"].FillWeight = 1;
                form1.dataGridView1.Columns["Day"].FillWeight = 1;
                form1.dataGridView1.Columns["Description"].FillWeight = 10;
                form1.dataGridView1.Columns["Amount"].FillWeight = 2;
                form1.dataGridView1.Columns["Category"].FillWeight = 4;

                form1.dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                foreach (DataGridViewColumn col in form1.dataGridView1.Columns)
                    col.SortMode = DataGridViewColumnSortMode.NotSortable;

                double sum = 0;

                List<Expense> expenses = Statics.DataMapper.ExpenseReport(reportDetais);
                foreach (Expense expense in expenses)
                {
                    Category category = Statics.DataMapper.GetExpenseCategoryByID(expense.CategoryID);
                    form1.dataGridView1.Rows.Add();
                    int lastIndex = form1.dataGridView1.Rows.Count - 1;
                    form1.dataGridView1.Rows[lastIndex].Cells[0].Value = "E-" + expense.ID;
                    form1.dataGridView1.Rows[lastIndex].Cells[1].Value = expense.Date.Year;
                    form1.dataGridView1.Rows[lastIndex].Cells[2].Value = expense.Date.Month;
                    form1.dataGridView1.Rows[lastIndex].Cells[3].Value = expense.Date.Day;
                    form1.dataGridView1.Rows[lastIndex].Cells[4].Value = expense.Description;
                    form1.dataGridView1.Rows[lastIndex].Cells[5].Value = Math.Round(expense.Amount,3);
                    form1.dataGridView1.Rows[lastIndex].Cells[6].Value = category.Name;
                    sum += expense.Amount;
                }

                form1.dataGridView1.Rows.Add();
                int lastIndex1 = form1.dataGridView1.Rows.Count - 1;
                form1.dataGridView1.Rows[lastIndex1].Cells[0].Value = "Sum";
                form1.dataGridView1.Rows[lastIndex1].Cells[5].Value = Math.Round(sum,3);

                foreach (DataGridViewCell cell in form1.dataGridView1.Rows[lastIndex1].Cells)
                    cell.Style.BackColor = Color.Bisque;

                EndWait();
                form1.Show();
            }
        }

        private void IncomeCatReportButton_Click(object sender, EventArgs e)
        {
            SelectForm selectForm = new SelectForm(RecordType.Income);
            selectForm.ShowDialog();
            if (selectForm.IsOK)
            {
                Category category = (Category)selectForm.ReturnItem;

                ReportDetailsForm form = new ReportDetailsForm();
                form.ShowDialog();
                if (form.IsOK)
                {
                    StartWait();

                    ReportDetail reportDetais = form.ReturnItem;
                    ReportForm form1 = new ReportForm();
                    form1.HeaderLabel.Text = " Income Category Report";
                    form1.Text = form1.HeaderLabel.Text;
                    form1.dataGridView1.Columns.Add("ID", "ID");
                    form1.dataGridView1.Columns.Add("Year", "Year");
                    form1.dataGridView1.Columns.Add("Month", "Month");
                    form1.dataGridView1.Columns.Add("Day", "Day");
                    form1.dataGridView1.Columns.Add("Description", "Description");
                    form1.dataGridView1.Columns.Add("Amount", "Amount");

                    form1.dataGridView1.Columns["ID"].FillWeight = 1;
                    form1.dataGridView1.Columns["Year"].FillWeight = 1;
                    form1.dataGridView1.Columns["Month"].FillWeight = 1;
                    form1.dataGridView1.Columns["Day"].FillWeight = 1;
                    form1.dataGridView1.Columns["Description"].FillWeight = 10;
                    form1.dataGridView1.Columns["Amount"].FillWeight = 2;

                    foreach (DataGridViewColumn col in form1.dataGridView1.Columns)
                        col.SortMode = DataGridViewColumnSortMode.NotSortable;

                    form1.dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                    double sum = 0;
                    List<Income> incomes = Statics.DataMapper.IncomeCategoryReport(reportDetais,category);
                    foreach (Income income in incomes)
                    {
                        form1.dataGridView1.Rows.Add();
                        int lastIndex = form1.dataGridView1.Rows.Count - 1;
                        form1.dataGridView1.Rows[lastIndex].Cells[0].Value = "I-" + income.ID;
                        form1.dataGridView1.Rows[lastIndex].Cells[1].Value = income.Date.Year;
                        form1.dataGridView1.Rows[lastIndex].Cells[2].Value = income.Date.Month;
                        form1.dataGridView1.Rows[lastIndex].Cells[3].Value = income.Date.Day;
                        form1.dataGridView1.Rows[lastIndex].Cells[4].Value = income.Description;
                        form1.dataGridView1.Rows[lastIndex].Cells[5].Value = Math.Round(income.Amount,3);
                        sum += income.Amount;
                    }

                    form1.dataGridView1.Rows.Add();
                    int lastIndex1 = form1.dataGridView1.Rows.Count - 1;
                    form1.dataGridView1.Rows[lastIndex1].Cells[0].Value = "Sum";
                    form1.dataGridView1.Rows[lastIndex1].Cells[5].Value = Math.Round(sum,3);

                    foreach (DataGridViewCell cell in form1.dataGridView1.Rows[lastIndex1].Cells)
                        cell.Style.BackColor = Color.Bisque;

                    EndWait();
                    form1.Show();
                }
            }
        }

        private void ExpenseCatReportButton_Click(object sender, EventArgs e)
        {
            SelectForm selectForm = new SelectForm(RecordType.Expense);
            selectForm.ShowDialog();
            if (selectForm.IsOK)
            {
                Category category = (Category)selectForm.ReturnItem;

                ReportDetailsForm form = new ReportDetailsForm();
                form.ShowDialog();
                if (form.IsOK)
                {
                    StartWait();

                    ReportDetail reportDetais = form.ReturnItem;
                    ReportForm form1 = new ReportForm();
                    form1.HeaderLabel.Text = " Expense Category Report";
                    form1.Text = form1.HeaderLabel.Text;

                    form1.dataGridView1.Columns.Add("ID", "ID");
                    form1.dataGridView1.Columns.Add("Year", "Year");
                    form1.dataGridView1.Columns.Add("Month", "Month");
                    form1.dataGridView1.Columns.Add("Day", "Day");
                    form1.dataGridView1.Columns.Add("Description", "Description");
                    form1.dataGridView1.Columns.Add("Amount", "Amount");

                    form1.dataGridView1.Columns["ID"].FillWeight = 1;
                    form1.dataGridView1.Columns["Year"].FillWeight = 1;
                    form1.dataGridView1.Columns["Month"].FillWeight = 1;
                    form1.dataGridView1.Columns["Day"].FillWeight = 1;
                    form1.dataGridView1.Columns["Description"].FillWeight = 10;
                    form1.dataGridView1.Columns["Amount"].FillWeight = 2;

                    form1.dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                    foreach (DataGridViewColumn col in form1.dataGridView1.Columns)
                        col.SortMode = DataGridViewColumnSortMode.NotSortable;

                    double sum = 0;
                    List<Expense> expenses = Statics.DataMapper.ExpenseCategoryReport(reportDetais,category);
                    foreach (Expense expense in expenses)
                    {
                        form1.dataGridView1.Rows.Add();
                        int lastIndex = form1.dataGridView1.Rows.Count - 1;
                        form1.dataGridView1.Rows[lastIndex].Cells[0].Value = "I-" + expense.ID;
                        form1.dataGridView1.Rows[lastIndex].Cells[1].Value = expense.Date.Year;
                        form1.dataGridView1.Rows[lastIndex].Cells[2].Value = expense.Date.Month;
                        form1.dataGridView1.Rows[lastIndex].Cells[3].Value = expense.Date.Day;
                        form1.dataGridView1.Rows[lastIndex].Cells[4].Value = expense.Description;
                        form1.dataGridView1.Rows[lastIndex].Cells[5].Value = Math.Round(expense.Amount,3);
                        sum += expense.Amount;
                    }

                    form1.dataGridView1.Rows.Add();
                    int lastIndex1 = form1.dataGridView1.Rows.Count - 1;
                    form1.dataGridView1.Rows[lastIndex1].Cells[0].Value = "Sum";
                    form1.dataGridView1.Rows[lastIndex1].Cells[5].Value = Math.Round(sum,3);

                    foreach (DataGridViewCell cell in form1.dataGridView1.Rows[lastIndex1].Cells)
                        cell.Style.BackColor = Color.Bisque;

                    EndWait();
                    form1.Show();
                }
            }
        }

        private void IncomeCatSummaryButton_Click(object sender, EventArgs e)
        {
            ReportDetailsForm form = new ReportDetailsForm();
            form.ShowDialog();
            if (form.IsOK)
            {
                StartWait();

                ReportDetail reportDetais = form.ReturnItem;
                ReportForm form1 = new ReportForm();
                form1.HeaderLabel.Text = " Income Categories Summary";
                form1.Text = form1.HeaderLabel.Text;
                form1.dataGridView1.Columns.Add("ID", "Category ID");
                form1.dataGridView1.Columns.Add("CategoryName", "Category name");
                form1.dataGridView1.Columns.Add("Total", "Total");

                form1.dataGridView1.Columns["ID"].FillWeight = 2;
                form1.dataGridView1.Columns["CategoryName"].FillWeight = 10;
                form1.dataGridView1.Columns["Total"].FillWeight = 2;

                form1.dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                foreach (DataGridViewColumn col in form1.dataGridView1.Columns)
                    col.SortMode = DataGridViewColumnSortMode.NotSortable;

                double sum1 = 0;
                List<Category> categories = Statics.DataMapper.GetIncomeCategories();
                foreach (Category category in categories)
                {
                    double sum = Statics.DataMapper.IncomeCategorySum(reportDetais,category.ID);
                    form1.dataGridView1.Rows.Add();
                    int lastIndex = form1.dataGridView1.Rows.Count - 1;
                    form1.dataGridView1.Rows[lastIndex].Cells[0].Value = "IC-" + category.ID;
                    form1.dataGridView1.Rows[lastIndex].Cells[1].Value = category.Name;
                    form1.dataGridView1.Rows[lastIndex].Cells[2].Value = Math.Round(sum,3);
                    sum1 += sum;
                }

                form1.dataGridView1.Rows.Add();
                int lastIndex1 = form1.dataGridView1.Rows.Count - 1;
                form1.dataGridView1.Rows[lastIndex1].Cells[0].Value = "Sum";
                form1.dataGridView1.Rows[lastIndex1].Cells[2].Value = Math.Round(sum1,3);

                foreach (DataGridViewCell cell in form1.dataGridView1.Rows[lastIndex1].Cells)
                    cell.Style.BackColor = Color.Bisque;

                EndWait();
                form1.Show();
            }
        }

        private void ExpenseCatSummaryButton_Click(object sender, EventArgs e)
        {
            ReportDetailsForm form = new ReportDetailsForm();
            form.ShowDialog();
            if (form.IsOK)
            {
                StartWait();

                ReportDetail reportDetais = form.ReturnItem;
                ReportForm form1 = new ReportForm();
                form1.HeaderLabel.Text = " Expense Categories Summary";
                form1.Text = form1.HeaderLabel.Text;
                form1.dataGridView1.Columns.Add("ID", "Category ID");
                form1.dataGridView1.Columns.Add("CategoryName", "Category name");
                form1.dataGridView1.Columns.Add("Total", "Total");

                form1.dataGridView1.Columns["ID"].FillWeight = 2;
                form1.dataGridView1.Columns["CategoryName"].FillWeight = 10;
                form1.dataGridView1.Columns["Total"].FillWeight = 2;

                form1.dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                foreach (DataGridViewColumn col in form1.dataGridView1.Columns)
                    col.SortMode = DataGridViewColumnSortMode.NotSortable;

                double sum1 = 0;
                List<Category> categories = Statics.DataMapper.GetExpenseCategories();
                foreach (Category category in categories)
                {
                    double sum = Statics.DataMapper.ExpenseCategorySum(reportDetais, category.ID);
                    form1.dataGridView1.Rows.Add();
                    int lastIndex = form1.dataGridView1.Rows.Count - 1;
                    form1.dataGridView1.Rows[lastIndex].Cells[0].Value = "EC-" + category.ID;
                    form1.dataGridView1.Rows[lastIndex].Cells[1].Value = category.Name;
                    form1.dataGridView1.Rows[lastIndex].Cells[2].Value = Math.Round(sum,3);
                    sum1 += sum;
                }

                form1.dataGridView1.Rows.Add();
                int lastIndex1 = form1.dataGridView1.Rows.Count - 1;
                form1.dataGridView1.Rows[lastIndex1].Cells[0].Value = "Sum";
                form1.dataGridView1.Rows[lastIndex1].Cells[2].Value = Math.Round(sum1,3);

                foreach (DataGridViewCell cell in form1.dataGridView1.Rows[lastIndex1].Cells)
                    cell.Style.BackColor = Color.Bisque;

                EndWait();
                form1.Show();
            }
        }

        private void TotalReportButton_Click(object sender, EventArgs e)
        {
            ReportDetailsForm form=new ReportDetailsForm();
            form.ShowDialog();
            if (form.IsOK)
            {
                StartWait();

                ReportDetail reportDetais = form.ReturnItem;
                ReportForm form1 = new ReportForm();
                form1.HeaderLabel.Text = " Total report";
                form1.Text = form1.HeaderLabel.Text;
                form1.dataGridView1.Columns.Add("ID", "ID");
                form1.dataGridView1.Columns.Add("Year", "Year");
                form1.dataGridView1.Columns.Add("Month", "Month");
                form1.dataGridView1.Columns.Add("Day", "Day");
                form1.dataGridView1.Columns.Add("Description", "Description");
                form1.dataGridView1.Columns.Add("Category", "Category");
                form1.dataGridView1.Columns.Add("Debit", "Debit");
                form1.dataGridView1.Columns.Add("Credit", "Credit");
                form1.dataGridView1.Columns.Add("Remaining", "Remaining");

                form1.dataGridView1.Columns["ID"].FillWeight = 1;
                form1.dataGridView1.Columns["Year"].FillWeight = 1;
                form1.dataGridView1.Columns["Month"].FillWeight = 1;
                form1.dataGridView1.Columns["Day"].FillWeight = 1;
                form1.dataGridView1.Columns["Description"].FillWeight = 10;
                form1.dataGridView1.Columns["Category"].FillWeight = 4;
                form1.dataGridView1.Columns["Debit"].FillWeight = 2;
                form1.dataGridView1.Columns["Credit"].FillWeight = 2;
                form1.dataGridView1.Columns["Remaining"].FillWeight = 2;

                form1.dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                foreach (DataGridViewColumn col in form1.dataGridView1.Columns)
                    col.SortMode = DataGridViewColumnSortMode.NotSortable;


                double remaining = 0;
                double debitSum = 0;
                double creditSum = 0;

                List<Record> records = Statics.DataMapper.TotalReport(reportDetais);
                foreach (Record record in records)
                {
                    if (record.IsIncome)
                    {
                        Income income = record.Income;
                        Category category = Statics.DataMapper.GetIncomeCategoryByID(income.CategoryID);
                        remaining += income.Amount;
                        creditSum += income.Amount;
                        form1.dataGridView1.Rows.Add();
                        int lastIndex = form1.dataGridView1.Rows.Count - 1;
                        form1.dataGridView1.Rows[lastIndex].Cells[0].Value = "I-" + income.ID;
                        form1.dataGridView1.Rows[lastIndex].Cells[1].Value = income.Date.Year;
                        form1.dataGridView1.Rows[lastIndex].Cells[2].Value = income.Date.Month;
                        form1.dataGridView1.Rows[lastIndex].Cells[3].Value = income.Date.Day;
                        form1.dataGridView1.Rows[lastIndex].Cells[4].Value = income.Description;
                        form1.dataGridView1.Rows[lastIndex].Cells[5].Value = category.Name;
                        form1.dataGridView1.Rows[lastIndex].Cells[6].Value = 0;
                        form1.dataGridView1.Rows[lastIndex].Cells[7].Value = Math.Round(income.Amount,3);
                        form1.dataGridView1.Rows[lastIndex].Cells[8].Value = Math.Round(remaining,3);
                    }
                    else
                    {
                        Expense expense = record.Expense;
                        Category category = Statics.DataMapper.GetExpenseCategoryByID(expense.CategoryID);
                        remaining -= expense.Amount;
                        debitSum += expense.Amount;
                        form1.dataGridView1.Rows.Add();
                        int lastIndex = form1.dataGridView1.Rows.Count - 1;
                        form1.dataGridView1.Rows[lastIndex].Cells[0].Value = "E-" + expense.ID;
                        form1.dataGridView1.Rows[lastIndex].Cells[1].Value = expense.Date.Year;
                        form1.dataGridView1.Rows[lastIndex].Cells[2].Value = expense.Date.Month;
                        form1.dataGridView1.Rows[lastIndex].Cells[3].Value = expense.Date.Day;
                        form1.dataGridView1.Rows[lastIndex].Cells[4].Value = expense.Description;
                        form1.dataGridView1.Rows[lastIndex].Cells[5].Value = category.Name;
                        form1.dataGridView1.Rows[lastIndex].Cells[6].Value = Math.Round(expense.Amount,3);
                        form1.dataGridView1.Rows[lastIndex].Cells[7].Value = 0;
                        form1.dataGridView1.Rows[lastIndex].Cells[8].Value = Math.Round(remaining,3);
                    }
                }

                form1.dataGridView1.Rows.Add();
                int lastIndex1 = form1.dataGridView1.Rows.Count - 1;
                form1.dataGridView1.Rows[lastIndex1].Cells[0].Value = "Sum";
                form1.dataGridView1.Rows[lastIndex1].Cells[6].Value = Math.Round(debitSum,3);
                form1.dataGridView1.Rows[lastIndex1].Cells[7].Value = Math.Round(creditSum,3);
                form1.dataGridView1.Rows[lastIndex1].Cells[8].Value = Math.Round(remaining,3);

                
                foreach (DataGridViewCell cell in form1.dataGridView1.Rows[lastIndex1].Cells)
                    cell.Style.BackColor = Color.Bisque;

                EndWait();
                form1.Show();
            }
        }

        private void WebsiteButton_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("http://www.farshadoo.com");
        }

        private void HelpButton_Click(object sender, EventArgs e)
        {
            string helpPath = Application.StartupPath + "\\Help.pdf";
            System.Diagnostics.Process.Start(helpPath);
        }
        
        private void StartWait()
        {
            tabControl1.Visible = false;
            this.Refresh();
            System.Threading.Thread.Sleep(1000);
        }

        private void EndWait()
        {
            tabControl1.Visible = true;
        }

        private void BackupToolsButton_Click(object sender, EventArgs e)
        {
            BackupToolsForm form = new BackupToolsForm();
            form.ShowDialog();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("http://www.visualpharm.com");
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("http://www.pixel-mixer.com");

        }

        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("http://www.farshadoo.com");
        }

        private void linkLabel4_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            PreviousVersionsImportForm form = new PreviousVersionsImportForm();
            form.ShowDialog();
        }

    }
}
