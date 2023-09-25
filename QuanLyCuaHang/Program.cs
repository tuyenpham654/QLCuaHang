using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyCuaHang
{
    internal class Program
    {
        static List<LoHang> danhSachLoHang = new List<LoHang>();
        static string filePath = "D:\\ThietBi.txt";
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

                Console.WriteLine("+---Thiết Bị Công Nghệ TTCP---+");
                Console.WriteLine("|------------MENU-------------|");
                Console.WriteLine("|1. Thêm lô hàng điện thoại   |");
                Console.WriteLine("|2. Thêm lô hàng laptop       |");
                Console.WriteLine("|3. Xóa lô hàng               |");
                Console.WriteLine("|4. Sửa thông tin lô hàng     |");
                Console.WriteLine("|5. Tìm kiếm lô hàng          |");
                Console.WriteLine("|6. Hiển thị danh sách lô hàng|");
                Console.WriteLine("|7. Lưu danh sách lô hàng     |");
                Console.WriteLine("|0. Thoát                     |");
                Console.Write("Moi ban nhap lua chon: ");
                string luaChon = Console.ReadLine();
                switch (luaChon)
                {
                    case "1":
                        Console.WriteLine("Lua chon 1 da chon");
                        danhSachLoHang.Add(ThemLoHang(LoaiThietBi.DienThoai));
                        LuuDanhSachLoHangVaoTep();
                        Console.ReadKey();
                        break;
                    case "2":
                        Console.WriteLine("Lua chon 2 da chon");
                        danhSachLoHang.Add(ThemLoHang(LoaiThietBi.Laptop));
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
                    case "6":
                        Console.WriteLine("Lua chon 6 da chon");
                        Console.ReadKey();
                        break;
                    case "7":
                        Console.WriteLine("Lua chon 7 da chon");
                       
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
        static LoHang ThemLoHang(LoaiThietBi loaiThietBi)
        {
            DateTime dt = DateTime.Now;
            dt.ToString("dd/MM/yyyy");
            Console.WriteLine($"Nhập thông tin lô hàng {loaiThietBi}:");
            Console.Write("Mã phiếu nhập hàng: ");
            string maPhieuNhap = Console.ReadLine();
           // Console.Write("Ngày nhập hàng: ");
           // DateTime ngayNhap = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy", null);
          //  DateTime ngayNhap = DateTime.UtcNow("dd/MM/yyyy");
            
            DateTime ngayNhap = dt;
            Console.Write("Tên nhà cung cấp: ");
            string nhaCungCap = Console.ReadLine();
            Console.Write("Mô tả cấu hình thiết bị: ");
            string moTa = Console.ReadLine();
            string maThung = "";
            string soSerial = "";

            if (loaiThietBi == LoaiThietBi.DienThoai)
            {
                Console.Write("Mã thùng của lô hàng điện thoại: ");
                maThung = Console.ReadLine();
            }
            else if (loaiThietBi == LoaiThietBi.Laptop)
            {
                Console.Write("Số serial của laptop: ");
                soSerial = Console.ReadLine();
            }

            Console.Write("Số lượng: ");
            int soLuong = int.Parse(Console.ReadLine());

            double giaTriNhap = 0;

            if (loaiThietBi == LoaiThietBi.DienThoai)
            {
                Console.Write("Đơn giá thùng: ");
                double donGiaThung = double.Parse(Console.ReadLine());
                Console.Write("Phí chuyên chở: ");
                double phiChuyenCho = double.Parse(Console.ReadLine());
                giaTriNhap = soLuong * donGiaThung + phiChuyenCho;
            }
            else if (loaiThietBi == LoaiThietBi.Laptop)
            {
                Console.Write("Giá vốn nhập hàng: ");
                double giaVonNhapHang = double.Parse(Console.ReadLine());
                Console.Write("Tỷ giá thuế: ");
                double tyGiaThue = double.Parse(Console.ReadLine());
                giaTriNhap = soLuong * (giaVonNhapHang + giaVonNhapHang * tyGiaThue);
            }

            return new LoHang
            {
                LoaiThietBi = loaiThietBi,
                MaPhieuNhap = maPhieuNhap,
                NgayNhap = ngayNhap,
                NhaCungCap = nhaCungCap,
                MoTa = moTa,
                MaThung = maThung,
                SoSerial = soSerial,
                SoLuong = soLuong,
                GiaTriNhap = giaTriNhap
            };
        }

        static void LuuDanhSachLoHangVaoTep()
        {
            using (StreamWriter sw = new StreamWriter(filePath))
            {
                foreach (var loHang in danhSachLoHang)
                {
                    sw.WriteLine($"{loHang.LoaiThietBi},{loHang.MaPhieuNhap},{loHang.NgayNhap},{loHang.NhaCungCap},{loHang.MoTa},{loHang.MaThung},{loHang.SoSerial},{loHang.SoLuong},{loHang.GiaTriNhap}");
                }
            }

            Console.WriteLine("Danh sách lô hàng đã được lưu vào tập tin.");
        }
    }
}
enum LoaiThietBi
{
    DienThoai,
    Laptop
}

 