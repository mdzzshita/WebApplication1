﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class Customer
    {
        public string CustomerName
        {
            get;
            set;
        }

        //public string Hobby
        //{
        //    get;
        //    set;
        //}

        public Address CustomerAddress { get; set; }

        //public override string ToString()
        //{
        //    return this.CustomerName + "-" + this.Address;
        //}

    }
}