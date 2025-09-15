using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2_8_1
{
    public enum Categories
    {
        Food,
        Appliances
    }
    public class Product
    {
        public string ProductName { get; set; }
        public decimal Price { get; set; }
        public string ImagePath { get; set; }
        public Categories Category {get;set;}
  
    }
}
