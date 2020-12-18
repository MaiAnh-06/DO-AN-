using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gas.Entites
{
    public class HoaDonNhap
    {
        private int MaHDN;
        private int MaNCC;
        private string NVGiao;
        private int MaNVNhan;
        private string NgayNhan;
        private int MaHang;
        private int SoLuong;
        private double DonGiaNhap;
        private double ThanhTien;
        public HoaDonNhap()
        {
            MaHDN = 0;
            MaNCC = 0;
            NVGiao = "";
            MaNVNhan = 0;
            NgayNhan = "";
            MaHang = 0;
            SoLuong = 0;
            DonGiaNhap = 0;
            ThanhTien = 0;
        }
        public HoaDonNhap(int mahdn, int mancc, string nvgiao, int manvnhan, string ngaynhan, int mahang, int sl, double gianhap, double thanhtien)
        {
            this.MaHDN = mahdn;
            this.MaNCC = mancc;
            this.NVGiao = nvgiao;
            this.MaNVNhan = manvnhan;
            this.NgayNhan = ngaynhan;
            this.MaHang = mahang;
            this.SoLuong = sl;
            this.DonGiaNhap = gianhap;
            this.ThanhTien = thanhtien;
        }


        public HoaDonNhap(HoaDonNhap hdn)
        {
            this.MaHDN = hdn.MaHDN;
            this.MaNCC = hdn.MaNCC;
            this.NVGiao = hdn.NVGiao;
            this.MaNVNhan = hdn.MaNVNhan;
            this.NgayNhan = hdn.NgayNhan;
            this.MaHang = hdn.MaHang;
            this.SoLuong = hdn.SoLuong;
            this.DonGiaNhap = hdn.DonGiaNhap;
            this.ThanhTien = hdn.ThanhTien;
        }
        public int mahdn
        {
            get
            {
                return MaHDN;
            }
            set
            {
                if (value > 0)
                    MaHDN = value;
            }
        }
        public int mancc
        {
            get
            {
                return MaNCC;
            }
            set
            {
                if (value > 0)
                    MaNCC = value;
            }
        }
        public string nvgiao
        {
            get
            {
                return NVGiao;
            }
            set
            {
                if (value != "")
                    NVGiao = value;
            }
        }
        public int manvnhan
        {
            get
            {
                return MaNVNhan;
            }
            set
            {
                if (value > 0)
                    MaNVNhan = value;
            }
        }
        public string ngaynhan
        {
            get
            {
                return NgayNhan;
            }
            set
            {
                if (value != "")
                    NgayNhan = value;
            }
        }
        public int mahang
        {
            get
            {
                return MaHang;
            }
            set
            {
                if (value > 0)
                    MaHang = value;
            }
        }
        public int soluong
        {
            get
            {
                return SoLuong;
            }
            set
            {
                if (value > 0)
                    SoLuong = value;
            }
        }
        public double gianhap
        {
            get
            {
                return DonGiaNhap;
            }
            set
            {
                if (value > 0)
                    DonGiaNhap = value;
            }
        }
        public double thanhtien
        {
            get
            {
                return soluong * gianhap;
            }
            set
            {
                if (ThanhTien > 0)
                    ThanhTien = value;
            }
        }
    }
}
