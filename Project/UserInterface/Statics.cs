//Copyright © 2010-2012 , Farshad Barahimi . All rights reserved
//This software is licensed under the Apache License, Version 2.0

using System;
using System.Collections.Generic;
using System.Text;
using Project.ModelClasses;
using Project.DataLayer;
using System.Windows.Forms;
using System.IO;

namespace Project.UserInterface
{
    public class Statics
    {
        public static MyDate LastUsedDate;
        public static MyDate Today;
        public static string ApplicationPath;
        public static DataMapper DataMapper;
        public const int CashPayemnet=0;
        public const int CheckPayment=1;
        public const int CreditCardPayment=2;
        public const int OtherPayment = 3;
    }
}
