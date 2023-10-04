using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test1
{
    class LapTop : PhieuHang
    {
        public string SoSeri { get; set; }
        public double GiaVonNhapHang { get; set; }
        public double TyGiaThue { get; set; }

        public LapTop(int maPhieu, DateTime ngayNhapHang, string tenNhaCungCap, int loaiHang, int soLuong, string tenSP, string moTa, string soSeri, double giaVonNhapHang, double tyGiaThue)
            : base(maPhieu, ngayNhapHang, tenNhaCungCap, loaiHang, soLuong, tenSP, moTa)
        {
            SoSeri = soSeri;
            GiaVonNhapHang = giaVonNhapHang;
            TyGiaThue = tyGiaThue;
        }

        public override double TinhTong()
        {
            return SoLuong * (GiaVonNhapHang + GiaVonNhapHang * TyGiaThue);
        }

        public override string toString()
        {
            return $"{base.toString()} {SoSeri} {GiaVonNhapHang} {TyGiaThue} {TinhTong()}";
          /*  base.InThongTin();
            Console.WriteLine($"Số seri: {SoSeri}");
            Console.WriteLine($"Giá vốn nhập hàng: {GiaVonNhapHang}");
            Console.WriteLine($"Tỷ giá thuế: {TyGiaThue}");
            Console.WriteLine($"Tổng tiền: {TinhTong()}");*/
        }
    }
}
