using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyCuaHang
{
     abstract class PhieuHang
    {
        private int maPhieu;
        private DateTime ngayNhapHang;
        private string tenNhaCungCap;
        private int loaiHang;
        private int soLuong;
        private string tenSP;
        private string moTa;

        public int MaPhieu { get => maPhieu; set => maPhieu = value; }
        public DateTime NgayNhapHang { get => ngayNhapHang; set => ngayNhapHang = value; }
        public int LoaiHang { get => loaiHang; set => loaiHang = value; }
        public int SoLuong { get => soLuong; set => soLuong = value; }
        public string TenSP { get => tenSP; set => tenSP = value; }
        public string MoTa { get => moTa; set => moTa = value; }
        public string TenNhaCungCap { get => tenNhaCungCap; set => tenNhaCungCap = value; }

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

        public virtual void TimKiem()
        {
            Console.WriteLine($"Mã phiếu: {MaPhieu}");
            Console.WriteLine($"Ngày nhập hàng: {NgayNhapHang}");
            Console.WriteLine($"Tên nhà cung cấp: {TenNhaCungCap}");
            Console.WriteLine($"Loại hàng: {LoaiHang}");
            Console.WriteLine($"Số lượng: {SoLuong}");
            Console.WriteLine($"Tên sản phẩm: {TenSP}");
            Console.WriteLine($"Mô tả cấu hình: {MoTa}");
          
        }
        public virtual string getAll()
        {
            return ($"| {MaPhieu,-10} | {NgayNhapHang.ToString("dd-MM-yyyy"),-15} | {TenNhaCungCap,-10} |{LoaiHang,-13} |{SoLuong,-10}| {TenSP,-14} | {MoTa,-10}|");
        }
        public virtual string toString()
        {
            return ($"| {MaPhieu,-10} | {NgayNhapHang.ToString("dd-MM-yyyy"),-15} | {TenNhaCungCap,-10} |{LoaiHang,-13} |{SoLuong,-10}| {TenSP,-14} | {MoTa,-10}|");

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
