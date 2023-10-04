﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyCuaHang
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

        public override void TimKiem(){
            base.TimKiem();
            Console.WriteLine($"Số seri: {SoSeri}");
            Console.WriteLine($"Giá vốn nhập hàng: {GiaVonNhapHang}");
            Console.WriteLine($"Tỷ giá thuế: {TyGiaThue}");
            Console.WriteLine($"Tổng tiền: {TinhTong()}");
            Console.ReadKey();

        }
        public override string toString()
        {
            return $"{base.toString()} {SoSeri,-10} {GiaVonNhapHang,-10} {TyGiaThue,-10} {TinhTong(),-10}";
          /*  base.InThongTin();
            Console.WriteLine($"Số seri: {SoSeri}");
            Console.WriteLine($"Giá vốn nhập hàng: {GiaVonNhapHang}");
            Console.WriteLine($"Tỷ giá thuế: {TyGiaThue}");
            Console.WriteLine($"Tổng tiền: {TinhTong()}");*/
        }
    }
}