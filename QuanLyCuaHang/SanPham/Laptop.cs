using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace QuanLyCuaHang.SanPham
{
    class Laptop : Product
    {
        private int serial_id;
        private string storage;
        private string graphicsCard;

        public int Serial_id { get => serial_id; set => serial_id = value; }
        public string Storage { get => storage; set => storage = value; }
        public string GraphicsCard { get => graphicsCard; set => graphicsCard = value; }

        public Laptop(int product_id, string name, string description, double price, int serial_id, string storage, string graphicsCard) : base(product_id, name, description, price)
        {
            this.Serial_id = serial_id;
            this.Storage = storage;
            this.GraphicsCard = graphicsCard;
        }
        public string toString()
        {
            return $"{Serial_id} | {Storage} | {GraphicsCard} | {base.toString()}";
        }
    }
}
