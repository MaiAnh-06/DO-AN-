using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gas.Entites;
using Gas.DataAccessLayer.Interface;
using System.IO;

namespace Gas.DataAccessLayer
{
    class NhanVienDAL : IDNhanVienDAL
    {
        //Xác định đường dẫn của tệp dữ liệu NHANVIEN.txt
        private string txtfile3 = "Data/NHANVIEN.txt";
        //Lấy toàn bộ dữ liệu có trong file NHANVIEN.txt đưa vào một danh sách
        public List<NhanVien> GetData()
        {
            List<NhanVien> list = new List<NhanVien>();
            StreamReader fread3 = File.OpenText(txtfile3);
            string s = fread3.ReadLine();
            while (s != null)
            {
                if (s != "")
                {
                    
                    string[] a = s.Split('\t');
                    list.Add(new NhanVien(int.Parse(a[0]), a[1], a[2], a[3], a[4]));

                }
                s = fread3.ReadLine();

            }
            fread3.Close();
            return list;
        }
       
        //Chèn một bản ghi nhân viên vào tệp
        public void Insert(NhanVien NV)
        {
            int mav = NV.manv + 1;
            StreamWriter fwrite = File.AppendText(txtfile3);
            fwrite.WriteLine();
            fwrite.Write(NV.manv+ "\t" + NV.tennv + "\t" + NV.ngaysinh + "\t" + NV.gt + "\t" + NV.ngayvaolam + "\t" );
            fwrite.Close();
        }
        //Cập nhật lại danh sách vào tệp
        public void Update(List<NhanVien> list)
        {
            StreamWriter fwrite = File.CreateText(txtfile3);
            for (int i = 0; i < list.Count; ++i)
                fwrite.WriteLine(list[i].manv + "\t" + list[i].tennv + "\t" + list[i].ngaysinh + "\t" + list[i].gt + "\t" + list[i].ngayvaolam + "\t");
            fwrite.Close();
        }
    }
}


