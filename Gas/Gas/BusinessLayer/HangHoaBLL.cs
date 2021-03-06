﻿using System;
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
                list.Add(HH);
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
            List<HangHoa> MH = new List<HangHoa>();

            if ((HH.mahh) == 0 && string.IsNullOrEmpty(HH.tenhang) && (HH.slhienco)==0 &&(HH.slnhapve)==0 )
            {
                MH = list;
            }
            if ((HH.mahh) == 0)
            {
                for (int i = 0; i < list.Count; i++)
                {
                    if (list[i].mahh == (HH.mahh))

                        MH.Add(new HangHoa(list[i]));
                }
            }

            else if (!string.IsNullOrEmpty(HH.tenhang))
            {
                for (int i = 0; i < list.Count; i++)
                {
                    if (list[i].tenhang.IndexOf(HH.tenhang) >= 0)
                    {
                        MH.Add(new HangHoa(list[i]));
                    }
                }
            }
            return MH;
        }
    }

}
