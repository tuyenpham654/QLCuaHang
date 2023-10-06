using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;


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
                Console.WriteLine("      +---Thiết Bị Công Nghệ TTCP---+");
                Console.WriteLine("      |------------MENU-------------|");
                Console.WriteLine("      |1. Thêm phiếu hàng           |");
                Console.WriteLine("      |2. Xem phiếu hàng            |");
                Console.WriteLine("      |3. Xóa phiếu hàng            |");
                Console.WriteLine("      |4. Sửa phiếu hàng            |");
                Console.WriteLine("      |5. Tìm kiếm phiếu hàng       |");
                Console.WriteLine("      |6. Xuất file phiếu hàng      |");
  //              Console.WriteLine("      |7. Đọc file phiếu hàng       |");
                Console.WriteLine("      |0. Thoát                     |");
                Console.Write("      Mời bạn nhập lựa chọn: ");
                string luaChon = Console.ReadLine();
                switch (luaChon)
                {
                    case "1":
                        Console.WriteLine("      Lựa chọn 1 đã được chọn");
                        AddPhieuHang();
                        LuuDanhSachLoHangVaoTep();
                        Console.ReadKey();
                        break;
                    case "2":
                        Console.WriteLine("      Lựa chọn 2 đã được chọn");
                        InToanBoDonHang();
                        LuuDanhSachLoHangVaoTep();
                       // Console.ReadKey();
                        break;
                    case "3":
                        Console.WriteLine("      Lựa chọn 3 đã được chọn");
                        XoaDonHang();
                        LuuDanhSachLoHangVaoTep();
                        Console.ReadKey();
                        break;
                    case "4":
                        Console.WriteLine("      Lựa chọn 4 đã được chọn");
                        SuaPhieuNhap();
                        Console.ReadKey();
                        break;
                    case "5":
                        Console.WriteLine("      Lựa chọn 5 đã được chọn");
                        TimKiemDonHangTheoMaPhieu();
                        break;
                    case "6":
                        Console.WriteLine("      Lựa chọn 6 đã được chọn");
                      //  InToanBoDonHang();
                        LuuDanhSachLoHangVaoTep();
                        Console.ReadKey();
                        break;
             /*       case "7":
                        Console.WriteLine("      Lựa chọn đã được chọn");

                        Console.ReadKey();
                        break;*/

                    case "0":
                        Console.WriteLine("      Kết thúc chương trình");
                        isRunning = false; // Kết thúc chương trình
                        break;
                    default:
                        Console.WriteLine("      Lựa chọn không hợp lệ.  Vui lòng nhập lại: ");
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
            int maHangCanKiemTra;
            bool kiemtra;
            Console.Write("      Nhập mã phiếu:");
            do
            {
                kiemtra = int.TryParse(Console.ReadLine(), out maHangCanKiemTra);
                if (kiemtra == true)
                {
                    PhieuHang ph = danhSachPhieuHang.Find(p => p.MaPhieu == maHangCanKiemTra);

                    if (ph == null)
                    {
                        kiemtra = true;

                    }
                    else
                    {
                        Console.Write("      Mã hàng tồn tại trong danh sách, mời nhập lại: ");
                        kiemtra = false;
                    }
                }
                else
                {
                    Console.Write("      Dữ liệu không hợp lệ, mời nhập lại mã: ");
                }

            } while (kiemtra == false);

            maPhieu = maHangCanKiemTra;
            Console.Write("      Nhập ngày nhập hàng (dd/mm/yyyy): ");
            kiemtra = DateTime.TryParseExact(Console.ReadLine(), "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out ngayNhapHang);
            //   kiemtra = uint.TryParse(Console.ReadLine(), out uint maPhieu);
            while (kiemtra == false)
            {
                Console.Write("      Định dạng không hợp lệ, mời nhập lại (dd/mm/yyyy): ");
                kiemtra = DateTime.TryParseExact(Console.ReadLine(), "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out ngayNhapHang);
            }
            Console.Write("      Nhập tên nhà cung cấp: ");
            tenNhaCungCap = Console.ReadLine();

            Console.WriteLine("      +--- Nhập loại hàng ---+");
            Console.WriteLine("      |1. Phiếu Laptop       |");
            Console.WriteLine("      |2. Phiếu Điện thoại   |");
            //      loaiHang = int.Parse(Console.ReadLine());
            do
            {
                kiemtra = int.TryParse(Console.ReadLine(), out loaiHang);
                if (kiemtra == true)
                {
                   if(loaiHang == 1 || loaiHang == 2)
                    {
                        kiemtra = true;
                    }
                    else
                    {
                        Console.Write("      Chỉ được nhập 1 hoặc 2, mời nhập lại:  ");
                        kiemtra = false;
                    }
                }
                else
                {
                    Console.Write("      Chỉ được nhập 1 hoặc 2, mời nhập lại:  ");
                }

            } while (kiemtra == false);

            Console.Write("      Nhập số lượng: ");
            kiemtra = int.TryParse(Console.ReadLine(), out  soLuong);
            while (kiemtra == false)
            {
                Console.Write("      Dữ liệu không hợp lệ, mời nhập lại: ");
                kiemtra = int.TryParse(Console.ReadLine(), out soLuong);
            }
           // soLuong = int.Parse(Console.ReadLine());

            Console.Write("      Nhập tên sản phẩm:");
            tenSP = Console.ReadLine();

            Console.Write("      Nhập mô tả cấu hình:");
            string moTa = Console.ReadLine();

            if (loaiHang == 1)
            {
                string soSeri;
                Console.Write("      Nhập số seri:");
                soSeri = Console.ReadLine();
                double giaVonNhapHang;
                double tyGiaThue;
                Console.Write("      Nhập giá vốn nhập hàng:");

                kiemtra = double.TryParse(Console.ReadLine(), out giaVonNhapHang);
                while (kiemtra == false)
                {
                    Console.Write("      Dữ liệu không hợp lệ, mời nhập lại: ");
                    kiemtra = double.TryParse(Console.ReadLine(), out giaVonNhapHang);
                }

              //  giaVonNhapHang = double.Parse(Console.ReadLine());
             
                Console.Write("      Nhập tỷ giá thuế:");
                kiemtra = double.TryParse(Console.ReadLine(), out tyGiaThue);
                while (kiemtra == false)
                {
                    Console.Write("      Dữ liệu không hợp lệ, mời nhập lại: ");
                    kiemtra = double.TryParse(Console.ReadLine(), out tyGiaThue);
                }
               // tyGiaThue = double.Parse(Console.ReadLine());

                LapTop laptop = new LapTop(maPhieu, ngayNhapHang, tenNhaCungCap, loaiHang, soLuong, tenSP, moTa, soSeri, giaVonNhapHang, tyGiaThue);
                danhSachPhieuHang.Add(laptop);
            }
            else if (loaiHang == 2)
            {
                int maThung;
                double donGiaThung;
                double phiVanChuyen;
                Console.Write("      Nhập mã thùng: ");
                kiemtra = int.TryParse(Console.ReadLine(), out maThung);
                while (kiemtra == false)
                {
                    Console.Write("      Dữ liệu không hợp lệ, mời nhập lại: ");
                    kiemtra = int.TryParse(Console.ReadLine(), out maThung);
                }
                Console.Write("      Nhập đơn giá thùng:");
                kiemtra = double.TryParse(Console.ReadLine(), out donGiaThung);
                while (kiemtra == false)
                {
                    Console.Write("      Dữ liệu không hợp lệ, mời nhập lại: ");
                    kiemtra = double.TryParse(Console.ReadLine(), out donGiaThung);
                }


                Console.Write("      Nhập phí vận chuyển:");

                kiemtra = double.TryParse(Console.ReadLine(), out phiVanChuyen);
                while (kiemtra == false)
                {
                    Console.Write("      Dữ liệu không hợp lệ, mời nhập lại: ");
                    kiemtra = double.TryParse(Console.ReadLine(), out phiVanChuyen);
                }

                DienThoai dienThoai = new DienThoai(maPhieu, ngayNhapHang, tenNhaCungCap, loaiHang, soLuong, tenSP, moTa, maThung, donGiaThung, phiVanChuyen);
                danhSachPhieuHang.Add(dienThoai);
            }

            Console.WriteLine("      Thông tin phiếu hàng đã được nhập.");
        }

        static void LuuDanhSachLoHangVaoTep()
        {
            using (StreamWriter sw = new StreamWriter(filePath))
            {
                foreach (var phieuHang in danhSachPhieuHang)
                {
                    sw.WriteLine(phieuHang.getAll());
                }
            }

            Console.WriteLine("      Phiếu hàng đã được lưu vào tập tin.");
        }

        static void InToanBoDonHang()
        {
            Console.WriteLine("         +--------------------------------------------------------------------------------------------------------------------------------------+");
            Console.WriteLine("         | Mã phiếu | Ngày nhập hàng | Tên nhà cung cấp  | Loại hàng | Số lượng |     Tên sản phẩm     |        Cấu hình        |      Tổng      |");
            Console.WriteLine("         +--------------------------------------------------------------------------------------------------------------------------------------+");

            foreach (var phieuHang in danhSachPhieuHang)
            {
                Console.OutputEncoding = Encoding.UTF8;
                Console.WriteLine("         " + phieuHang.toString());
                Console.WriteLine("         +--------------------------------------------------------------------------------------------------------------------------------------+");
            }
            
            Console.Write("         Nhấn 1 để xem chi tiết từng mã.\n         Nhấn phím bất kỳ để thoát.");

            string check = (Console.ReadLine());

            if (check != "1") {
            
            }
            else
            {
                Console.Write("         1. Nhập mã phiếu để xem chi tiết: ");
                bool kiemtra;
                int maPhieu;
                do
                {
                    kiemtra = int.TryParse(Console.ReadLine(), out maPhieu);
                    if (kiemtra == true)
                    {
                        PhieuHang phieuHangChiTiet = danhSachPhieuHang.Find(p => p.MaPhieu == maPhieu);

                        if (phieuHangChiTiet != null)
                        {
                            phieuHangChiTiet.TimKiem();
                        }
                        else
                        {
                            Console.Write("         Mã không hàng tồn tại trong danh sách, mời nhập lại: ");
                            kiemtra = false;
                        }
                    }
                    else
                    {
                        Console.Write("         Dữ liệu không hợp lệ, mời nhập lại mã: ");
                    }

                } while (kiemtra == false);
             
            }
           
    

        }

        static void TimKiemDonHangTheoMaPhieu()
        {
            bool kiemtra;
            int maPhieu;
            Console.Write("      Nhập mã phiếu cần tìm: ");
            do
            {
                kiemtra = int.TryParse(Console.ReadLine(), out maPhieu);
                if (kiemtra == true)
                {
                    PhieuHang phieuHang = danhSachPhieuHang.Find(p => p.MaPhieu == maPhieu);

                    if (phieuHang != null)
                    {
                        phieuHang.TimKiem();
                    }
                    else
                    {
                        Console.Write("      Không tìm thấy phiếu hàng có mã phiếu này.");
                        kiemtra = true;
                        Console.ReadKey();
                
                    }
                }
                else
                {
                    Console.Write("      Dữ liệu không hợp lệ, mời nhập lại mã: ");
                }

            } while (kiemtra == false);
        }

        static void XoaDonHang()
        {
            Console.Write("      Nhập mã phiếu cần xóa:");
            int maPhieu = int.Parse(Console.ReadLine());

            PhieuHang phieuHang = danhSachPhieuHang.Find(p => p.MaPhieu == maPhieu);

            if (phieuHang != null)
            {
                danhSachPhieuHang.Remove(phieuHang);
                Console.WriteLine("      Đã xóa phiếu hàng có mã phiếu này.");
            }
            else
            {
                Console.WriteLine("      Không tìm thấy phiếu hàng có mã phiếu này.");
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

            PhieuHang phieuCanSua = null;

            foreach (var phieuHang in danhSachPhieuHang)
            {
                if (phieuHang.MaPhieu == maPhieu)
                {
                    phieuCanSua = phieuHang;
                    break;
                }
            }

            if (phieuCanSua != null)
            {
                Console.WriteLine("      Chọn thông tin bạn muốn sửa:");
                Console.WriteLine("      1. Ngày nhập hàng");
                Console.WriteLine("      2. Nhà cung cấp");
                Console.WriteLine("      3. Mô tả cấu hình");
                if (phieuCanSua.LoaiHang == 1)
                {
                    Console.WriteLine("      4. Thông tin laptop");
                }
                else if (phieuCanSua.LoaiHang == 2)
                {
                    Console.WriteLine("      4. Thông tin điện thoại");
                }
                Console.Write("      Nhập lựa chọn của bạn: ");
                int luaChon = int.Parse(Console.ReadLine());

                switch (luaChon)
                {
                    case 1:
                        Console.Write("      Nhập ngày nhập hàng mới (dd/MM/yyyy): ");
                        string ngayNhapHangInput = Console.ReadLine();
                        if (DateTime.TryParseExact(ngayNhapHangInput, "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out DateTime ngayNhapHangMoi))
                        {
                            phieuCanSua.NgayNhapHang = ngayNhapHangMoi;
                            Console.WriteLine("      Ngày nhập hàng đã được cập nhật.");
                        }
                        else
                        {
                            Console.WriteLine("      Ngày không hợp lệ. Không thay đổi.");
                        }
                        break;
                    case 2:
                        Console.Write("      Nhập tên nhà cung cấp mới: ");
                        string nhaCungCapMoi = Console.ReadLine();
                        phieuCanSua.TenNhaCungCap = nhaCungCapMoi;
                        Console.WriteLine("      Nhà cung cấp đã được cập nhật.");
                        break;
                    case 3:
                        Console.Write("      Nhập mô tả cấu hình mới: ");
                        string moTaCauHinhMoi = Console.ReadLine();
                        phieuCanSua.MoTa = moTaCauHinhMoi;
                        Console.WriteLine("      Mô tả cấu hình đã được cập nhật.");
                        break;
                    case 4:
                       
                        if (phieuCanSua.LoaiHang == 1)
                        {
                           // SuaThongTinLaptop(phieuCanSua);
                        }
                        else if (phieuCanSua.LoaiHang == 2)
                        {
                           // SuaThongTinDienThoai(phieuCanSua);
                        }
                        break;
                  
                    default:
                        Console.WriteLine("      Lựa chọn không hợp lệ. Không thay đổi.");
                        break;
                }
            }
            else
            {
                Console.WriteLine("      Không tìm thấy lô hàng có mã phiếu nhập này.");
            }
        }
        //Sửa thông tin Laptop
        static void SuaThongTinLaptop(LapTop phieuCanSua)
        {
            Console.WriteLine("      Sửa thông tin laptop trong lô hàng:");

          /*  // Hiển thị danh sách các laptop trong lô hàng
            Console.WriteLine("Danh sách laptop:");
            foreach (var laptop in phieuHang.)
            {
                Console.WriteLine($"- Số serial: {laptop.SoSeri}");
            }

            Console.Write("Nhập số serial của laptop cần sửa: ");
            string soSerialMoi = Console.ReadLine();

            // Tìm laptop cần sửa
            LapTop laptopCanSua = phieuHang.DanhSachLaptop.FirstOrDefault(l => l.SoSeri == soSerialMoi);*/

            if (phieuCanSua != null)
            {
                Console.WriteLine("      Chọn thông tin bạn muốn sửa:");
                Console.WriteLine("      1. Số serial");
                Console.WriteLine("      2. Giá vốn");
                Console.WriteLine("      3. Giá thuế");
                Console.Write("      Nhập lựa chọn của bạn: ");
                int luaChon = int.Parse(Console.ReadLine());

                switch (luaChon)
                {
                    case 1:
                        Console.Write("      Nhập số serial mới: ");
                        string soSerialMoi2 = Console.ReadLine();
                        phieuCanSua.SoSeri = soSerialMoi2;
                        Console.WriteLine("      Số serial đã được cập nhật.");
                        break;
                    case 2:
                        Console.Write("      Nhập giá vốn mới: ");
                        double giaVonMoi = double.Parse(Console.ReadLine());
                        phieuCanSua.GiaVonNhapHang = giaVonMoi;
                        Console.WriteLine("      Giá vốn đã được cập nhật.");
                        break;
                    case 3:
                        Console.Write("      Nhập tỷ giá thuế mới: ");
                        double giaThueMoi = double.Parse(Console.ReadLine());
                        phieuCanSua.TyGiaThue = giaThueMoi;
                        Console.WriteLine("      Tỷ giá thuế đã được cập nhật.");
                        break;
                    default:
                        Console.WriteLine("      Lựa chọn không hợp lệ. Không thay đổi.");
                        break;
                }
            }
            else
            {
                Console.WriteLine("      Không tìm thấy laptop có số serial tương ứng.");
            }
        }

        static void SuaThongTinDienThoai(DienThoai phieuCanSua)
        {
            Console.WriteLine("      Sửa thông tin điện thoại trong lô hàng:");
/*
            // Hiển thị danh sách các điện thoại trong lô hàng
            Console.WriteLine("Danh sách điện thoại:");
            foreach (var dt in phieuCanSua.)
            {
                Console.WriteLine($"- Mã thùng: {dt.MaThung}");
            }

            Console.Write("Nhập mã thùng của điện thoại cần sửa: ");
            int maThungMoi = int.Parse(Console.ReadLine());

            // Tìm điện thoại cần sửa
            DienThoai dienThoaiCanSua = phieuHang.DanhSachPhone.FirstOrDefault(dt => dt.MaThung == maThungMoi);
*/
            if (phieuCanSua != null)
            {
                Console.WriteLine("      Chọn thông tin bạn muốn sửa:");
                Console.WriteLine("      1. Mã thùng");
                Console.WriteLine("      2. Đơn giá thùng");
                Console.WriteLine("      3. Phí vận chuyển");
                Console.Write("      Nhập lựa chọn của bạn: ");
                int luaChon = int.Parse(Console.ReadLine());

                switch (luaChon)
                {
                    case 1:
                        Console.Write("      Nhập mã thùng mới: ");
                        int maThungMoi2 = int.Parse(Console.ReadLine());
                        phieuCanSua.MaThung = maThungMoi2;
                        Console.WriteLine("Mã thùng đã được cập nhật.");
                        break;
                    case 2:
                        Console.Write("      Nhập đơn giá thùng mới: ");
                        double donGiaThungMoi = double.Parse(Console.ReadLine());
                        phieuCanSua.DonGiaThung = donGiaThungMoi;
                        Console.WriteLine("      Đơn giá thùng đã được cập nhật.");
                        break;
                    case 3:
                        Console.Write("      Nhập phí vận chuyển mới: ");
                        double phiVanChuyenMoi = double.Parse(Console.ReadLine());
                        phieuCanSua.PhiVanChuyen = phiVanChuyenMoi;
                        Console.WriteLine("      Phí vận chuyển đã được cập nhật.");
                        break;
                    default:
                        Console.WriteLine("      Lựa chọn không hợp lệ. Không thay đổi.");
                        break;
                }
            }
            else
            {
                Console.WriteLine("      Không tìm thấy điện thoại có mã thùng tương ứng.");
            }
        }
    }
}
