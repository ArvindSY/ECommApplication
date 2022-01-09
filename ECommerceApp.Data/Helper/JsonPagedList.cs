using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerceApp.Data.Helper
{
    public class JsonPagedList
    {
        public string JsonSourceList { get; set; }
        public int TotalCount { get; set; }
        public string TotalAmount { get; set; }
        public string ListParameterOne { get; set; }
        public string ListParameterTwo { get; set; }
    }
}
