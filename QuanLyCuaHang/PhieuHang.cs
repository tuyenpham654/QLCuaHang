using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test1
{
     abstract class PhieuHang
    {
        public int MaPhieu { get; set; }
        public DateTime NgayNhapHang { get; set; }
        public string TenNhaCungCap { get; set; }
        public int LoaiHang { get; set; }
        public int SoLuong { get; set; }
        public string TenSP { get; set; }
        public string MoTa { get; set; }

        public PhieuHang(int maPhieu, DateTime ngayNhapHang, string tenNhaCungCap, int loaiHang, int soLuong, string tenSP, string moTa)
        {
            MaPhieu = maPhieu;
            NgayNhapHang = ngayNhapHang;
            TenNhaCungCap = tenNhaCungCap;
            LoaiHang = loaiHang;
            SoLuong = soLuong;
            TenSP = tenSP;
            MoTa = moTa;
        }

        public abstract double TinhTong();
   

        public virtual string toString()
        {
          
            return ($"| {MaPhieu} | {NgayNhapHang} | {TenNhaCungCap} |{LoaiHang} |{SoLuong}| {TenSP} | {MoTa}| {TinhTong()}|");

            /*
                        Console.WriteLine($"Mã phiếu: {MaPhieu}");
                        Console.WriteLine($"Ngày nhập hàng: {NgayNhapHang}");
                        Console.WriteLine($"Tên nhà cung cấp: {TenNhaCungCap}");
                        Console.WriteLine($"Loại hàng: {LoaiHang}");
                        Console.WriteLine($"Số lượng: {SoLuong}");
                        Console.WriteLine($"Tên sản phẩm: {TenSP}");
                        Console.WriteLine($"Mô tả cấu hình: {MoTa}");*/
        }
    }

}
