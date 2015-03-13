using System;

namespace ProductsManagementApp
{
    public class Product : IPrintable
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Cost { get; set; }
        public int Units { get; set; }
        public int Category { get; set; }

       
    }
}