using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.IO;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;


namespace QuanLyCuaHang
{
    internal class Program
    {

        static List<PhieuHang> danhSachPhieuHang = new List<PhieuHang>();
        static string filePath = "D:\\Nhom 2\\QLCuaHang\\QuanLyCuaHang\\file\\ThietBi.txt";

        static void Main(string[] args)
        {
            XuatVaDocFileTxt();
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
                        LuuDanhSachLoHangVaoTep();
                        Console.ReadKey();
                        break;
                    case "2":
                        Console.WriteLine("Lua chon 2 da chon");
                        InToanBoDonHang();
                       // Console.ReadKey();
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
                        InToanBoDonHang();
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
            int maPhieu;
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

            Console.WriteLine("+--- Nhập loại hàng ---+");
            Console.WriteLine("|1. Phiếu Laptop       |");
            Console.WriteLine("|2. Phiếu Điện thoại   |");
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

        static void LuuDanhSachLoHangVaoTep()
        {
            using (StreamWriter sw = new StreamWriter(filePath))
            {
                foreach (var phieuHang in danhSachPhieuHang)
                {
                    sw.WriteLine(phieuHang.toString());
                }
            }

            Console.WriteLine("Phiếu hàng đã được lưu vào tập tin.");
        }

        static void InToanBoDonHang()
        {
            Console.WriteLine("+-----------------------------------------------------------------------------------------------------+");
            Console.WriteLine("| Mã phiếu | Ngày nhập hàng | Tên NCC  | Loại hàng | Số lượng | Tên sản phẩm | Cấu hình | Tổng |");

            foreach (var phieuHang in danhSachPhieuHang)
            {
                Console.WriteLine(phieuHang.toString());
                Console.WriteLine("+------------------------------------------------------------------------------------------------------+");
            }
            
            Console.Write("Nhấn 1 để xem chi tiết từng mã.\nNhấn phím bất kỳ để thoát.");

            string check = (Console.ReadLine());

            if (check != "1") {

                
            }
            else
            {
                Console.Write("1. Nhập mã để xem chi tiết: ");
                int maPhieu = int.Parse(Console.ReadLine());
                PhieuHang phieuHangChiTiet = danhSachPhieuHang.Find(p => p.MaPhieu == maPhieu);
                phieuHangChiTiet.TimKiem();
            }
           
    

        }

        static void TimKiemDonHangTheoMaPhieu()
        {
            Console.WriteLine("Nhập mã phiếu cần tìm:");
            int maPhieu = int.Parse(Console.ReadLine());

            PhieuHang phieuHang = danhSachPhieuHang.Find(p => p.MaPhieu == maPhieu);

            if (phieuHang != null)
            {
                phieuHang.TimKiem();
               // Console.WriteLine(phieuHang.TimKiem());
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
            if (File.Exists(filePath))
            {
                using (StreamReader sr = new StreamReader(filePath))
                {
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        string[] parts = line.Split('|');


                        int maPhieu;
                        DateTime ngayNhapHang;
                        string tenNhaCungCap;
                        int loaiHang;
                        int soLuong;
                        string tenSP;
                        string moTa;

                        //Console.WriteLine("Nhập mã phiếu:");
                        maPhieu = int.Parse(parts[1].Trim());
                        ngayNhapHang = DateTime.Parse(parts[2].Trim());
                        tenNhaCungCap = parts[3].Trim();
                        loaiHang = int.Parse(parts[4].Trim());
                        soLuong = int.Parse(parts[5].Trim());
                        tenSP = parts[6].Trim();
                        moTa = parts[7].Trim();

                        if (loaiHang == 1)
                        {
                            string soSeri = parts[8].Trim();
                            double giaVonNhapHang = double.Parse(parts[9].Trim());
                            double tyGiaThue = double.Parse(parts[10].Trim());
                            LapTop laptop = new LapTop(maPhieu, ngayNhapHang, tenNhaCungCap, loaiHang, soLuong, tenSP,moTa  ,  soSeri, giaVonNhapHang, tyGiaThue);
                            danhSachPhieuHang.Add(laptop);
                        }
                        else if (loaiHang == 2)
                        {
                      
                            int maThung = int.Parse(parts[8].Trim());
                            double donGiaThung = double.Parse(parts[9].Trim());
                            double phiVanChuyen = double.Parse(parts[10].Trim());
                            DienThoai dienThoai = new DienThoai(maPhieu, ngayNhapHang, tenNhaCungCap, loaiHang, soLuong, tenSP,moTa , maThung, donGiaThung, phiVanChuyen);
                            danhSachPhieuHang.Add(dienThoai);
                        }
                    }
                }
            }
        }


        static void SuaPhieuNhap()
        {
            Console.Write("Nhập mã phiếu nhập hàng cần sửa: ");
            int maPhieu = int.Parse(Console.ReadLine());

            PhieuHang phieuHang = danhSachPhieuHang.Find(p => p.MaPhieu == maPhieu);
            // string maPhieuCanSua = Console.ReadLine();

            PhieuHang phieuCanSua = null;

            foreach (var phieuNhap in danhSachPhieuHang)
            {
                if (phieuNhap.MaPhieu == maPhieu)
                {
                    phieuCanSua = phieuNhap;
                    break;
                }
            }

            if (phieuCanSua != null)
            {
                Console.WriteLine("Chọn thông tin bạn muốn sửa:");
                Console.WriteLine("1. Ngày nhập hàng");
                Console.WriteLine("2. Nhà cung cấp");
                Console.WriteLine("3. Mô tả cấu hình");
                Console.WriteLine("4. Thông tin laptop");
                Console.WriteLine("5. Thông tin điện thoại");
                Console.Write("Nhập lựa chọn của bạn: ");
                int luaChon = int.Parse(Console.ReadLine());

                switch (luaChon)
                {
                    case 1:
                        Console.Write("Nhập ngày nhập hàng mới (dd/MM/yyyy): ");
                        string ngayNhapHangInput = Console.ReadLine();
                        if (DateTime.TryParseExact(ngayNhapHangInput, "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out DateTime ngayNhapHangMoi))
                        {
                            phieuCanSua.NgayNhapHang = ngayNhapHangMoi;
                            Console.WriteLine("Ngày nhập hàng đã được cập nhật.");
                        }
                        else
                        {
                            Console.WriteLine("Ngày không hợp lệ. Không thay đổi.");
                        }
                        break;
                    case 2:
                        Console.Write("Nhập tên nhà cung cấp mới: ");
                        string nhaCungCapMoi = Console.ReadLine();
                        phieuCanSua.TenNhaCungCap = nhaCungCapMoi;
                        Console.WriteLine("Nhà cung cấp đã được cập nhật.");
                        break;
                    case 3:
                        Console.Write("Nhập mô tả cấu hình mới: ");
                        string moTaCauHinhMoi = Console.ReadLine();
                        phieuCanSua.MoTa = moTaCauHinhMoi;
                        Console.WriteLine("Mô tả cấu hình đã được cập nhật.");
                        break;
                    case 4:
                        //SuaThongTinLaptop(phieuCanSua);
                        break;
                    case 5:
                        //SuaThongTinPhone(phieuCanSua);
                        break;
                    default:
                        Console.WriteLine("Lựa chọn không hợp lệ. Không thay đổi.");
                        break;
                }
            }
            else
            {
                Console.WriteLine("Không tìm thấy lô hàng có mã phiếu nhập này.");
            }
        }
        //Sửa thông tin Laptop
       /* static void SuaThongTinLaptop(PhieuHang phieuNhap)
        {
            Console.WriteLine("Sửa thông tin laptop trong lô hàng:");
            Console.Write("Nhập mã laptop cần sửa: ");
            string maLaptopCanSua = Console.ReadLine();

            Laptop laptopCanSua = null;

            foreach (var laptop in phieuNhap.DanhSachLaptop)
            {
                if (laptop.Serial_id == maLaptopCanSua)
                {
                    laptopCanSua = laptop;
                    break;
                }
            }

            if (laptopCanSua != null)
            {
                Console.WriteLine("Chọn thông tin bạn muốn sửa:");
                Console.WriteLine("1. Số serial");
                Console.WriteLine("2. Giá vốn");
                Console.WriteLine("3. Giá thuế");
                Console.Write("Nhập lựa chọn của bạn: ");
                int luaChon = int.Parse(Console.ReadLine());

                switch (luaChon)
                {
                    case 1:
                        Console.Write("Nhập số serial mới: ");
                        string soSerialMoi = Console.ReadLine();
                        laptopCanSua.Serial_id = soSerialMoi;
                        Console.WriteLine("Số serial đã được cập nhật.");
                        break;
                    case 2:
                        Console.Write("Nhập giá vốn mới: ");
                        double giaVonMoi = double.Parse(Console.ReadLine());
                        laptopCanSua.GiaVonNhapHang = giaVonMoi;
                        Console.WriteLine("Giá vốn đã được cập nhật.");
                        break;
                    case 3:
                        Console.Write("Nhập tỷ giá thuế mới: ");
                        double giaThueMoi = double.Parse(Console.ReadLine());
                        laptopCanSua.GiaVonNhapHang = giaThueMoi;
                        Console.WriteLine("Giá vốn đã được cập nhật.");
                        break;
                    default:
                        Console.WriteLine("Lựa chọn không hợp lệ. Không thay đổi.");
                        break;
                }
            }
            else
            {
                Console.WriteLine("Không tìm thấy laptop có mã tương ứng.");
            }
        }*/
        //Sửa Thông tin Phone
        /*static void SuaThongTinPhone(PhieuNhap phieuNhap)
        {
            Console.WriteLine("Sửa thông tin điện thoại trong lô hàng:");
            Console.Write("Nhập mã điện thoại cần sửa: ");
            string maDienThoaiCanSua = Console.ReadLine();

            Phone phoneCanSua = null;

            foreach (var phone in phieuNhap.DanhSachPhone)
            {
                if (phone.Box_id == maDienThoaiCanSua)
                {
                    phoneCanSua = phone;
                    break;
                }
            }

            if (phoneCanSua != null)
            {
                Console.WriteLine("Chọn thông tin bạn muốn sửa:");
                Console.WriteLine("1. Số thùng");
                Console.WriteLine("2. Giá vốn");
                Console.WriteLine("2. Phí chuyên chỡ");
                Console.Write("Nhập lựa chọn của bạn: ");
                int luaChon = int.Parse(Console.ReadLine());

                switch (luaChon)
                {
                    case 1:
                        Console.Write("Nhập số thùng mới: ");
                        string soSerialMoi = Console.ReadLine();
                        phoneCanSua.Box_id = soSerialMoi;
                        Console.WriteLine("Số serial đã được cập nhật.");
                        break;
                    case 2:
                        Console.Write("Nhập giá vốn mới: ");
                        double donGiaThungMoi = double.Parse(Console.ReadLine());
                        phoneCanSua.DonGiaThung = donGiaThungMoi;
                        Console.WriteLine("Giá vốn đã được cập nhật.");
                        break;
                    case 3:
                        Console.Write("Nhập phí chuyên chỡ mới: ");
                        double phiChuyenChoMoi = double.Parse(Console.ReadLine());
                        phoneCanSua.DonGiaThung = phiChuyenChoMoi;
                        Console.WriteLine("Giá vốn đã được cập nhật.");
                        break;
                    default:
                        Console.WriteLine("Lựa chọn không hợp lệ. Không thay đổi.");
                        break;
                }
            }
            else
            {
                Console.WriteLine("Không tìm thấy điện thoại có mã tương ứng.");
            }
        }*/
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
}
/*enum LoaiThietBi
{
    DienThoai,
    Laptop
}

 */