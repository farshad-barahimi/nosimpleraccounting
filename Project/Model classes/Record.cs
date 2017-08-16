//Copyright © 2010-2012 , Farshad Barahimi . All rights reserved
//This software is licensed under the Apache License, Version 2.0

using System;
using System.Collections.Generic;
using System.Text;
using Project.ModelClasses;

namespace Project.ModelClasses
{
    public class Record
    {
        private bool isIncome;
        public bool IsIncome
        {
            get { return isIncome; }
            set { isIncome = value; }
        }
        
        private Income income;
        public Income Income
        {
            get { return income; }
            set { income = value; }
        }
        
        private Expense expense;
        public Expense Expense
        {
            get { return expense; }
            set { expense = value; }
        }
    }
}
