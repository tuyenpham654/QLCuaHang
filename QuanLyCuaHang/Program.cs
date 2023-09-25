using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyCuaHang
{
    internal class Program
    {
        static void Main(string[] args)
        {
           
            Product product = new Product(10,"name","Price","weight","memory") ;
            Console.WriteLine("+--------------------------------------+");
            Console.WriteLine("| ID | Name | Price | Weight | Memory  |");
            Console.WriteLine("+--------------------------------------+");
            Console.WriteLine(product.toString());
            Console.WriteLine("+--------------------------------------+");
            Console.ReadKey();
        }
    }
}
