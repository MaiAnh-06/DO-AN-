using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GAS.BusinessLayer;
using GAS.Entites;


namespace GAS.Presenation
{
    public class FormHangHoa
    {
        private IFHangHoaBLL hanghoa = new HangHoaBLL();
        public void Nhap()
        {
            Console.Clear();
            Console.WriteLine("");
            Console.WriteLine("\t\t\tNHẬP THÔNG TIN HÀNG HÓA ");
            HangHoa hh = new HangHoa();
            Console.Write("\t\tNhập mã hàng hóa :"); hh.mahh = int.Parse(Console.ReadLine());
            Console.Write("\t\tNhập tên hàng hóa:"); hh.tenhang = Console.ReadLine();
            Console.Write("\t\tSố lượng nhập về:"); hh.slnhapve = int.Parse(Console.ReadLine());
            Console.Write("\t\tSố lượng hiện có :"); hh.slhienco = int.Parse(Console.ReadLine());
            
            hanghoa.ThemHangHoa(hh);
        }
        public void Hien()
        {
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("\t\t\t\t\t HIỂN THỊ THÔNG TIN HÀNG HÓA ");
            Console.WriteLine();
            List<HangHoa> list = hanghoa.XemDSHangHoa();
            foreach (var hh in list)
                Console.WriteLine( "\t\t\t" + hh.mahh + "\t\t" + hh.tenhang + "\t\t" + hh.slnhapve + "\t\t" + hh.slhienco);
        }
        public void Sua()
        {
            Console.Clear();
            Console.WriteLine("\t\t\tSỬA THÔNG TIN HÀNG HÓA ");
            List<HangHoa> list = hanghoa.XemDSHangHoa();
            int mahh;
            Console.Write("\t\tNhập mã hàng hóa cần sửa :");
            mahh = int.Parse(Console.ReadLine());
            int i = 0;
            for (i = 0; i < list.Count; ++i)
                if (list[i].mahh == mahh) break;

            if (i < list.Count)
            {
                HangHoa sp = new HangHoa(list[i]);
                Console.Write("\t\tNhập tên hàng mới :");
                string tenhang = Console.ReadLine();
                if (!string.IsNullOrEmpty(tenhang)) sp.tenhang = tenhang;
                Console.Write("\t\tSố lượng nhập về :");
                int SL = int.Parse(Console.ReadLine());

            }
            else
            {
                Console.WriteLine("Khong ton tai ma  hang nay");
            }
        }
        public void Xoa()
        {
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine("\t\tXÓA THÔNG TIN HÀNG HÓA ");
            List<HangHoa> list = hanghoa.XemDSHangHoa();
            int mahh;
            Console.Write("\tNhập mã hàng cần xóa:");
            mahh = int.Parse(Console.ReadLine());
            int i = 0;
            for (i = 0; i < list.Count; ++i)
            {
                if (list[i].mahh== mahh)
                {
                    break;
                }
            }

            if (i < list.Count)
            {
                HangHoa mah = new HangHoa(list[i]);
                hanghoa.XoaHangHoa(mahh);
            }
            else
            {
                Console.WriteLine("Không tồn tại mã hàng  này");
            }

        }
        public void TimKiem()
        {
            Console.Clear();
            Console.WriteLine("\t\tTÌM KIẾM HÀNG HÓA ");
            List<HangHoa> list = hanghoa.XemDSHangHoa();

            Console.WriteLine("\tNhập tên hàng hóa cần tìm kiếm: "); string mm = Console.ReadLine();
            int i = 0;
            for (i = 0; i < list.Count; i++)
                if (list[i].tenhang == mm ) break;
            if (i < list.Count)
            {
                List<HangHoa> HH = hanghoa.TimHangHoa(new HangHoa(list[i]));
                foreach (var x in HH)

                    Console.WriteLine(x.mahh + "\t" + x.tenhang + "\t" + x.slnhapve + "\t" + x.slhienco);
            }

            else Console.WriteLine("Thông tin mặt hàng này không tồn tại");
        }
        public void Menu()
        {
            do
            {
                Console.Clear();
                Console.WriteLine("\t\t\t\t\t****************************************************\t\t\t");
                Console.WriteLine("\t\t\t\t\t*          QUẢN LÝ THÔNG TIN HÀNG HÓA              *\t\t\t");
                Console.WriteLine("\t\t\t\t\t*             1.Nhập hàng hóa                      *\t\t\t");
                Console.WriteLine("\t\t\t\t\t*             2.Sửa hàng hóa                       *\t\t\t");
                Console.WriteLine("\t\t\t\t\t*             3.Xóa hàng hóa                       *\t\t\t");
                Console.WriteLine("\t\t\t\t\t*             4.Hiện danh sách hàng hóa            *\t\t\t");
                Console.WriteLine("\t\t\t\t\t*             5.Tìm kiếm                           *\t\t\t");
                Console.WriteLine("\t\t\t\t\t*             6.Back                               *\t\t\t");
                Console.WriteLine("\t\t\t\t\t****************************************************\t\t\t");
                Console.WriteLine("Chọn chức năng :");
                
                int n =int.Parse( Console.ReadLine());
                switch (n)
                {
                    case 1:
                        Nhap();
                        Hien();
                        Console.WriteLine("Nhap phim bat ky de tiep tuc...");
                        Console.ReadKey();
                        break;
                    case 4:
                        Hien();
                        Console.WriteLine();
                        Console.WriteLine("Nhap phim bat ky de tiep tuc...");
                        Console.ReadKey();
                        break;
                    case 3:
                        Xoa();
                        Hien();
                        Console.WriteLine("Nhap phim bat ky de tiep tuc...");
                        Console.ReadKey();
                        break;
                    case 2:
                        Sua();
                        Hien();
                        Console.WriteLine("Nhap phim bat ky de tiep tuc...");
                        Console.ReadKey();
                        break;
                    case 5:
                        TimKiem();
                        Console.WriteLine("Nhap phim bat ky de tiep tuc...");
                        Console.ReadKey();
                        break;

                    case 6:
                        Program.Menu();
                        break;
                }
            } while (true);
        }
    }

}

