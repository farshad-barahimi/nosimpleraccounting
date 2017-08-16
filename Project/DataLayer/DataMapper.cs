//Copyright © 2010-2012 , Farshad Barahimi . All rights reserved
//This software is licensed under the Apache License, Version 2.0

using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.OleDb;
using Project.ModelClasses;
using System.Windows.Forms;
using Project.UserInterface;

namespace Project.DataLayer
{
    /// <summary>
    /// Main class for to communicate with database
    /// </summary>
    public class DataMapper
    {
        private OleDbConnection connection;
        public bool IsError = false;
        
        public DataMapper(string connectionString)
        {
            try
            {
                connection = new OleDbConnection(connectionString);
                connection.Open();
            }
            catch(Exception e)
            {
                error(e.Message);
            }
        }

        public void OpenConnection()
        {
            connection.Open();
        }
        public void CloseConnection()
        {
            connection.Close();
        }

        /// <summary>
        /// Dates are stored in database as strings. This function converts a date into its equivalent string
        /// </summary>
        private string MyDateToString(int year, int month, int day)
        {
            int i;
            string res="";
            string s;
            s = year.ToString();
            if(s.Length>4)
                return "error";
            for (i = 0; i < 4-s.Length; i++)
                res += "0";
            res += s;

            s = month.ToString();
            if (s.Length > 2)
                return "error";
            for (i = 0; i < 2 - s.Length; i++)
                res += "0";
            res += s;

            s = day.ToString();
            if (s.Length > 2)
                return "error";
            for (i = 0; i < 2 - s.Length; i++)
                res += "0";
            res += s;

            return res;
        }

        
        /// <summary>
        /// Dates are stored in database as strings. This function converts a string into its equivalent date
        /// </summary>
        private MyDate getMyDateFromString(string dateString)
        {
            string yearS = dateString.Substring(0, 4);
            string monthS = dateString.Substring(4, 2);
            string dayS = dateString.Substring(6, 2);

            while (yearS[0] == '0' && yearS.Length>1)
                yearS = yearS.Substring(1);
            int year = int.Parse(yearS);

            while (monthS[0] == '0' && monthS.Length > 1)
                monthS = monthS.Substring(1);
            int month = int.Parse(monthS);

            while (dayS[0] == '0' && monthS.Length > 1)
                dayS = dayS.Substring(1);
            int day = int.Parse(dayS);

            return new MyDate(year,month,day);
        }

        /// <summary>
        /// This function is called when an error occurs in communicating with database.
        /// </summary>
        private void error(string message)
        {
            IsError = true;
            MessageBox.Show("Error, Application will exit");
            Application.Exit();
        }
        
        /// <summary>
        /// This function adds an expense record to datbase.
        /// </summary>
        public void AddExpense(Expense expense)
        {
            try
            {
                OleDbCommand command = new OleDbCommand("", connection);
                string date = MyDateToString(expense.Date.Year, expense.Date.Month, expense.Date.Day);
                command.CommandText = string.Format("INSERT INTO Expenses Values('{0}','{1}','{2}','{3}','{4}','{5}')", expense.ID, expense.CategoryID, expense.Amount, expense.Description, expense.PaymentType, date);
                command.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                error(e.Message);
            }
        }

        /// <summary>
        /// This function updates an expense record in database.
        /// </summary>
        public void UpdateExpense(Expense expense)
        {
            try
            {
                OleDbCommand command = new OleDbCommand("", connection);
                string date = MyDateToString(expense.Date.Year, expense.Date.Month, expense.Date.Day);
                command.CommandText = string.Format("UPDATE Expenses SET Description='{0}', Amount={1},CategoryID={2}, PaymentType={3}, MyDate='{4}' WHERE ID={5}", expense.Description, expense.Amount, expense.CategoryID, expense.PaymentType, date, expense.ID);
                command.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                error(e.Message);
            }
        }

        /// <summary>
        /// This function deletes an expense record from database.
        /// </summary>
        /// <param name="expenseID">The ID of expense record to be deleted.</param>
        public void RemoveExpense(int expenseID)
        {
            try
            {
                OleDbCommand command = new OleDbCommand("", connection);
                command.CommandText = "DELETE FROM Expenses WHERE ID=" + expenseID.ToString();
                command.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                error(e.Message);
            }
        }

