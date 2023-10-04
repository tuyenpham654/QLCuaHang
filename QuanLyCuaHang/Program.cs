using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using test1;

namespace QuanLyCuaHang
{
    internal class Program
    {
    
        static List<PhieuHang> danhSachPhieuHang = new List<PhieuHang>();
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
                Console.OutputEncoding = Encoding.UTF8;
                Console.WriteLine("+---Thiết Bị Công Nghệ TTCP---+");
                Console.WriteLine("|------------MENU-------------|");
                Console.WriteLine("|1. Thêm phiếu hàng           |");
                Console.WriteLine("|2. Xem phiếu hàng            |");
                Console.WriteLine("|3. Xóa phiếu hàng            |");
                Console.WriteLine("|4. Sửa phiếu hàng            |");
                Console.WriteLine("|5. Tìm kiếm phiếu hàng       |");
                Console.WriteLine("|6. Xuất file phiếu hàng      |");
                Console.WriteLine("|7. Đọc file phiếu hàng       |");
                Console.WriteLine("|0. Thoát                     |");
                Console.Write("Mời bạn nhập lựa chọn: ");
                string luaChon = Console.ReadLine();
                switch (luaChon)
                {
                    case "1":
                        Console.WriteLine("Lua chon 1 da chon");
                        AddPhieuHang();
                        Console.ReadKey();
                        break;
                    case "2":
                        Console.WriteLine("Lua chon 2 da chon");
                        InToanBoDonHang();
                        Console.ReadKey();
                        break;
                    case "3":
                        Console.WriteLine("Lua chon 3 da chon");
                        XoaDonHang();
                        Console.ReadKey();
                        break;
                    case "4":
                        Console.WriteLine("Lua chon 4 da chon");
                        SuaDonHang();
                        Console.ReadKey();
                        break;
                    case "5":
                        Console.WriteLine("Lua chon 5 da chon");
                        TimKiemDonHangTheoMaPhieu();
                        break;
                    case "6":
                        Console.WriteLine("Lua chon 6 da chon");
                        XuatVaDocFileTxt();
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

        static void AddPhieuHang()
        {
            int maPhieu = 1;
            DateTime ngayNhapHang;
            string tenNhaCungCap;
            int loaiHang;
            int soLuong;
            string tenSP;

            Console.WriteLine("Nhập mã phiếu:");
            maPhieu = int.Parse(Console.ReadLine());

            Console.WriteLine("Nhập ngày nhập hàng (dd/mm/yyyy):");
            ngayNhapHang = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy", null);

            Console.WriteLine("Nhập tên nhà cung cấp:");
            tenNhaCungCap = Console.ReadLine();

            Console.WriteLine("Nhập loại hàng (1 - Laptop, 2 - Điện thoại):");
             loaiHang = int.Parse(Console.ReadLine());

            Console.WriteLine("Nhập số lượng:");
            soLuong = int.Parse(Console.ReadLine());

            Console.WriteLine("Nhập tên sản phẩm:");
             tenSP = Console.ReadLine();

            Console.WriteLine("Nhập mô tả cấu hình:");
            string moTa = Console.ReadLine();

            if (loaiHang == 1)
            {
                string soSeri;
                Console.WriteLine("Nhập số seri:");
                 soSeri = Console.ReadLine();
                double giaVonNhapHang;
                Console.WriteLine("Nhập giá vốn nhập hàng:");
                giaVonNhapHang = double.Parse(Console.ReadLine());
                double tyGiaThue;
                Console.WriteLine("Nhập tỷ giá thuế:");
                tyGiaThue = double.Parse(Console.ReadLine());

                LapTop laptop = new LapTop(maPhieu, ngayNhapHang, tenNhaCungCap, loaiHang, soLuong, tenSP, moTa, soSeri, giaVonNhapHang, tyGiaThue);
                danhSachPhieuHang.Add(laptop);
            }
            else if (loaiHang == 2)
            {
                Console.WriteLine("Nhập mã thùng:");
                int maThung = int.Parse(Console.ReadLine());

                Console.WriteLine("Nhập đơn giá thùng:");
                double donGiaThung = double.Parse(Console.ReadLine());

                Console.WriteLine("Nhập phí vận chuyển:");
                double phiVanChuyen = double.Parse(Console.ReadLine());

                DienThoai dienThoai = new DienThoai(maPhieu, ngayNhapHang, tenNhaCungCap, loaiHang, soLuong, tenSP, moTa, maThung, donGiaThung, phiVanChuyen);
                danhSachPhieuHang.Add(dienThoai);
            }

            Console.WriteLine("Thông tin phiếu hàng đã được nhập.");
        }

        static void InToanBoDonHang()
        {
            Console.WriteLine("+----------------------------------------------------------------------------------------------+");
            Console.WriteLine("| Mã phiếu | Ngày nhập hàng | Tên nhà cung cấp | Loại hàng | Số lượng| Tên sản phẩm | Cấu hình | Tổng |");
           
           
            foreach (var phieuHang in danhSachPhieuHang)
            {
                
                Console.WriteLine(phieuHang.toString());
            }
            Console.WriteLine("+----------------------------------------------------------------------------------------------+");
        }

        static void TimKiemDonHangTheoMaPhieu()
        {
            Console.WriteLine("Nhập mã phiếu cần tìm:");
            int maPhieu = int.Parse(Console.ReadLine());

            PhieuHang phieuHang = danhSachPhieuHang.Find(p => p.MaPhieu == maPhieu);

            if (phieuHang != null)
            {
                phieuHang.toString();
                Console.WriteLine(phieuHang.toString());
            }
            else
            {
                Console.WriteLine("Không tìm thấy phiếu hàng có mã phiếu này.");
            }
        }

        static void SuaDonHang()
        {
            Console.WriteLine("Nhập mã phiếu cần sửa:");
            int maPhieu = int.Parse(Console.ReadLine());

            PhieuHang phieuHang = danhSachPhieuHang.Find(p => p.MaPhieu == maPhieu);

            if (phieuHang != null)
            {
                // Hãy thêm mã code để chỉnh sửa thông tin phiếu hàng ở đây
                Console.WriteLine("Chức năng sửa đang phát triển.");
            }
            else
            {
                Console.WriteLine("Không tìm thấy phiếu hàng có mã phiếu này.");
            }
        }

        static void XoaDonHang()
        {
            Console.WriteLine("Nhập mã phiếu cần xóa:");
            int maPhieu = int.Parse(Console.ReadLine());

            PhieuHang phieuHang = danhSachPhieuHang.Find(p => p.MaPhieu == maPhieu);

            if (phieuHang != null)
            {
                danhSachPhieuHang.Remove(phieuHang);
                Console.WriteLine("Đã xóa phiếu hàng có mã phiếu này.");
            }
            else
            {
                Console.WriteLine("Không tìm thấy phiếu hàng có mã phiếu này.");
            }
        }

        static void XuatVaDocFileTxt()
        {
            // Hãy thêm mã code để xuất và đọc file txt thông tin phiếu nhập ở đây
            Console.WriteLine("Chức năng xuất và đọc file đang phát triển.");
        }
    }
    /*  static LoHang ThemLoHang(LoaiThietBi loaiThietBi)
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
}*/
}
/*enum LoaiThietBi
{
    DienThoai,
    Laptop
}

 */