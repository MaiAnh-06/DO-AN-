using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GAS.Entites;
using GAS.DataAccessLayer;


namespace GAS.BusinessLayer
{
    //Thực thi các yêu cầu nghiệm vụ 
    public class HangHoaBLL : IFHangHoaBLL
    {
        private IDHangHoaDAL HHDA = new HangHoaDAL();
        //Thực thi các yêu cầu
        public List<HangHoa> XemDSHangHoa()
        {
            return HHDA.GetData();
        }
        public void ThemHangHoa(HangHoa HH)
        {
            if (HH.tenhang != "")
            {

                HHDA.Insert(HH);
            }
            else
                throw new Exception("Du lieu sai!");
        }

        //public bool KiemTra(int mahh)
        //{
        //    List<HangHoa> list = HHDA.GetData();
        //    Node<HangHoa> NB = ;
        //    bool kt = false;
        //    while (NB != null)
        //    {
        //        if (NB.Info.mahh == mahh)
        //        {
        //            kt = true;
        //            break;
        //        }
        //        else
        //            NB = NB.Link;
        //    }
        //    return kt;
        //}
        //public bool KiemTraTen(string tenhh)
        //{
        //    List<HangHoa> list = HHDA.GetData();
        //    Node<HangHoa> NB = list.L;
        //    bool kt = false;
        //    while (NB != null)
        //    {
        //        if (NB.Info.tenhang == tenhh)
        //        {
        //            kt = true;
        //            break;
        //        }
        //        else
        //            NB = NB.Link;
        //    }
        //    return kt;
        //}
        public void XoaHangHoa(int mahh)
        {
            int i;
            List<HangHoa> list = HHDA.GetData();
            for (i = 0; i < list.Count; ++i)
                if (list[i].mahh == mahh)
                    break;
            if (i < list.Count)
            {
                list.RemoveAt(i);
                HHDA.Update(list);
            }
            else
                throw new Exception("Không tồn tại mã này!");
        }
        public void SuaHangHoa(HangHoa HH)
        {
            int i;
            List<HangHoa> list = HHDA.GetData();
            for (i = 0; i < list.Count; ++i)
                if (list[i].mahh == HH.mahh)
                    break;
            if (i < list.Count)
            {
                list.RemoveAt(i);
                HHDA.Insert(HH);
                HHDA.Update(list);
            }
            else
                throw new Exception("Không tồn tại mã này!");
        }
        public HangHoa LayHangHoa(int mahh)
        {
            int i;
            List<HangHoa> list = HHDA.GetData();
            for (i = 0; i < list.Count; ++i)
                if (list[i].mahh == mahh) break;
            if (i < list.Count)
            {
                return list[i];
            }
            else
                throw new Exception("Không tồn tại mã này!");

        }
        public List<HangHoa> TimHangHoa(HangHoa HH)
        {
            List<HangHoa> list = HHDA.GetData();
            List<HangHoa> KQ = new List<HangHoa>();

            //Tìm theo mã
            if (HH.mahh != 0 && HH.tenhang == null)
            {
                for (int i = 0; i < list.Count; ++i)
                    if (list[i].mahh == HH.mahh)
                    {
                        KQ.Add(new HangHoa(list[i]));
                    }
            }
            else if (HH.mahh == 0 && HH.tenhang != null)
            {
                for (int i = 0; i < list.Count; i++)
                {
                    if (list[i].tenhang == HH.tenhang)
                    {
                        KQ.Add(new HangHoa(list[i]));
                    }
                }
            }
            else KQ = null;
            return KQ;
        }
    }

}