        /// <summary>
        /// This function adds an income record to database.
        /// </summary>
        public void AddIncome(Income income)
        {
            try
            {
                OleDbCommand command = new OleDbCommand("", connection);
                string date = MyDateToString(income.Date.Year, income.Date.Month, income.Date.Day);
                command.CommandText = string.Format("INSERT INTO Incomes Values('{0}','{1}','{2}','{3}','{4}','{5}')", income.ID, income.CategoryID, income.Amount, income.Description, income.PaymentType, date);
                command.ExecuteNonQuery();
            }
            catch(Exception e)
            {
                error(e.Message);
            }
        }

        /// <summary>
        /// This function updates an income record in database.
        /// </summary>
        public void UpdateIncome(Income income)
        {
            try
            {
                OleDbCommand command = new OleDbCommand("", connection);
                string date = MyDateToString(income.Date.Year, income.Date.Month, income.Date.Day);
                command.CommandText = string.Format("UPDATE Incomes SET Description='{0}', Amount={1},CategoryID={2}, PaymentType={3}, MyDate='{4}' WHERE ID={5}", income.Description, income.Amount, income.CategoryID, income.PaymentType, date, income.ID);
                command.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                error(e.Message);
            }
        }

        /// <summary>
        /// This funtion deletes an income record from database.
        /// </summary>
        /// <param name="incomeID">The ID of income record to be deleted.</param>
        public void RemoveIncome(int incomeID)
        {
            try
            {
                OleDbCommand command = new OleDbCommand("", connection);
                command.CommandText = "DELETE FROM Incomes WHERE ID=" + incomeID.ToString();
                command.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                error(e.Message);
            }
        }

        /// <summary>
        /// This function adds an income category to database.
        /// </summary>
        public void AddIncomeCategory(Category category)
        {
            try
            {
                OleDbCommand command = new OleDbCommand("", connection);
                command.CommandText = string.Format("INSERT INTO IncomeCategories Values('{0}','{1}')", category.ID, category.Name);
                command.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                error(e.Message);
            }
        }

        /// <summary>
        /// This function updates an income category in database.
        /// </summary>
        public void UpdateIncomeCategory(Category category)
        {
            try
            {
                OleDbCommand command = new OleDbCommand("", connection);
                command.CommandText = string.Format("UPDATE IncomeCategories SET MyName='{0}'WHERE ID={1}", category.Name, category.ID);
                command.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                error(e.Message);
            }
        }

        /// <summary>
        /// This function deletes an income category from database.
        /// </summary>
        /// <param name="ID"></param>
        public void RemoveIncomeCategory(int ID)
        {
            try
            {
                OleDbCommand command = new OleDbCommand("", connection);
                command.CommandText = "DELETE FROM IncomeCategories WHERE ID=" + ID.ToString();
                command.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                error(e.Message);
            }
        }
        
        /// <summary>
        /// This function adds an expense category to database
        /// </summary>
        public void AddExpenseCategory(Category category)
        {
            try
            {
                OleDbCommand command = new OleDbCommand("", connection);
                command.CommandText = string.Format("INSERT INTO ExpenseCategories Values('{0}','{1}')", category.ID, category.Name);
                command.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                error(e.Message);
            }
        }

        /// <summary>
        /// This function updates an expesnse category in database
        /// </summary>
        public void UpdateExpenseCategory(Category category)
        {
            try
            {
                OleDbCommand command = new OleDbCommand("", connection);
                command.CommandText = string.Format("UPDATE ExpenseCategories SET MyName='{0}'WHERE ID={1}", category.Name, category.ID);
                command.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                error(e.Message);
            }
        }

        /// <summary>
        /// This function deletes an expense category from database.
        /// </summary>
        public void RemoveExpenseCategory(int ID)
        {
            try
            {
                OleDbCommand command = new OleDbCommand("", connection);
                command.CommandText = "DELETE FROM ExpenseCategories WHERE ID=" + ID.ToString();
                command.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                error(e.Message);
            }
        }

