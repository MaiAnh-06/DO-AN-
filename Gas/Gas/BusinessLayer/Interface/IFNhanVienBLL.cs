using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gas.Entites;

namespace Gas.BusinessLayer
{
    public interface IFNhanVienBLL
    {
        List<NhanVien> XemDSNhanVien();
        void ThemNhanVien(NhanVien NV);
        void XoaNhanVien(int manv);
        void SuaNhanVien(NhanVien nv);
        NhanVien LayNhanVien(int manv);
        List<NhanVien> TimNhanVien(NhanVien nv);
    }
}
