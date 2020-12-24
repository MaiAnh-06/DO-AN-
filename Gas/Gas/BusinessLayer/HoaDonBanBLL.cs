using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gas.Entites;
using Gas.DataAccessLayer.Interface;
using Gas.BusinessLayer.Interface;
using Gas.DataAccessLayer;


namespace Gas.BusinessLayer
{
    //Thực thi các yêu cầu nghiệm vụ 
    public class HoaDonBanBLL : IFHoaDonBanBLL
    {
        private IDHoaDonBanDAL HDBDA = new HoaDonBanDAL();
        //Thực thi các yêu cầu
        public List<HoaDonBan> XemDSHoaDonBan()
        {
            return HDBDA.GetData();
        }
        public void ThemHoaDonBan(HoaDonBan HDB)
        {
            if (HDB.kh != "")
            {
                HDBDA.Insert(HDB);
            }
            else
                throw new Exception("Du lieu sai!");
        }
        
        public void XoaHoaDonBan(int mahdb)
        {
            int i;
            List<HoaDonBan> list = HDBDA.GetData();
            for (i = 0; i < list.Count; ++i)
                if (list[i].mahdb == mahdb)
                    break;
            if (i < list.Count)
            {
                list.RemoveAt(i);
                HDBDA.Update(list);
            }
            else
                throw new Exception("Không tồn tại mã này!");
        }
        public void SuaHoaDonBan(HoaDonBan HDB)
        {
            int i;
            List<HoaDonBan> list = HDBDA.GetData();
            for (i = 0; i < list.Count; ++i)
                if (list[i].mahdb == HDB.mahdb)
                    break;
            if (i < list.Count)
            {
                list.RemoveAt(i);
                list.Add(HDB);
                HDBDA.Update(list);
            }
            else
                throw new Exception("Không tồn tại mã này!");
        }
        public HoaDonBan LayHoaDonBan(int mahdb)
        {
            int i;
            List<HoaDonBan> list = HDBDA.GetData();
            for (i = 0; i < list.Count; ++i)
                if (list[i].mahdb == mahdb) break;
            if (i < list.Count)
            {
                return list[i];
            }
            else
                throw new Exception("Khong ton tai ma nay");

        }
        public List<HoaDonBan> TimHoaDonBan(HoaDonBan HDB)
        {
            List<HoaDonBan> list = HDBDA.GetData();
            List<HoaDonBan> KQ = new List<HoaDonBan>();
            
            //Tìm theo mã
            if (HDB.mahdb != 0)
            {
                for (int i = 0; i < list.Count; ++i)
                    if (list[i].mahdb == HDB.mahdb)
                    {
                        KQ.Add(new HoaDonBan(list[i]));
                    }
            }
            else KQ = null;
            return KQ;
        }
    }
}
