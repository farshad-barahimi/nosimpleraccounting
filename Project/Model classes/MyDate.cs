//Copyright © 2010-2012 , Farshad Barahimi . All rights reserved
//This software is licensed under the Apache License, Version 2.0

using System;
using System.Collections.Generic;
using System.Text;

namespace Project.ModelClasses
{
    public struct MyDate
    {
        public MyDate(int year, int month, int day)
        {
            this.year = year;
            this.month = month;
            this.day = day;
        }

        private int year;
        public int Year
        {
            get { return year; }
            set { year = value; }
        }

        private int month;
        public int Month
        {
            get { return month; }
            set { month = value; }
        }

        private int day;
        public int Day
        {
            get { return day; }
            set { day = value; }
        }
    }
}
