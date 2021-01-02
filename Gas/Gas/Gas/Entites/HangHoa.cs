using System;
using System.Collections.Generic;
using System.Text;

namespace GAS.Entites
{
    public class HangHoa
    {
        private int MaHH;
        private string TenHang;
        private int SLNhapVe;
        private int SLHienCo;

        public HangHoa()
        {
            MaHH = 0;
            TenHang = "";
            SLNhapVe = 0;
            SLHienCo = 0;

        }
        public HangHoa(int mahh, string tenhang, int slnhap, int slhienco)
        {
            this.MaHH = mahh;
            this.TenHang = tenhang;
            this.SLNhapVe = slnhap;
            this.SLHienCo = slhienco;

        }
        public HangHoa(HangHoa hh)
        {
            this.MaHH = hh.mahh;
            this.TenHang = hh.tenhang;
            this.SLNhapVe = hh.slnhapve;
            this.SLHienCo = hh.slhienco;

        }
        public int mahh
        {
            get
            {
                return MaHH;
            }
            set
            {
                if (value > 0)
                    MaHH = value;
            }
        }
        public string tenhang
        {
            get
            {
                return TenHang;
            }
            set
            {
                if (value != "")
                    TenHang = value;
            }
        }
        public int slnhapve
        {
            get
            {
                return SLNhapVe;
            }
            set
            {
                if (value > 0)
                    SLNhapVe = value;
            }
        }
        public int slhienco
        {
            get
            {
                return SLHienCo;
            }
            set
            {
                if (value > 0)
                    SLHienCo = value;
            }
        }

    }
}
