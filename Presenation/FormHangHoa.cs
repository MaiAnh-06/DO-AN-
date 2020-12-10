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
            Console.WriteLine("NHAP THONG TIN HANG HOA");
            HangHoa hh = new HangHoa();
            Console.Write("Nhap ma hang hoa:"); hh.mahh = int.Parse(Console.ReadLine());
            Console.Write("Nhap ten hang hoa:"); hh.tenhang = Console.ReadLine();
            Console.Write("Nhap so luong nhap ve:"); hh.slnhapve = int.Parse(Console.ReadLine());
            Console.Write("Nhap so luong hien co:"); hh.slhienco = int.Parse(Console.ReadLine());
            
            hanghoa.ThemHangHoa(hh);
        }
        public void Hien()
        {
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("\t\t\t\t\t HIEN THI THONG TIN HANG HOA");
            Console.WriteLine();
            List<HangHoa> list = hanghoa.XemDSHangHoa();
            foreach (var hh in list)
                Console.WriteLine( "\t\t\t" + hh.mahh + "\t\t" + hh.tenhang + "\t\t" + hh.slnhapve + "\t\t" + hh.slhienco);
        }
        public void Sua()
        {
            Console.Clear();
            Console.WriteLine("SUA THONG TIN HANG HOA");
            List<HangHoa> list = hanghoa.XemDSHangHoa();
            int mahh;
            Console.Write("Nhap ma hang hoa can sua:");
            mahh = int.Parse(Console.ReadLine());
            int i = 0;
            for (i = 0; i < list.Count; ++i)
                if (list[i].mahh == mahh) break;

            if (i < list.Count)
            {
                HangHoa sp = new HangHoa(list[i]);
                Console.Write("Nhap ten hang moi:");
                string tenhang = Console.ReadLine();
                if (!string.IsNullOrEmpty(tenhang)) sp.tenhang = tenhang;
                Console.Write("So luong nhap ve:");
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
            Console.WriteLine("Xóa THÔNG TIN HANG HOA");
            List<HangHoa> list = hanghoa.XemDSHangHoa();
            int mahh;
            Console.Write("Nhập mã hang cần xóa:");
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
                Console.WriteLine("Không tồn tại mã hang này");
            }

        }
        public void TimKiem()
        {
            Console.Clear();
            Console.WriteLine("TIM KIEM HANG HOA");
            List<HangHoa> list = hanghoa.XemDSHangHoa();

            Console.WriteLine("Nhap thong tin hang hoa can tim kiem"); string mm = Console.ReadLine();
            int i = 0;
            for (i = 0; i < list.Count; i++)
                if (list[i].tenhang == mm ) break;
            if (i < list.Count)
            {
                List<HangHoa> hangs = hanghoa.TimHangHoa(new HangHoa(list[i]));
                foreach (var x in hangs)

                    Console.WriteLine(x.mahh + "\t" + x.tenhang + "\t" + x.slnhapve + "\t" + x.slhienco);
            }

            else Console.WriteLine("Thong tin hang  nay k ton tai");
        }
        public void Menu()
        {
            do
            {
                Console.Clear();
                Console.WriteLine("\t\t\t\t\t****************************************************\t\t\t");
                Console.WriteLine("\t\t\t\t\t*         QUAN LY THONG TIN HANG HOA               *\t\t\t");
                Console.WriteLine("\t\t\t\t\t*             1.Nhap Hang Hoa                      *\t\t\t");
                Console.WriteLine("\t\t\t\t\t*             2.Sua Hang Hoa                       *\t\t\t");
                Console.WriteLine("\t\t\t\t\t*             3.Xoa hang hoa                       *\t\t\t");
                Console.WriteLine("\t\t\t\t\t*             4.Hien danh sach                     *\t\t\t");
                Console.WriteLine("\t\t\t\t\t*             5.Tim kiem                           *\t\t\t");
                Console.WriteLine("\t\t\t\t\t*             6.Back                               *\t\t\t");
                Console.WriteLine("\t\t\t\t\t****************************************************\t\t\t");
                Console.WriteLine("Chon chuc nang:");
                
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

