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

        private List<Product> products;

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

        public override string ToString()
        {
            return $" Product_id: {Product_id}\n Name: {Name}\n Description: {Description}\n Price: {Price}\n";
        }

        public static bool DeleteProduct(int productId, List<Product> products)
        {
            Product productToRemove = products.FirstOrDefault(p => p.Product_id == productId);
            if (productToRemove != null)
            {
                products.Remove(productToRemove);
                Console.WriteLine("San pham voi ID " + productId + " da duoc xoa thanh cong.");
                return true;
            }
            else
            {
                Console.WriteLine("Khong tim thay san pham voi ID " + productId);
                return false;
            }
        }
        public static void DisplayProducts(List<Product> products)
        {
            if (products.Count == 0)
            {
                Console.WriteLine("Khong co san pham nao duoc them.");
                return;
            }

            Console.WriteLine("Danh sach san pham:");
            foreach (var product in products)
            {
                Console.WriteLine(product.ToString());
                Console.WriteLine("-------------");
            }
        }
        public static Product FindProductById(int productId, List<Product> products)
        {
            return products.FirstOrDefault(p => p.Product_id == productId);
        }
    }
}
