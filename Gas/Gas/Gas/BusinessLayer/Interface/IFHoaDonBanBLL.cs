using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gas.Entites;


namespace Gas.BusinessLayer
{
    public interface IFHoaDonBanBLL
    {
        List<HoaDonBan> XemDSHoaDonBan();
        void ThemHoaDonBan(HoaDonBan HDB);
        void XoaHoaDonBan(int mahdb);
        void SuaHoaDonBan(HoaDonBan HDB);
        HoaDonBan LayHoaDonBan(int mahdb);
        List<HoaDonBan> TimHoaDonBan(HoaDonBan HDB);
    }
}
