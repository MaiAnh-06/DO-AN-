using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gas.Entites;

namespace Gas.DataAccessLayer
{
    public interface IDHoaDonBanDAL
    {
        List<HoaDonBan> GetData();
        void Insert(HoaDonBan hdb);
        void Update(List<HoaDonBan> list);
    }
}
