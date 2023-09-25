using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyCuaHang.SanPham
{
    class Mobile:Product
    {
        private int moblie_id;
        private int box_id;
        private string rom;
        private string camera;

        public int Moblie_id { get => moblie_id; set => moblie_id = value; }
        public int Box_id { get => box_id; set => box_id = value; }
        public string Rom { get => rom; set => rom = value; }
        public string Camera { get => camera; set => camera = value; }

        public Mobile(int product_id, string name, string description, double price, int moblie_id, int box_id, string rom, string camera):base(product_id, name, description, price)
        {
            this.Moblie_id = moblie_id;
            this.Box_id = box_id;
            this.Rom = rom;
            this.Camera = camera;
        }
        
        public string toString()
        {
            return $"{Moblie_id} | {Box_id} | {Rom} | {Camera} | {base.toString()}";
        }
    }
}
