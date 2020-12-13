using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gas.Entites;

namespace Gas.DataAccessLayer.Interface
{
    public interface IDHoaDonNhapDAL
    {
        List<HoaDonNhap> GetData();
        void Insert(HoaDonNhap hdn);
        void Update(List<HoaDonNhap> list);
    }
}
