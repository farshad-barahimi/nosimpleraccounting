//Copyright © 2010-2012 , Farshad Barahimi . All rights reserved
//This software is licensed under the Apache License, Version 2.0

using System;
using System.Collections.Generic;
using System.Text;

namespace Project.ModelClasses
{
    public class Income
    {
        public Income(int ID, string description, double amount, int categoryID, int paymentType, MyDate date)
        {
            this.id = ID;
            this.description = description;
            this.amount = amount;
            this.categoryID = categoryID;
            this.paymentType = paymentType;
            this.date = date;
        }

        private int id;
        public int ID
        {
            get { return id; }
            set { id = value; }
        }

        private string description;
        public string Description
        {
            get { return description; }
            set { description = value; }
        }

        private double amount;
        public double Amount
        {
            get { return amount; }
            set { amount = value; }
        }

        private int categoryID;
        public int CategoryID
        {
            get { return categoryID; }
            set { categoryID = value; }
        }

        private int paymentType;
        public int PaymentType
        {
            get { return paymentType; }
            set { paymentType = value; }
        }

        private MyDate date;
        public MyDate Date
        {
            get { return date; }
            set { date = value; }
        }
    }
}
