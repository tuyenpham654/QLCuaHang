using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test1
{
    class DienThoai : PhieuHang
    {
        public int MaThung { get; set; }
        public double DonGiaThung { get; set; }
        public double PhiVanChuyen { get; set; }

        public DienThoai(int maPhieu, DateTime ngayNhapHang, string tenNhaCungCap, int loaiHang, int soLuong, string tenSP, string moTa, int maThung, double donGiaThung, double phiVanChuyen)
            : base(maPhieu, ngayNhapHang, tenNhaCungCap, loaiHang, soLuong, tenSP, moTa)
        {
            MaThung = maThung;
            DonGiaThung = donGiaThung;
            PhiVanChuyen = phiVanChuyen;
        }

        public override double TinhTong()
        {
            return (SoLuong * DonGiaThung) + PhiVanChuyen;
        }

        public override string toString()
        {
            return$"{ base.toString()} {MaThung} {DonGiaThung} {PhiVanChuyen} {TinhTong()}";
            
       /*     Console.WriteLine($"Mã thùng: {base.toString()}");
            Console.WriteLine($"Mã thùng: {MaThung}");
            Console.WriteLine($"Đơn giá thùng: {DonGiaThung}");
            Console.WriteLine($"Phí vận chuyển: {PhiVanChuyen}");
            Console.WriteLine($"Tổng tiền: {TinhTong()}");*/
        }
    }
}
