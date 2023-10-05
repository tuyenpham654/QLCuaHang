using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyCuaHang
{
    class DienThoai : PhieuHang
    {
        private int maThung;
        private double donGiaThung;
        private double phiVanChuyen;
        public int MaThung { get => maThung; set => maThung = value; }
        public double DonGiaThung { get => donGiaThung; set => donGiaThung = value; }
        public double PhiVanChuyen { get => phiVanChuyen; set => phiVanChuyen = value; }

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
        public override void TimKiem()
        {
            base.TimKiem();
            Console.WriteLine($"Mã thùng: {MaThung}");
            Console.WriteLine($"Đơn giá thùng: {DonGiaThung}");
            Console.WriteLine($"Phí vận chuyển: {PhiVanChuyen}");
            Console.WriteLine($"Tổng tiền: {TinhTong()}");
            Console.ReadKey();
        }
        public override string getAll()
        {
            return $"{base.toString()} {MaThung,-10} | {DonGiaThung,-10} | {PhiVanChuyen,-10} | {TinhTong(),-10}|";
        }
        public override string toString()
        {
            return $"{base.toString()}{TinhTong(),-10}|";
            // return$"{ base.toString()} {MaThung,-10} | {DonGiaThung,-10} | {PhiVanChuyen,-10} | {TinhTong(),-10}|";

            /*     Console.WriteLine($"Mã thùng: {base.toString()}");
                 Console.WriteLine($"Mã thùng: {MaThung}");
                 Console.WriteLine($"Đơn giá thùng: {DonGiaThung}");
                 Console.WriteLine($"Phí vận chuyển: {PhiVanChuyen}");
                 Console.WriteLine($"Tổng tiền: {TinhTong()}");*/
        }
    }
}
