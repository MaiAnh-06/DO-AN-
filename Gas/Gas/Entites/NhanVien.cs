using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gas.Entites
{
    public class NhanVien
    {
        private int MaNV;
        private string TenNV;
        private string NgaySinh;
        private string GioiTinh;
        private string NgayVaoLV;

        public NhanVien()
        {
            MaNV = 0;
            TenNV = "";
            NgaySinh = "";
            GioiTinh = "";
            NgayVaoLV = "";

        }
        public NhanVien(int manv, string tennv, string ngaysinh, string gt, string ngayvaolv)
        {
            this.MaNV = manv;
            this.TenNV = tennv;
            this.NgaySinh = ngaysinh;
            this.GioiTinh = gt;
            this.NgayVaoLV = ngayvaolv;

        }
        public NhanVien(NhanVien nv)
        {
            this.MaNV = nv.MaNV;
            this.TenNV = nv.TenNV;
            this.NgaySinh = nv.NgaySinh;
            this.GioiTinh = nv.GioiTinh;
            this.NgayVaoLV = nv.NgayVaoLV;

        }
        public int manv
        {
            get
            {
                return MaNV;
            }
            set
            {
                if (value > 0)
                    MaNV = value;
            }
        }
        public string tennv
        {
            get
            {
                return TenNV;
            }
            set
            {
                if (value != "")
                    TenNV = value;
            }
        }
        public string ngaysinh
        {
            get
            {
                return NgaySinh;
            }
            set
            {
                if (value != "")
                    NgaySinh = value;
            }
        }
        public string gt
        {
            get
            {
                return GioiTinh;
            }
            set
            {
                if (value.ToLower() == "nam" || value.ToLower() == "nữ")
                    GioiTinh = value;
            }
        }
        public string ngayvaolam
        {
            get
            {
                return NgayVaoLV;
            }
            set
            {
                if (value != "")
                    NgayVaoLV = value;
            }
        }
    }
}
