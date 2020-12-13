using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gas.Entites;

namespace Gas.BusinessLayer.Interface
{
    public interface IFHoaDonNhapBLL
    {
        List<HoaDonNhap> XemDSHoaDonNhap();
        void ThemHoaDonNhap(HoaDonNhap HDN);
        void XoaHoaDonNhap(int mahdn);
        void SuaHoaDonNhap(HoaDonNhap HDN);
        HoaDonNhap LayHoaDonNhap(int mahdn);
        List<HoaDonNhap> TimHoaDonNhap(HoaDonNhap HDN);
    }
}
