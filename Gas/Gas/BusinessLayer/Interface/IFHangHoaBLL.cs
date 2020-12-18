using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GAS.Entites;

namespace GAS.BusinessLayer
{
    public interface IFHangHoaBLL
    {
        List<HangHoa> XemDSHangHoa();
        void ThemHangHoa(HangHoa HH);
        void XoaHangHoa(int mahh);
        void SuaHangHoa(HangHoa HH);
        HangHoa LayHangHoa(int mahh);
        List<HangHoa> TimHangHoa(HangHoa HH);
    }
}

