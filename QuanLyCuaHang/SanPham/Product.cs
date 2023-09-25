using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyCuaHang
{
    class Product
    {
        private int product_id;
        private string name;
        private string description;
        private double price;

        public int Product_id { get => product_id; set => product_id = value; }
        public string Name { get => name; set => name = value; }
        public string Description { get => description; set => description = value; }
        public double Price { get => price; set => price = value; }

        public Product(int product_id, string name, string description, double price)
        {
            this.Product_id = product_id;
            this.Name = name;
            this.Description = description;
            this.Price = price;
        }

        public string toString()
        {
            return $"{Product_id} | {Name} | {Description} | {Price} |";
        }

    }
}
