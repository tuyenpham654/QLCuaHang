﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyCuaHang
{
    class LapTop : PhieuHang
    {
        private string soSeri;
        private double giaVonNhapHang;
        private double tyGiaThue;

        public string SoSeri { get => soSeri; set => soSeri = value; }
        public double GiaVonNhapHang { get => giaVonNhapHang; set => giaVonNhapHang = value; }
        public double TyGiaThue { get => tyGiaThue; set => tyGiaThue = value; }

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
            Console.WriteLine($"      Số seri          : {SoSeri}\n");
            Console.WriteLine($"      Giá vốn nhập hàng: {GiaVonNhapHang}\n");
            Console.WriteLine($"      Tỷ giá thuế      : {TyGiaThue}\n");
            Console.WriteLine($"      Tổng tiền        : {TinhTong()}\n");
            Console.ReadKey();

        }
        public override string getAll()
        {
            return $"{base.getAll()} {SoSeri,-10} | {GiaVonNhapHang,-10} | {TyGiaThue,-10} | {TinhTong(),-10}|";
        }
        public override string toString()
        {
            return $"{base.toString()} {TinhTong(),-15}|";
          //  return $"{base.toString()} {SoSeri,-10} | {GiaVonNhapHang,-10} | {TyGiaThue,-10} | {TinhTong(),-10}|";
          /*  base.InThongTin();
            Console.WriteLine($"Số seri: {SoSeri}");
            Console.WriteLine($"Giá vốn nhập hàng: {GiaVonNhapHang}");
            Console.WriteLine($"Tỷ giá thuế: {TyGiaThue}");
            Console.WriteLine($"Tổng tiền: {TinhTong()}");*/
        }
    }
}
