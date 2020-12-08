using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using GAS.Entites;



namespace GAS.DataAccessLayer
{
    class HangHoaDAL : IDHangHoaDAL
    {
        //Xác định đường dẫn của tệp dữ liệu HANGHOA.txt
        private string txtfile1 = "Data/HANGHOA.txt";
        //Lấy toàn bộ dữ liệu có trong file HANGHOA.txt đưa vào một danh sách
        public List<HangHoa> GetData()
        {
            List<HangHoa> list = new List<HangHoa>();
            StreamReader fread1 = File.OpenText(txtfile1);
            string s = fread1.ReadLine();
            while (s != null)
            {
                if (s != "")
                {

                    string[] a = s.Split('\t');
                    list.Add(new HangHoa(int.Parse(a[0]), a[1], int.Parse(a[2]), int.Parse(a[3])));

                }
                s = fread1.ReadLine();

            }
            fread1.Close();
            return list;
        }

        //Chèn một bản ghi nhân viên vào tệp
        public void Insert(HangHoa HH)
        {
            int mah = HH.mahh + 1;
            StreamWriter fwrite = File.AppendText(txtfile1);
            fwrite.WriteLine();
            fwrite.Write(mah + "\t" + HH.tenhang + "\t" + HH.slnhapve + "\t" + HH.slhienco);
            fwrite.Close();
        }
        //Cập nhật lại danh sách vào tệp
        public void Update(List<HangHoa> list)
        {
            StreamWriter fwrite = File.CreateText(txtfile1);
            for (int i = 0; i < list.Count; ++i)
                fwrite.WriteLine(list[i].mahh + "\t" + list[i].tenhang + "\t" + list[i].slnhapve + "\t" + list[i].slhienco);
            fwrite.Close();
        }
    }
}


