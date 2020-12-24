using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gas.Entites;
using Gas.DataAccessLayer.Interface;
using Gas.BusinessLayer.Interface;
using Gas.DataAccessLayer;


namespace GAS.BusinessLayer
{
    //Thực thi các yêu cầu nghiệm vụ 
    public class HoaDonNhapBLL : IFHoaDonNhapBLL
    {
        private IDHoaDonNhapDAL HDNDA = new HoaDonNhapDAL();
        //Thực thi các yêu cầu
        public List<HoaDonNhap> XemDSHoaDonNhap()
        {
            return HDNDA.GetData();
        }
        public void ThemHoaDonNhap(HoaDonNhap HDN)
        {
            if (HDN.nvgiao != "")
            {
                
                HDNDA.Insert(HDN);
            }
            else
                throw new Exception("Du lieu sai!");
        }
        
        public void XoaHoaDonNhap(int mahdn)
        {
            int i;
            List<HoaDonNhap> list = HDNDA.GetData();
            for (i = 0; i < list.Count; ++i)
                if (list[i].mahdn == mahdn)
                    break;
            if (i < list.Count)
            {
                list.RemoveAt(i);
                HDNDA.Update(list);
            }
            else
                throw new Exception("Không tồn tại mã này!");
        }
        public void SuaHoaDonNhap(HoaDonNhap HDN)
        {
            int i;
            List<HoaDonNhap> list = HDNDA.GetData();
            for (i = 0; i < list.Count; ++i)
                if (list[i].mahdn == HDN.mahdn)
                    break;
            if (i < list.Count)
            {
                list.RemoveAt(i);
                list.Add(HDN);
                HDNDA.Update(list);
            }
            else
                throw new Exception("Không tồn tại mã này!");
        }
        public HoaDonNhap LayHoaDonNhap(int mahdn)
        {
            int i;
            List<HoaDonNhap> list = HDNDA.GetData();
            for (i = 0; i < list.Count; ++i)
                if (list[i].mahdn == mahdn) break;
            if (i < list.Count)
            {
                return list[i];
            }
            else
                throw new Exception("Khong ton tai ma nay");

        }
        public List<HoaDonNhap> TimHoaDonNhap(HoaDonNhap HDN)
        {

            List<HoaDonNhap> list = HDNDA.GetData();
            List<HoaDonNhap> KQ = new List<HoaDonNhap>();
            
            //Tìm theo mã
            if (HDN.mahdn != 0)
            {
                for (int i = 0; i < list.Count; ++i)
                    if (list[i].mahdn == HDN.mahdn)
                    {
                        KQ.Add(new HoaDonNhap(list[i]));
                    }
            }
            else KQ = null;
            return KQ;
        }
    
    }

}
