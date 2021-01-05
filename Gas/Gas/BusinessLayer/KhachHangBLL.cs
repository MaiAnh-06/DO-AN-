using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gas.Entites;
using Gas.DataAccessLayer;

namespace Gas.BusinessLayer
{
    public class KhachHangBLL : IFKhachHangBLL
    {
        private IDKhacHangDAL HHDA = new KhachhangDAL();
        //Thực thi các yêu cầu
        public List<Khachhang> XemDSKhachHang()
        {
            return HHDA.GetData();
        }
        public void ThemKH(Khachhang HH)
        {
            if (HH.Tenkhach != "")
            {

                HHDA.Insert(HH);
            }
            else
                throw new Exception("Du lieu sai!");
        }


        public void XoaKH(string makhach)
        {
            int i;
            List<Khachhang> list = HHDA.GetData();
            for (i = 0; i < list.Count; ++i)
                if (list[i].Makhach== makhach)
                    break;
            if (i < list.Count)
            {
                list.RemoveAt(i);
                HHDA.Update(list);
            }
            else
                throw new Exception("Không tồn tại mã này!");
        }
        public void SuaKH(Khachhang HH)
        {
            int i;
            List<Khachhang> list = HHDA.GetData();
            for (i = 0; i < list.Count; ++i)
                if (list[i].Makhach == HH.Makhach)
                    break;
            if (i < list.Count)
            {
                list.RemoveAt(i);
                list.Add(HH);
                HHDA.Update(list);
            }
            else
                throw new Exception("Không tồn tại mã này!");
        }
        
        public List<Khachhang> TimKH(Khachhang HH)
        {
            List<Khachhang> list = HHDA.GetData();
            List<Khachhang> MH = new List<Khachhang>();

            if (string.IsNullOrEmpty(HH.Makhach)&& string.IsNullOrEmpty(HH.Tenkhach) && string.IsNullOrEmpty(HH.Quequan) && string.IsNullOrEmpty(HH.Sodienthoai))
            {
                MH = list;
            }
            if (!string.IsNullOrEmpty(HH.Makhach))
            {
                for (int i = 0; i < list.Count; i++)
                {
                    if (list[i].Makhach == (HH.Makhach))

                        MH.Add(new Khachhang(list[i]));
                }
            }

            else if (!string.IsNullOrEmpty(HH.Tenkhach))
            {
                for (int i = 0; i < list.Count; i++)
                {
                    if (list[i].Tenkhach.IndexOf(HH.Tenkhach) >= 0)
                    {
                        MH.Add(new Khachhang(list[i]));
                    }
                }
            }
            return MH;
        }
    }
}
