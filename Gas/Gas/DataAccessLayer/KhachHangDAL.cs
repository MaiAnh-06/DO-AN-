using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Gas.Entites;

namespace Gas.DataAccessLayer
{
   public class KhachhangDAL :IDKhacHangDAL
    {
        //Xác định đường dẫn của tệp dữ liệu khachhang.txt
        private string txtfile7 = "Data/KHACHHANG.txt";
        //Lấy toàn bộ dữ liệu có trong file Khachhang.txt đưa vào một danh sách 
        public List<Khachhang> GetData()
        {
            List<Khachhang> list = new List<Khachhang>();
            StreamReader fread7 = File.OpenText(txtfile7);
            string s = fread7.ReadLine();
            while (s != null)
            {
                if (s != "")
                {

                    string[] a = s.Split('\t');
                    list.Add(new Khachhang((a[0]), a[1], (a[2]), (a[3])));

                }
                s = fread7.ReadLine();

            }
            fread7.Close();
            return list;
        }

        //Chèn một bản ghi nhân viên vào tệp
        public void Insert(Khachhang kh)
        {

            StreamWriter fwrite = File.AppendText(txtfile7);
            fwrite.WriteLine();
            fwrite.Write(kh.Makhach + "\t" + kh.Tenkhach + "\t" + kh.Quequan + "\t" + kh.Sodienthoai);
            fwrite.Close();
        }
        //Cập nhật lại danh sách vào tệp
        public void Update(List<Khachhang> list)
        {
            StreamWriter fwrite = File.CreateText(txtfile7);
            for (int i = 0; i < list.Count; ++i)
                fwrite.WriteLine(list[i].Makhach + "\t" + list[i].Tenkhach + "\t" + list[i].Quequan+ "\t" + list[i].Sodienthoai);
            fwrite.Close();
        }

    }
}
