using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gas.Entites;

namespace Gas.DataAccessLayer
{
    public interface IDKhacHangDAL
    {
        List<Khachhang> GetData();
        void Insert(Khachhang kh);
        void Update(List<Khachhang> list);
    }
}
