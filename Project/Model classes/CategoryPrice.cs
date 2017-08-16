//Copyright © 2010-2012 , Farshad Barahimi . All rights reserved
//This software is licensed under the Apache License, Version 2.0

using System;
using System.Collections.Generic;
using System.Text;

namespace Project.ModelClasses
{
    public class CategoryPrice
    {
        public CategoryPrice(int categoryID, double price)
        {
            this.categoryID = categoryID;
            this.price = price;
        }
        
        private int categoryID;
        public int CategoryID
        {
            get { return categoryID; }
            set { categoryID = value; }
        }

        private double price;
        public double Price
        {
            get { return price; }
            set { price = value; }
        }
    }
}
