using QuanLyCuaHang.SanPham;
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
            List<Product> products = new List<Product>
        {
            new Mobile(1, "Samsung Galaxy", "Smartphone", 800, 1, "Samsung","360"),
            new Laptop(2, "Dell XPS", "High-performance laptop", 1500, 1, "16", "Intel i7")
        };

            /*    Product product = new Product(10,"name","Price","weight","memory") ;
                Console.WriteLine("+--------------------------------------+");
                Console.WriteLine("| ID | Name | Price | Weight | Memory  |");
                Console.WriteLine("+--------------------------------------+");
                Console.WriteLine(product.toString());
                Console.WriteLine("+--------------------------------------+");*/
            bool isRunning = true;
            while (isRunning)
            {
                Console.Clear(); // Xóa màn hình để hiển thị menu mới

                Console.WriteLine("+-------------------------------------------+");
                Console.WriteLine("| 1. Xem                                    |");
                Console.WriteLine("| 2. Them                                   |");
                Console.WriteLine("| 3. Xoa                                    |");
                Console.WriteLine("| 4. Tim kiem                               |");
                Console.WriteLine("| 5. Xuat file                              |");
                Console.WriteLine("| 6. Doc file                               |");
                Console.WriteLine("| 0. Thoat                                  |");
                Console.WriteLine("+-------------------------------------------+");
                Console.Write("Moi ban nhap lua chon: ");
                string luaChon = Console.ReadLine();
                switch (luaChon)
                {
                    case "1":
                        Product.DisplayProducts(products);
                        Console.ReadKey();
                        break;
                    case "2":
                        Console.WriteLine("Lua chon 2 da chon");
                        Console.ReadKey();
                        break;
                    case "3":
                        Console.WriteLine("Ban muon xoa ?");
                        Console.WriteLine("\t1 - San Pham");
                        Console.WriteLine("\t2 - Phieu Nhap Hang");
                        Console.Write("Lua chon? ");
                        switch (Console.ReadLine())
                        {
                            case "1":
                                Console.Write("Nhap ID san pham muon xoa: ");
                                int productIdToDelete = int.Parse(Console.ReadLine());
                                Product.DeleteProduct(productIdToDelete, products);
                                Console.ReadKey();
                                break;
                            case "2":
                                Console.WriteLine($"Your result: 2");
                                Console.ReadKey();
                                break;
                        }
                        break;
                    case "4":
                        Console.WriteLine("Ban muon tim ?");
                        Console.WriteLine("\t1 - San Pham");
                        Console.WriteLine("\t2 - Phieu Nhap Hang");
                        Console.Write("Lua chon? ");
                        switch (Console.ReadLine())
                        {
                            case "1":
                                Console.Write("Nhap ID san pham muon tim kiem: ");
                                int productIdToFind = int.Parse(Console.ReadLine());
                                Product foundProduct = Product.FindProductById(productIdToFind, products);
                                if (foundProduct != null)
                                    Console.WriteLine("San pham tim kiem:\n" + foundProduct.ToString());
                                else
                                    Console.WriteLine("Khong tim thay san pham voi ID " + productIdToFind);
                                Console.ReadKey();
                                break;
                            case "2":
                                Console.WriteLine($"Your result: 2");
                                Console.ReadKey();
                                break;
                        }
                        break;
                    case "5":
                        Console.WriteLine("Lua chon 5 da chon");
                        Console.ReadKey();
                        break;
                    case "0":
                        Console.WriteLine("Ket thuc chuong trinh");
                        isRunning = false; // Kết thúc chương trình
                        break;
                    default:
                        Console.WriteLine("Lua chon khong hop le, vui long nhap lai.");
                        Console.ReadKey();
                        break;

                }
            }

            Console.ReadKey();
        }
    }
}
