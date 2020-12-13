using System;
using System.Collections.Generic;
using Gas.Entites;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gas.DataAccessLayer;
using Gas.BusinessLayer;

namespace Gas.BusinessLayer
{
    //Thực thi các yêu cầu nghiệm vụ 
    public class NhanVienBLL : IFNhanVienBLL
    {
        private IDNhanVienDAL NVDA = new NhanVienDAL();
        //Thực thi các yêu cầu
        public List<NhanVien> XemDSNhanVien()
        {
            return NVDA.GetData();
        }
        public void ThemNhanVien(NhanVien NV)
        {
            if (NV.tennv != ""  )
            {
                
                NVDA.Insert(NV);
            }
            else
                throw new Exception("Du lieu sai!");
        }
        
        public void XoaNhanVien(int manv)
        {
            int i;
            List<NhanVien> list = NVDA.GetData();
            for (i = 0; i < list.Count; ++i)
                if (list[i].manv == manv)
                    break;
            if (i < list.Count)
            {
                list.RemoveAt(i);
                NVDA.Update(list);
            }
            else
                throw new Exception("Không tồn tại mã này!");
        }
        public void SuaNhanVien(NhanVien nv)
        {
            int i;
            List<NhanVien> list = NVDA.GetData();
            for (i = 0; i < list.Count; ++i)
                if (list[i].manv == nv.manv)
                    break;
            if (i < list.Count)
            {
                list.RemoveAt(i);
                NVDA.Update(list);
            }
            else
                throw new Exception("Không tồn tại mã này!");
        }
        public NhanVien LayNhanVien(int manv)
        {
            int i;
            List<NhanVien> list = NVDA.GetData();
            for (i = 0; i < list.Count; ++i)
                if (list[i].manv == manv) break;
            if (i < list.Count)
            {
                return list[i];
            }
            else
                throw new Exception("Khong ton tai ma nay");

        }
        public List<NhanVien> TimNhanVien(NhanVien nv)
        {
            List<NhanVien> list = NVDA.GetData();
            List<NhanVien> MH = new List<NhanVien>();
            if ((nv.manv)==0 && string.IsNullOrEmpty(nv.tennv) && string.IsNullOrEmpty(nv.ngaysinh)&& string.IsNullOrEmpty(nv.gt)&& string.IsNullOrEmpty(nv.ngayvaolam))
            {
                MH = list;
            }
            if ((nv.manv)==0)
            {
                for (int i = 0; i < list.Count; i++)
                {
                    if (list[i].manv==(nv.manv) )

                        MH.Add(new NhanVien(list[i]));
                }
            }

            else if (!string.IsNullOrEmpty(nv.tennv))
            {
                for (int i = 0; i < list.Count; i++)
                {
                    if (list[i].tennv.IndexOf(nv.tennv) >= 0)
                    {
                        MH.Add(new NhanVien(list[i]));
                    }
                }
            }
            else if (!string.IsNullOrEmpty(nv.ngayvaolam))
            {
                for (int i = 0; i < list.Count; i++)
                {
                    if (list[i].tennv.IndexOf(nv.ngayvaolam) >= 0)
                    {
                        MH.Add(new NhanVien(list[i]));
                    }
                }
            }
            return MH;
        }
    }
}
