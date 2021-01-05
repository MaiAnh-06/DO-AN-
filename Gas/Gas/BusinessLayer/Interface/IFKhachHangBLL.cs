using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gas.Entites;

namespace Gas.BusinessLayer
{
   public interface IFKhachHangBLL
    {
        List<Khachhang> XemDSKhachHang();
        void ThemKH(Khachhang HH);
        void XoaKH(string makhach);
        void SuaKH(Khachhang HH);
        List<Khachhang> TimKH(Khachhang HH);
    }
}
