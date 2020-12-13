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
    class HoaDonNhapDAL : IDHoaDonNhapDAL
    {
        //Xác định đường dẫn của tệp dữ liệu HOADONNHAP.txt
        private string txtfile4 = "Data/HOADONNHAP.txt";
        //Lấy toàn bộ dữ liệu có trong file HOADONNHAP.txt đưa vào một danh sách
        public List<HoaDonNhap> GetData()
        {
            List<HoaDonNhap> list = new List<HoaDonNhap>();
            StreamReader fread4 = File.OpenText(txtfile4);
            string s = fread4.ReadLine();
            while (s != null)
            {
                if (s != "")
                {
                    
                    string[] a = s.Split('\t');
                    list.Add(new HoaDonNhap(int.Parse(a[0]), int.Parse(a[1]), a[2], int.Parse(a[3]), a[4], int.Parse(a[5]), int.Parse(a[6]), double.Parse(a[7]), double.Parse(a[8])));

                }
                s = fread4.ReadLine();

            }
            fread4.Close();
            return list;
        }
        
        //Chèn một bản ghi hóa đơn nhập vào tệp
        public void Insert(HoaDonNhap hdn)
        {
            int manhap = hdn.mahdn + 1;
            StreamWriter fwrite = File.AppendText(txtfile4);
            fwrite.WriteLine();
            fwrite.Write(manhap + "\t" + hdn.mancc + "\t" + hdn.nvgiao + "\t" + hdn.manvnhan + "\t" + hdn.ngaynhan + "\t" + hdn.mahang + "\t" + hdn.soluong + "\t" + hdn.gianhap + "\t" + hdn.thanhtien);
            fwrite.Close();
        }
        //Cập nhật lại danh sách vào tệp
        public void Update(List<HoaDonNhap> list)
        {
            StreamWriter fwrite = File.CreateText(txtfile4);
            for (int i = 0; i < list.Count; ++i)
                fwrite.WriteLine(list[i].mahdn + "\t" + list[i].mancc + "\t" + list[i].nvgiao + "\t" + list[i].manvnhan + "\t" + list[i].ngaynhan + "\t" + list[i].mahang + "\t" + list[i].soluong + "\t" + list[i].gianhap + "\t" + list[i].thanhtien); ;
            fwrite.Close();
        }
    }
}

