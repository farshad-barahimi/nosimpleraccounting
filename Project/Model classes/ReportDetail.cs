//Copyright © 2010-2012 , Farshad Barahimi . All rights reserved
//This software is licensed under the Apache License, Version 2.0

using System;
using System.Collections.Generic;
using System.Text;

namespace Project.ModelClasses
{
    /// <summary>
    /// This class is used to model the details of a report.
    /// </summary>
    public class ReportDetail
    {
        public ReportDetail(MyDate fromDate, MyDate toDate, bool isCash, bool isCheck, bool isCreditCard, bool isOther)
        {
            this.fromDate = fromDate;
            this.toDate = toDate;
            this.isCash = isCash;
            this.isCheck = isCheck;
            this.isCreditCard = isCreditCard;
            this.isOther = isOther;
        }

        private MyDate fromDate;
        public MyDate FromDate
        {
            get { return fromDate; }
            set { fromDate = value; }
        }
        
        private MyDate toDate;
        public MyDate ToDate
        {
            get { return toDate; }
            set { toDate = value; }
        }
        
        private bool isCash;
        public bool IsCash
        {
            get { return isCash; }
            set { isCash = value; }
        }

        private bool isCheck;
        public bool IsCheck
        {
            get { return isCheck; }
            set { isCheck = value; }
        }

        private bool isCreditCard;
        public bool IsCreditCard
        {
            get { return isCreditCard; }
            set { isCreditCard = value; }
        }

        private bool isOther;
        public bool IsOther
        {
            get { return isOther; }
            set { isOther = value; }
        }
    }
}
