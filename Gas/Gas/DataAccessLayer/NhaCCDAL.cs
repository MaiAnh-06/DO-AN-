using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using GAS.Entites;

namespace GAS.DataAccessLayer
{
    class NhaCCDAL : IDNhaCCDAL
    {
        //Xác định đường dẫn của tệp dữ liệu NCC.txt
        private string txtfile2 = "Data/NCC.txt";
        //Lấy toàn bộ dữ liệu có trong file NCC.txt đưa vào một danh sách
        public List<NCC> GetData()
        {
            List<NCC> list = new List<NCC>();
            StreamReader fread2 = File.OpenText(txtfile2);
            string s = fread2.ReadLine();
            while (s != null)
            {
                if (s != "")
                {

                    string[] a = s.Split('\t');
                    list.Add(new NCC(int.Parse(a[0]), a[1], a[2], a[3]));

                }
                s = fread2.ReadLine();

            }
            fread2.Close();
            return list;
        }

        //Chèn một bản ghi nhà cung cấp vào tệp
        public void Insert(NCC nc)
        {
            int manc = nc.mancc + 1;
            StreamWriter fwrite = File.AppendText(txtfile2);
            fwrite.WriteLine();
            fwrite.Write(manc + "\t" + nc.tenncc + "\t" + nc.diachi + "\t" + nc.sdt);
            fwrite.Close();
        }
        //Cập nhật lại danh sách vào tệp
        public void Update(List<NCC> list)
        {
            StreamWriter fwrite = File.CreateText(txtfile2);
            for (int i = 0; i < list.Count; ++i)
                fwrite.WriteLine(list[i].mancc + "\t" + list[i].tenncc + "\t" + list[i].diachi + "\t" + list[i].sdt);
            fwrite.Close();
        }
    }
}


