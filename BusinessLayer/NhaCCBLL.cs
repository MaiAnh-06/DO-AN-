using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GAS.Entites;
using GAS.DataAccessLayer;
using GAS.BusinessLayer.Interface;


namespace GAS.BusinessLayer
{
    //Thực thi các yêu cầu nghiệm vụ 
    public class NhaCCBLL : IFNhaCCBLL
    {
        private IDNhaCCDAL NCCDA = new NhaCCDAL();
        //Thực thi các yêu cầu
        public List<NCC> XemDSNhaCC()
        {
            return NCCDA.GetData();
        }
        public void ThemNhaCC(NCC nc)
        {
            if (nc.tenncc != "" && nc.diachi != "")
            {
                NCCDA.Insert(nc);
            }
            else
                throw new Exception("Du lieu sai!");
        }

        public void XoaNhaCC(int mancc)
        {
            int i;
            List<NCC> list = NCCDA.GetData();
            for (i = 0; i < list.Count; ++i)
                if (list[i].mancc == mancc)
                    break;
            if (i < list.Count)
            {
                list.RemoveAt(i);
                NCCDA.Update(list);
            }
            else
                throw new Exception("Không tồn tại mã này!");
        }
        public void SuaNhaCC(NCC nc)
        {
            int i;
            List<NCC> list = NCCDA.GetData();
            for (i = 0; i < list.Count; ++i)
                if (list[i].mancc == nc.mancc)
                    break;
            if (i < list.Count)
            {
                list.RemoveAt(i);

                NCCDA.Update(list);
            }
            else
                throw new Exception("Không tồn tại mã này!");
        }
        public NCC LayNCC(int mancc)
        {
            int i;
            List<NCC> list = NCCDA.GetData();
            for (i = 0; i < list.Count; ++i)
                if (list[i].mancc == mancc) break;
            if (i < list.Count)
            {
                return list[i];
            }
            else
                throw new Exception("Khong ton tai ma nay");

        }
        public List<NCC> TimNhaCC(NCC nc)
        {
            List<NCC> list = NCCDA.GetData();
            List<NCC> MH = new List<NCC>();
            if ((nc.mancc) == 0 && string.IsNullOrEmpty(nc.tenncc) && string.IsNullOrEmpty(nc.diachi) && string.IsNullOrEmpty(nc.sdt) )
            {
                MH = list;
            }
            if ((nc.mancc) == 0)
            {
                for (int i = 0; i < list.Count; i++)
                {
                    if (list[i].mancc == (nc.mancc))

                        MH.Add(new NCC(list[i]));
                }
            }

            else if (!string.IsNullOrEmpty(nc.tenncc))
            {
                for (int i = 0; i < list.Count; i++)
                {
                    if (list[i].tenncc.IndexOf(nc.tenncc) >= 0)
                    {
                        MH.Add(new NCC(list[i]));
                    }
                }
            }
            else if (!string.IsNullOrEmpty(nc.sdt))
            {
                for (int i = 0; i < list.Count; i++)
                {
                    if (list[i].tenncc.IndexOf(nc.sdt) >= 0)
                    {
                        MH.Add(new NCC(list[i]));
                    }
                }
            }
            return MH;
        }
    }
}

       
      
  



