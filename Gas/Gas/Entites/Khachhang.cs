using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gas.Entites
{
    public class Khachhang
    {

        private string makhach;
        private string tenkhach;
        private string quequan;
        private string sodienthoai;


        public string Makhach
        {
            get { return makhach; }
            set
            {
                if (!string.IsNullOrEmpty(value))
                    makhach = value;
            }
        }
        public string Tenkhach
        {
            get { return tenkhach; }
            set
            {
                if (!string.IsNullOrEmpty(value))
                    tenkhach = value;
            }
        }
        public string Quequan
        {
            get { return quequan; }
            set
            {
                if (!string.IsNullOrEmpty(value))
                    quequan = value;
            }
        }

        public string Sodienthoai
        {
            get { return sodienthoai; }
            set
            {
                if (!string.IsNullOrEmpty(value) && value.Length == 10)
                    sodienthoai = value;
            }
        }

        public Khachhang() { }
        //Phương thức thiết lập sao chép
        public Khachhang(Khachhang kh)
        {
            this.makhach = kh.makhach;
            this.tenkhach = kh.tenkhach;
            this.quequan = kh.quequan;
            this.sodienthoai = kh.sodienthoai;
        }
        public Khachhang(string makhach, string tenkhach, string quequan, string sodienthoai)
        {
            this.makhach = makhach;
            this.tenkhach = tenkhach;
            this.quequan = quequan;
            this.sodienthoai = sodienthoai;
        }
    }
}