        /// <summary>
        /// This function returns the income record whose ID is equal to parameter.
        /// </summary>
        /// <param name="ID">The ID of income record to return.</param>
        /// <returns>The income record whose ID is equal to parameter. null if not found.</returns>
        public Income GetIncomeByID(int ID)
        {
            Income res = null;
            try
            {
                OleDbCommand command = new OleDbCommand("", connection);
                command.CommandText = "SELECT * from Incomes WHERE ID=" + ID.ToString();
                OleDbDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    string date = reader.GetString(5);
                    MyDate myDate = getMyDateFromString(date);
                    res = new Income(reader.GetInt32(0), reader.GetString(3), reader.GetDouble(2), reader.GetInt32(1), reader.GetInt32(4), myDate);
                }
                reader.Close();
            }
            catch (Exception e)
            {
                error(e.Message);
            }
            return res;
        }

        /// <summary>
        /// This function returns the expense record whose ID is equal to parameter.
        /// </summary>
        /// <param name="ID">The ID of expense record to return.</param>
        /// <returns>The expense record whose ID is equal to parameter. null if not found.</returns>
        public Expense GetExpenseByID(int ID)
        {
            Expense res = null;
            try
            {
                OleDbCommand command = new OleDbCommand("", connection);
                command.CommandText = "SELECT * from Expenses WHERE ID=" + ID.ToString();
                OleDbDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    string date = reader.GetString(5);
                    MyDate myDate = getMyDateFromString(date);
                    res = new Expense(reader.GetInt32(0), reader.GetString(3), reader.GetDouble(2), reader.GetInt32(1), reader.GetInt32(4), myDate);
                }
                reader.Close();
            }
            catch (Exception e)
            {
                error(e.Message);
            }
            return res;
        }

        /// <summary>
        /// This function returns the income category whose ID is equal to parameter.
        /// </summary>
        /// <param name="ID">The ID of income category to return.</param>
        /// <returns>The income category whose ID is equal to parameter. null if not found.</returns>
        public Category GetIncomeCategoryByID(int ID)
        {
            Category res = null;
            try
            {
                OleDbCommand command = new OleDbCommand("", connection);
                command.CommandText = "SELECT * from IncomeCategories WHERE ID=" + ID.ToString();
                OleDbDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    res = new Category(reader.GetInt32(0), reader.GetString(1));
                }
                reader.Close();
            }
            catch (Exception e)
            {
                error(e.Message);
            }
            return res;
        }

        /// <summary>
        /// This function returns the expense category whose ID is equal to parameter.
        /// </summary>
        /// <param name="ID">The ID of expense category to return.</param>
        /// <returns>The expense category whose ID is equal to parameter. null if not found.</returns>
        public Category GetExpenseCategoryByID(int ID)
        {
            Category res = null;
            try
            {
                OleDbCommand command = new OleDbCommand("", connection);
                command.CommandText = "SELECT * from ExpenseCategories WHERE ID=" + ID.ToString();
                OleDbDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    res = new Category(reader.GetInt32(0), reader.GetString(1));
                }
                reader.Close();
            }
            catch (Exception e)
            {
                error(e.Message);
            }
            return res;
        }

        /// <summary>
        /// This function generates new expense ID by adding 1 to maximum expense ID in database.
        /// </summary>
        /// <returns>The new ID.</returns>
        public int GenerateExpenseID()
        {
            OleDbCommand command = new OleDbCommand("", connection);
            command.CommandText = "SELECT MAX(ID) FROM Expenses";
            OleDbDataReader reader = command.ExecuteReader();
            if (!reader.HasRows)
            {
                reader.Close();
                return 1;
            }
            reader.Read();
            if (reader.IsDBNull(0))
            {
                reader.Close();
                return 1;
            }
            int result = reader.GetInt32(0);
            reader.Close();
            if (result == int.MaxValue)
                error("Maximum of integer reached");
            return result + 1;
        }

        /// <summary>
        /// This function generates new income ID by adding 1 to maximum income ID in database.
        /// </summary>
        /// <returns>The new ID.</returns>
        public int GenerateIncomeID()
        {
            OleDbCommand command = new OleDbCommand("", connection);
            command.CommandText = "SELECT MAX(ID) FROM Incomes";
            OleDbDataReader reader = command.ExecuteReader();
            if (!reader.HasRows)
            {
                reader.Close();
                return 1;
            }
            reader.Read();
            if (reader.IsDBNull(0))
            {
                reader.Close();                
                return 1;
            }
            int result = reader.GetInt32(0);
            reader.Close();
            if (result == int.MaxValue)
                error("Maximum of integer reached");
            return result+1;
        }

        /// <summary>
        /// This function generates new income category ID by adding 1 to maximum income category ID in database.
        /// </summary>
        /// <returns>The new ID.</returns>
        public int GenerateIncomeCategoryID()
        {
            OleDbCommand command = new OleDbCommand("", connection);
            command.CommandText = "SELECT MAX(ID) FROM IncomeCategories";
            OleDbDataReader reader = command.ExecuteReader();
            if (!reader.HasRows)
            {
                reader.Close();
                return 1;
            }
            reader.Read();
            if (reader.IsDBNull(0))
            {
                reader.Close();
                return 1;
            }
            int result = reader.GetInt32(0);
            reader.Close();
            if (result == int.MaxValue)
                error("Maximum of integer reached");
            return result + 1;
        }

        /// <summary>
        /// This function generates new expense category ID by adding 1 to maximum expense category ID in database.
        /// </summary>
        /// <returns>The new ID.</returns>
        public int GenerateExpenseCategoryID()
        {
            OleDbCommand command = new OleDbCommand("", connection);
            command.CommandText = "SELECT MAX(ID) FROM ExpenseCategories";
            OleDbDataReader reader = command.ExecuteReader();
            if (!reader.HasRows)
            {
                reader.Close();
                return 1;
            }
            reader.Read();
            if (reader.IsDBNull(0))
            {
                reader.Close();
                return 1;
            }
            int result = reader.GetInt32(0);
            reader.Close();
            if (result == int.MaxValue)
                error("Maximum of integer reached");
            return result + 1;
        }
        
        /// <summary>
        /// This function retrieves a list of all income categories.
        /// </summary>
        public List<Category> GetIncomeCategories()
        {
            List<Category> res = new List<Category>();
            OleDbCommand command = new OleDbCommand("", connection);
            command.CommandText = "SELECT * from IncomeCategories";
            OleDbDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                Category category = new Category(reader.GetInt32(0), reader.GetString(1));
                res.Add(category);
            }
            reader.Close();
            return res;
        }

        /// <summary>
        /// This function retrieves a list of all expense categories.
        /// </summary>
        public List<Category> GetExpenseCategories()
        {
            List<Category> res = new List<Category>();
            OleDbCommand command = new OleDbCommand("", connection);
            command.CommandText = "SELECT * from ExpenseCategories";
            OleDbDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                Category category = new Category(reader.GetInt32(0), reader.GetString(1));
                res.Add(category);
            }
            reader.Close();
            return res;
        }

        /// <summary>
        /// This function is used by other report functions. 
        /// It produces a part sql query which limits the results in a way specified by reportDetails parameter.
        /// </summary>
        private string generateWhereSQL(ReportDetail reportDetail)
        {
            string s="";
            int cnt=0;
            if(reportDetail.IsCash)
            {
                string s1= "PaymentType=" + Statics.CashPayemnet;
                if (cnt != 0)
                    s1 = " OR " + s1;
                s += s1;
                cnt++;
            }

            if (reportDetail.IsCheck)
            {
                string s1 = "PaymentType=" + Statics.CheckPayment;
                if (cnt != 0)
                    s1 = " OR " + s1;
                s += s1;
                cnt++;
            }

            if (reportDetail.IsCreditCard)
            {
                string s1 = "PaymentType=" + Statics.CreditCardPayment;
                if (cnt != 0)
                    s1 = " OR " + s1;
                s += s1;
                cnt++;
            }

            if (reportDetail.IsOther)
            {
                string s1 = "PaymentType=" + Statics.OtherPayment;
                if (cnt != 0)
                    s1 = " OR " + s1;
                s += s1;
                cnt++;
            }

            if (cnt != 1)
                s="("+s+")";

            string dateFromString = MyDateToString(reportDetail.FromDate.Year, reportDetail.FromDate.Month, reportDetail.FromDate.Day);
            string dateToString = MyDateToString(reportDetail.ToDate.Year, reportDetail.ToDate.Month, reportDetail.ToDate.Day);

            string res = string.Format("WHERE MyDate>='{0}' AND MyDate<='{1}' AND {2}", dateFromString, dateToString, s);
            return res;
        }

        /// <summary>
        /// Generates the total report
        /// </summary>
        public List<Record> TotalReport(ReportDetail reportDetail)
        {
            List<Record> res = new List<Record>();
            try
            {
                OleDbCommand command = new OleDbCommand("", connection);
                command.CommandText = "SELECT 1,* from Incomes " + generateWhereSQL(reportDetail) + 
                    " UNION SELECT 0,* from Expenses " + generateWhereSQL(reportDetail) + " ORDER BY MyDate";
                OleDbDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    int temp = reader.GetInt32(0);
                    Record record = new Record();
                    record.IsIncome=false;
                    if (temp == 1)
                        record.IsIncome = true;
                    string date = reader.GetString(6);
                    MyDate myDate = getMyDateFromString(date);
                    if(record.IsIncome)
                        record.Income = new Income(reader.GetInt32(1), reader.GetString(4), reader.GetDouble(3), reader.GetInt32(2), reader.GetInt32(5), myDate);
                    else
                        record.Expense = new Expense(reader.GetInt32(1), reader.GetString(4), reader.GetDouble(3), reader.GetInt32(2), reader.GetInt32(5), myDate);
                    res.Add(record);
                }
                reader.Close();
            }
            catch (Exception e)
            {
                error(e.Message);
            }
            return res;
        }

        /// <summary>
        /// Generates the income report
        /// </summary>
        public List<Income> IncomeReport(ReportDetail reportDetail)
        {
            List<Income> res = new List<Income>();
            try
            {
                OleDbCommand command = new OleDbCommand("", connection);
                command.CommandText = "SELECT * from Incomes " + generateWhereSQL(reportDetail)+" ORDER BY MyDate";
                OleDbDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    string date = reader.GetString(5);
                    MyDate myDate = getMyDateFromString(date);
                    Income income = new Income(reader.GetInt32(0), reader.GetString(3), reader.GetDouble(2), reader.GetInt32(1), reader.GetInt32(4), myDate);
                    res.Add(income);
                }
                reader.Close();
            }
            catch (Exception e)
            {
                error(e.Message);
            }
            return res;
        }

        /// <summary>
        /// Generates the expense report
        /// </summary>
        public List<Expense> ExpenseReport(ReportDetail reportDetail)
        {
            List<Expense> res = new List<Expense>();
            try
            {
                OleDbCommand command = new OleDbCommand("", connection);
                command.CommandText = "SELECT * from Expenses " + generateWhereSQL(reportDetail) + " ORDER BY MyDate";
                OleDbDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    string date = reader.GetString(5);
                    MyDate myDate = getMyDateFromString(date);
                    Expense expense = new Expense(reader.GetInt32(0), reader.GetString(3), reader.GetDouble(2), reader.GetInt32(1), reader.GetInt32(4), myDate);
                    res.Add(expense);
                }
                reader.Close();
            }
            catch (Exception e)
            {
                error(e.Message);
            }
            return res;
        }

        /// <summary>
        /// Generates the income category report
        /// </summary>
        public List<Income> IncomeCategoryReport(ReportDetail reportDetail,Category category)
        {
            List<Income> res = new List<Income>();
            try
            {
                OleDbCommand command = new OleDbCommand("", connection);
                command.CommandText = "SELECT * from Incomes " + generateWhereSQL(reportDetail) + " AND CategoryID=" + category.ID + " ORDER BY MyDate";
                OleDbDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    string date = reader.GetString(5);
                    MyDate myDate = getMyDateFromString(date);
                    Income income = new Income(reader.GetInt32(0), reader.GetString(3), reader.GetDouble(2), reader.GetInt32(1), reader.GetInt32(4), myDate);
                    res.Add(income);
                }
                reader.Close();
            }
            catch (Exception e)
            {
                error(e.Message);
            }
            return res;
        }

        /// <summary>
        /// Generates the expense category report
        /// </summary>
        public List<Expense> ExpenseCategoryReport(ReportDetail reportDetail,Category category)
        {
            List<Expense> res = new List<Expense>();
            try
            {
                OleDbCommand command = new OleDbCommand("", connection);
                command.CommandText = "SELECT * from Expenses " + generateWhereSQL(reportDetail) + " AND CategoryID=" + category.ID + " ORDER BY MyDate";
                OleDbDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    string date = reader.GetString(5);
                    MyDate myDate = getMyDateFromString(date);
                    Expense expense = new Expense(reader.GetInt32(0), reader.GetString(3), reader.GetDouble(2), reader.GetInt32(1), reader.GetInt32(4), myDate);
                    res.Add(expense);
                }
                reader.Close();
            }
            catch (Exception e)
            {
                error(e.Message);
            }
            return res;
        }

        /// <summary>
        /// This function calculates total sum of income records in a special income category limited by reportDetails parameter.
        /// </summary>
        public double IncomeCategorySum(ReportDetail reportDetail,int categoryID)
        {
            double res = 0;
            try
            {
                OleDbCommand command = new OleDbCommand("", connection);
                command.CommandText = "SELECT sum(Amount) from Incomes " + generateWhereSQL(reportDetail) + " AND CategoryID="+categoryID;
                OleDbDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    double price=0;
                    if (!reader.IsDBNull(0))
                        price = reader.GetDouble(0);
                    res = price;
                }
                reader.Close();
            }
            catch (Exception e)
            {
                error(e.Message);
            }
            return res;
        }

        /// <summary>
        /// This function calculates total sum of expense records in a special expense category limited by reportDetails parameter.
        /// </summary>
        public double ExpenseCategorySum(ReportDetail reportDetail, int categoryID)
        {
            double res = 0;
            try
            {
                OleDbCommand command = new OleDbCommand("", connection);
                command.CommandText = "SELECT sum(Amount) from Expenses " + generateWhereSQL(reportDetail) + " AND CategoryID=" + categoryID;
                OleDbDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    double price = 0;
                    if (!reader.IsDBNull(0))
                        price = reader.GetDouble(0);
                    res = price;
                }
                reader.Close();
            }
            catch (Exception e)
            {
                error(e.Message);
            }
            return res;
        }

        /// <summary>
        /// This function checks if there exists an income record in specified income category.
        /// </summary>
        public bool IsIncomeCategoryEmpty(int categoryID)
        {
            bool res = false;
            OleDbCommand command = new OleDbCommand("", connection);
            command.CommandText = "SELECT count(*) from Incomes WHERE CategoryID="+categoryID;
            OleDbDataReader reader = command.ExecuteReader();
            if(reader.Read())
            {
                if (reader.GetInt32(0) == 0)
                    res = true;
            }
            reader.Close();
            return res;
        }

        /// <summary>
        /// This function checks if there exists an expense record in specified expense category.
        /// </summary>
        public bool IsExpenseCategoryEmpty(int categoryID)
        {
            bool res = false;
            OleDbCommand command = new OleDbCommand("", connection);
            command.CommandText = "SELECT count(*) from Expenses WHERE CategoryID=" + categoryID;
            OleDbDataReader reader = command.ExecuteReader();
            if (reader.Read())
            {
                if (reader.GetInt32(0) == 0)
                    res = true;
            }
            reader.Close();
            return res;
        }

        /// <summary>
        /// Checks Database version of a backup file
        /// Databse version for NSA 1.0 to 3.0 is 1;
        /// Database version for NSA 4.0 and 5.0 is 2;
        /// </summary>
        /// <returns>-1 if not NoSimplerAccounting database, otherwise DBVersion</returns>
        public int GetFileDBVersion(string fileName)
        {
            string connectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + fileName + ";Jet OLEDB:Database Password=1;";
            OleDbConnection connection1=null;
            try
            {
                connection1 = new OleDbConnection(connectionString);
                connection1.Open();
                OleDbCommand command = new OleDbCommand("", connection1);
                command.CommandText = "SELECT * FROM Options";
                OleDbDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    if (reader.GetString(0) != "NoSimplerAccounting")
                    {
                        reader.Close();
                        connection1.Close();
                        return -1;
                    }
                    else
                    {
                        int result=reader.GetInt32(1);
                        reader.Close();
                        connection1.Close();
                        return result;
                    }
                }
                else
                    return -1;
            }
            catch
            {
                return -1;
            }
            finally
            {
                if (connection1!=null && connection1.State == ConnectionState.Open)
                    connection1.Close();
            }
        }

        /// <summary>
        /// Imports data from a database version 1 (NSA 1.0-3.0) backup file and changes all expense categories to General category.
        /// </summary>
        public bool ImportFromDBVersion1(string fileName)
        {
            string connectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + fileName + ";Jet OLEDB:Database Password=1;";
            OleDbConnection newConnection = null;
                
            newConnection = new OleDbConnection(connectionString);
            newConnection.Open();
            OleDbTransaction transaction = connection.BeginTransaction();

            try
            {


                OleDbCommand command = new OleDbCommand("", connection, transaction);
                command.CommandText = "DELETE FROM Expenses";
                command.ExecuteNonQuery();

                command = new OleDbCommand("", connection, transaction);
                command.CommandText = "DELETE FROM ExpenseCategories";
                command.ExecuteNonQuery();

                command = new OleDbCommand("", connection, transaction);
                command.CommandText = "DELETE FROM Incomes";
                command.ExecuteNonQuery();

                command = new OleDbCommand("", connection, transaction);
                command.CommandText = "DELETE FROM IncomeCategories";
                command.ExecuteNonQuery();

                OleDbCommand newCommand = new OleDbCommand("", newConnection);
                newCommand.CommandText = "SELECT * FROM ExpenseCategories";
                OleDbDataReader reader = newCommand.ExecuteReader();
                while (reader.Read())
                {
                    int ID = reader.GetInt32(0);
                    string name = reader.GetString(1);

                    command = new OleDbCommand("", connection, transaction);
                    command.CommandText = string.Format("INSERT INTO ExpenseCategories Values('{0}','{1}')", ID, name);
                    command.ExecuteNonQuery();
                }

                newCommand = new OleDbCommand("", newConnection);
                newCommand.CommandText = "SELECT * FROM IncomeCategories";
                reader = newCommand.ExecuteReader();
                while (reader.Read())
                {
                    int ID = reader.GetInt32(0);
                    string name = reader.GetString(1);

                    command = new OleDbCommand("", connection, transaction);
                    command.CommandText = string.Format("INSERT INTO IncomeCategories Values('{0}','{1}')", ID, name);
                    command.ExecuteNonQuery();
                }

                newCommand = new OleDbCommand("", newConnection);
                newCommand.CommandText = "SELECT * FROM Expenses";
                reader = newCommand.ExecuteReader();
                while (reader.Read())
                {
                    int ID = reader.GetInt32(0);
                    int CatID = reader.GetInt32(1);
                    double amount = reader.GetDouble(2);
                    string description = reader.GetString(3);
                    int paymentType = reader.GetInt32(4);
                    string mydate = reader.GetString(5);

                    command = new OleDbCommand("", connection, transaction);
                    command.CommandText = string.Format("INSERT INTO Expenses Values('{0}','{1}','{2}','{3}','{4}','{5}')", ID, 1, amount, description, paymentType, mydate);
                    command.ExecuteNonQuery();
                }

                newCommand = new OleDbCommand("", newConnection);
                newCommand.CommandText = "SELECT * FROM Incomes";
                reader = newCommand.ExecuteReader();
                while (reader.Read())
                {
                    int ID = reader.GetInt32(0);
                    int CatID = reader.GetInt32(1);
                    double amount = reader.GetDouble(2);
                    string description = reader.GetString(3);
                    int paymentType = reader.GetInt32(4);
                    string mydate = reader.GetString(5);

                    command = new OleDbCommand("", connection, transaction);
                    command.CommandText = string.Format("INSERT INTO Incomes Values('{0}','{1}','{2}','{3}','{4}','{5}')", ID, CatID, amount, description, paymentType, mydate);
                    command.ExecuteNonQuery();
                }

                transaction.Commit();
            }
            catch (OleDbException e)
            {
                transaction.Rollback();
                return false;
            }
            
            newConnection.Close();
            return true;
        }
    }
}
