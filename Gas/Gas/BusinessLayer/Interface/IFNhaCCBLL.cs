using GAS.Entites;
using System.Collections.Generic;

namespace GAS.BusinessLayer.Interface
{
    public interface IFNhaCCBLL
    {
        List<NCC> XemDSNhaCC();
        void ThemNhaCC(NCC nc);
        void XoaNhaCC(int manc);
        void SuaNhaCC(NCC nc);
        NCC LayNCC(int mancc);
        List<NCC> TimNhaCC(NCC nc);
    }

}
