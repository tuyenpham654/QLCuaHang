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
                        Console.WriteLine("Lua chon 1 da chon");
                        Console.ReadKey();
                        break;
                    case "2":
                        Console.WriteLine("Lua chon 2 da chon");
                        Console.ReadKey();
                        break;
                    case "3":
                        Console.WriteLine("Lua chon 3 da chon");
                        Console.ReadKey();
                        break;
                    case "4":
                        Console.WriteLine("Lua chon 4 da chon");
                        Console.ReadKey();
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
