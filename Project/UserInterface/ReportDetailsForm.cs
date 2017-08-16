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
    public partial class ReportDetailsForm : Form
    {
        public bool IsOK = false;
        public ReportDetail ReturnItem;
        public ReportDetailsForm()
        {
            InitializeComponent();
            AllButton_Click(this,new EventArgs());
        }

        private void ViewReportButton_Click(object sender, EventArgs e)
        {
            int yearFrom;
            int monthFrom;
            int dayFrom;
            try
            {
                yearFrom = int.Parse(YearTextBoxFrom.Text);
                monthFrom = int.Parse(MonthTextBoxFrom.Text);
                dayFrom = int.Parse(DayTextBoxFrom.Text);
            }
            catch
            {
                MessageBox.Show("Please enter from date in correct format.");
                return;
            }

            int yearTo;
            int monthTo;
            int dayTo;
            try
            {
                yearTo = int.Parse(YearTextBoxTo.Text);
                monthTo = int.Parse(MonthTextBoxTo.Text);
                dayTo = int.Parse(DayTextBoxTo.Text);
            }
            catch
            {
                MessageBox.Show("Please enter to date in correct format.");
                return;
            }

            if (!checkBox1.Checked && !checkBox2.Checked && !checkBox3.Checked && !!checkBox4.Checked)
            {
                MessageBox.Show("At least one of payment types should be selected");
                return;
            }

            MyDate fromDate = new MyDate(yearFrom, monthFrom, dayFrom);
            MyDate toDate = new MyDate(yearTo, monthTo, dayTo);
            
            IsOK = true;
            ReturnItem = new ReportDetail(fromDate, toDate, checkBox1.Checked, checkBox2.Checked, checkBox3.Checked, checkBox4.Checked);
            this.Close();
        }

        private void MyCancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void TodayButton_Click(object sender, EventArgs e)
        {
            YearTextBoxFrom.Text = Statics.Today.Year.ToString();
            MonthTextBoxFrom.Text = Statics.Today.Month.ToString();
            DayTextBoxFrom.Text = Statics.Today.Day.ToString();

            YearTextBoxTo.Text = Statics.Today.Year.ToString();
            MonthTextBoxTo.Text = Statics.Today.Month.ToString();
            DayTextBoxTo.Text = Statics.Today.Day.ToString();
        }

        private void LastYearButton_Click(object sender, EventArgs e)
        {
            int fromYear = Statics.Today.Year;
            if (fromYear > 0)
                fromYear--;
            YearTextBoxFrom.Text = fromYear.ToString();
            MonthTextBoxFrom.Text = Statics.Today.Month.ToString();
            DayTextBoxFrom.Text = Statics.Today.Day.ToString();

            YearTextBoxTo.Text = Statics.Today.Year.ToString();
            MonthTextBoxTo.Text = Statics.Today.Month.ToString();
            DayTextBoxTo.Text = Statics.Today.Day.ToString();
        }

        private void AllButton_Click(object sender, EventArgs e)
        {
            YearTextBoxFrom.Text = "0";
            MonthTextBoxFrom.Text = "0";
            DayTextBoxFrom.Text = "0";

            YearTextBoxTo.Text = "9999";
            MonthTextBoxTo.Text = "99";
            DayTextBoxTo.Text = "99";
        }
    }
}
