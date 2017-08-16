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
    public partial class IncomeExpenseForm : Form
    {
        private ActionType actionType;
        private RecordType incomeOrExpense;
        private int ID;

        public IncomeExpenseForm(ActionType type,RecordType incomeOrExpense,int ID,Income incomeToShow,Expense expenseToShow)
        {
            InitializeComponent();
            
            this.actionType = type;
            this.incomeOrExpense = incomeOrExpense;
            this.ID = ID;

            switch (type)
            {
                case ActionType.Add:
                    this.Text = "New ";
                    YearTextBox.Text = Statics.LastUsedDate.Year.ToString();
                    MonthTextBox.Text = Statics.LastUsedDate.Month.ToString();
                    DayTextBox.Text = Statics.LastUsedDate.Day.ToString();
                    break;
                case ActionType.Modify:
                    this.Text="Modify ";
                    break;
                case ActionType.Remove:
                    this.Text="Remove ";
                    SaveOrDeleteButton.ImageIndex=1;
                    foreach (Control control in this.Controls)
                    {
                        if(!(control is Label))
                            control.Enabled = false;
                    }
                    SaveOrDeleteButton.Enabled=true;
                    SaveOrDeleteButton.Text = "Delete";
                    MyCancelButton.Enabled=true;
                    break;
            }

            switch(incomeOrExpense)
            {
                case RecordType.Income:
                    this.Text+= "Income";
                    label8.Text = "I-" + ID.ToString();
                    List<Category> incomeCategories = Statics.DataMapper.GetIncomeCategories();
                    foreach (Category cat in incomeCategories)
                    {
                        string s=cat.ID.ToString()+"- "+cat.Name;
                        comboBox1.Items.Add(s);
                    }
                    comboBox1.SelectedIndex = 0;
                    break;
                case RecordType.Expense:
                    this.Text+="Expense";
                    label8.Text = "E-" + ID.ToString();
                    List<Category> expenseCategories = Statics.DataMapper.GetExpenseCategories();
                    foreach (Category cat in expenseCategories)
                    {
                        string s = cat.ID.ToString() + "- " + cat.Name;
                        comboBox1.Items.Add(s);
                    }
                    comboBox1.SelectedIndex = 0;
                    break;
            }

            if ((actionType == ActionType.Modify || actionType == ActionType.Remove) && incomeOrExpense == RecordType.Income)
            {
                label8.Text = "I-" + incomeToShow.ID.ToString();
                DescriptionTextBox.Text = incomeToShow.Description;
                AmountTextBox.Text = incomeToShow.Amount.ToString();
                string s = incomeToShow.CategoryID.ToString()+"-";
                int len = s.Length;
                for (int i = 0; i < comboBox1.Items.Count; i++)
                {
                    if (comboBox1.Items[i].ToString().Substring(0, len) == s)
                        comboBox1.SelectedIndex = i;
                }

                switch (incomeToShow.PaymentType)
                {
                    case Statics.CashPayemnet:
                        radioButton1.Checked = true;
                        break;
                    case Statics.CheckPayment:
                        radioButton2.Checked = true;
                        break;
                    case Statics.CreditCardPayment:
                        radioButton3.Checked = true;
                        break;
                    case Statics.OtherPayment:
                        radioButton4.Checked = true;
                        break;
                }

                YearTextBox.Text = incomeToShow.Date.Year.ToString();
                MonthTextBox.Text = incomeToShow.Date.Month.ToString();
                DayTextBox.Text = incomeToShow.Date.Day.ToString();
            }

            if ((actionType == ActionType.Modify || actionType == ActionType.Remove) && incomeOrExpense == RecordType.Expense)
            {
                label8.Text = "E-" + expenseToShow.ID.ToString();
                DescriptionTextBox.Text = expenseToShow.Description;
                AmountTextBox.Text = expenseToShow.Amount.ToString();
                string s = expenseToShow.CategoryID.ToString() + "-";
                int len = s.Length;
                for (int i = 0; i < comboBox1.Items.Count; i++)
                {
                    if (comboBox1.Items[i].ToString().Substring(0, len) == s)
                        comboBox1.SelectedIndex = i;
                }

                switch (expenseToShow.PaymentType)
                {
                    case Statics.CashPayemnet:
                        radioButton1.Checked = true;
                        break;
                    case Statics.CheckPayment:
                        radioButton2.Checked = true;
                        break;
                    case Statics.CreditCardPayment:
                        radioButton3.Checked = true;
                        break;
                    case Statics.OtherPayment:
                        radioButton4.Checked = true;
                        break;
                }

                YearTextBox.Text = expenseToShow.Date.Year.ToString();
                MonthTextBox.Text = expenseToShow.Date.Month.ToString();
                DayTextBox.Text = expenseToShow.Date.Day.ToString();
            }
            
        }

        private void MyCancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void SaveOrDeleteButton_Click(object sender, EventArgs e)
        {
            if (DescriptionTextBox.Text.IndexOf("'") != -1)
            {
                MessageBox.Show("Description cannot have ' character");
                return;
            }

            double amount;
            try
            {
                amount = double.Parse(AmountTextBox.Text);
            }
            catch
            {
                MessageBox.Show("Please enter amount in correct format.");
                return;
            }

            int year;
            int month;
            int day;
            try
            {
                year = int.Parse(YearTextBox.Text);
                month = int.Parse(MonthTextBox.Text);
                day = int.Parse(DayTextBox.Text);
            }
            catch
            {
                MessageBox.Show("Please enter date in correct format.");
                return;
            }

            int paymentType = 0;
            if (radioButton1.Checked)
                paymentType = Statics.CashPayemnet;
            else if (radioButton2.Checked)
                paymentType = Statics.CheckPayment;
            else if (radioButton3.Checked)
                paymentType = Statics.CreditCardPayment;
            else if (radioButton4.Checked)
                paymentType = Statics.OtherPayment;
            else
            {
                MessageBox.Show("Error");
                return;
            }

            string s1;
            try
            {
                s1 = (string)comboBox1.SelectedItem;
            }
            catch
            {
                MessageBox.Show("Error");
                return;
            }

            int k=s1.IndexOf('-');
            string s=s1.Substring(0,k);
            int catID=0;

            try
            {
                catID = int.Parse(s);
            }
            catch
            {
                MessageBox.Show("Error");
                return;
            }


            if (actionType == ActionType.Add && incomeOrExpense == RecordType.Income)
            {
                Statics.LastUsedDate = new MyDate(year, month, day);               
                Income income = new Income(ID, DescriptionTextBox.Text, amount, catID, paymentType, new MyDate(year, month, day));
                Statics.DataMapper.AddIncome(income);
                this.Close();
            }

            if (actionType == ActionType.Modify && incomeOrExpense == RecordType.Income)
            {
                Income income = new Income(ID, DescriptionTextBox.Text, amount, catID, paymentType, new MyDate(year, month, day));
                Statics.DataMapper.UpdateIncome(income);
                this.Close();
            }

            if (actionType == ActionType.Remove && incomeOrExpense == RecordType.Income)
            {
                Statics.DataMapper.RemoveIncome(ID);
                this.Close();
            }

            if (actionType == ActionType.Add && incomeOrExpense == RecordType.Expense)
            {
                Statics.LastUsedDate = new MyDate(year, month, day);
                Expense expense = new Expense(ID, DescriptionTextBox.Text, amount, catID, paymentType, new MyDate(year, month, day));
                Statics.DataMapper.AddExpense(expense);
                this.Close();
            }

            if (actionType == ActionType.Modify && incomeOrExpense == RecordType.Expense)
            {
                Expense expense = new Expense(ID, DescriptionTextBox.Text, amount, catID, paymentType, new MyDate(year, month, day));
                Statics.DataMapper.UpdateExpense(expense);
                this.Close();
            }

            if (actionType == ActionType.Remove && incomeOrExpense == RecordType.Expense)
            {
                Statics.DataMapper.RemoveExpense(ID);
                this.Close();
            }
        }

        private void AddCategoryButton_Click(object sender, EventArgs e)
        {
            if (incomeOrExpense == RecordType.Income)
            {
                int myCatID = Statics.DataMapper.GenerateIncomeCategoryID();
                CategoryForm form = new CategoryForm(myCatID, ActionType.Add, RecordType.Income, null);
                form.ShowDialog();
                if (form.IsOK)
                {
                    comboBox1.Items.Clear();
                    List<Category> incomeCategories = Statics.DataMapper.GetIncomeCategories();
                    int index = 0;
                    for (int i = 0; i < incomeCategories.Count; i++)
                    {
                        Category cat = incomeCategories[i];
                        if (cat.ID == myCatID)
                            index = i;
                        string s = cat.ID.ToString() + "- " + cat.Name;
                        comboBox1.Items.Add(s);
                    }
                    comboBox1.SelectedIndex = index;
                }
            }
            else
            {
                int myCatID = Statics.DataMapper.GenerateExpenseCategoryID();
                CategoryForm form = new CategoryForm(myCatID, ActionType.Add, RecordType.Expense, null);
                form.ShowDialog();
                if (form.IsOK)
                {
                    comboBox1.Items.Clear();
                    List<Category> expenseCategories = Statics.DataMapper.GetExpenseCategories();
                    int index = 0;
                    for (int i = 0; i < expenseCategories.Count; i++)
                    {
                        Category cat = expenseCategories[i];
                        if (cat.ID == myCatID)
                            index = i;
                        string s = cat.ID.ToString() + "- " + cat.Name;
                        comboBox1.Items.Add(s);
                    }
                    comboBox1.SelectedIndex = index;
                }
            }
        }
    }
}
