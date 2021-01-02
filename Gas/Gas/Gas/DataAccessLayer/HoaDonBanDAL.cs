using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Gas.DataAccessLayer.Interface;
using Gas.Entites;

namespace Gas.DataAccessLayer
{
    class HoaDonBanDAL : IDHoaDonBanDAL
    {
        //Xác định đường dẫn của tệp dữ liệu HOADONBAN.txt
        private string txtfile6 = "Data/HOADONBAN.txt";
        //Lấy toàn bộ dữ liệu có trong file HOADONBAN.txt đưa vào một danh sách
        public List<HoaDonBan> GetData()
        {
            List<HoaDonBan> list = new List<HoaDonBan>();
            StreamReader fread6 = File.OpenText(txtfile6);
            string s = fread6.ReadLine();
            while (s != null)
            {
                if (s != "")
                {
                    
                    string[] a = s.Split('\t');
                    list.Add(new HoaDonBan(int.Parse(a[0]), int.Parse(a[1]), a[2], int.Parse(a[3]), int.Parse(a[4]), double.Parse(a[5]), a[6], double.Parse(a[7])));

                }
                s = fread6.ReadLine();

            }
            fread6.Close();
            return list;
        }
        
        //Chèn một bản ghi hóa đơn bán vào tệp
        public void Insert(HoaDonBan hdb)
        {
            int mahdban = hdb.mahdb ;
            StreamWriter fwrite = File.AppendText(txtfile6);
            fwrite.WriteLine();
            fwrite.Write(mahdban + "\t" + hdb.manvban + "\t" + hdb.ngayban + "\t" + hdb.mahang + "\t" + hdb.soluong + "\t" + hdb.giaban + "\t" + hdb.kh + "\t" + hdb.thanhtien);
            fwrite.Close();
        }
        //Cập nhật lại danh sách vào tệp
        public void Update(List<HoaDonBan> list)
        {
            StreamWriter fwrite = File.CreateText(txtfile6);
            for (int i = 0; i < list.Count; ++i)
                fwrite.WriteLine(list[i].mahdb + "\t" + list[i].manvban + "\t" + list[i].ngayban + "\t" + list[i].mahang + "\t" + list[i].soluong + "\t" + list[i].giaban + "\t" + list[i].kh + "\t" + list[i].thanhtien);
            fwrite.Close();
        }
    }
}


