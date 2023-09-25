using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyCuaHang
{
    internal class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Price { get; set; }
        public string Weight { get; set; }
        public string Memory { get; set; }
        public Product()
        {
            Id = 0;
            Name = "";
            Price = "";
            Weight = "";
            Memory = "";
        }
        public Product(int _Id, string _Name,string _Price, string _Weight, string _Memory)
        {
            this.Id = _Id;
            this.Name = _Name;
            this.Price = _Price;
            this.Weight = _Weight;  
            this.Memory = _Memory;
        }
        public string toString()
        {
            return $"+ {Id} | {Name} | {Price} | {Weight} | {Memory}  + ";
        }

    }

  
}
