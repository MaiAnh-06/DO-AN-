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
            Console.WriteLine("HIEN THI THONG TIN HANG HOA");
            List<HangHoa> list = hanghoa.XemDSHangHoa();
            foreach (var hh in list)
                Console.WriteLine(hh.mahh + "\t" + hh.tenhang + "\t" + hh.slnhapve + "\t" + hh.slhienco);
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
        public void Menu()
        {
            do
            {
                Console.Clear();
                Console.WriteLine("QUAN LY THONG TIN HANG HOA");
                Console.WriteLine(" 1.Nhap Hang Hoa ");
                Console.WriteLine(" 2.Sua Hang Hoa ");
                Console.WriteLine(" 3.Xoa hang hoa ");
                Console.WriteLine(" 4.Hien danh sach ");
                Console.WriteLine(" 5.Tim kiem ");
                Console.WriteLine(" 6.Back ");
                
                int n =int.Parse( Console.ReadLine());
                switch (n)
                {
                    case 1:
                        Nhap();
                        Hien();
                        Console.WriteLine("Nhap phim bat ky de tiep tuc...");
                        Console.ReadKey();
                        break;
                    case 2:
                        Hien();
                        Console.WriteLine("Nhap phim bat ky de tiep tuc...");
                        Console.ReadKey();
                        break;
                    case 3:
                        Hien();
                        Console.WriteLine("Nhap phim bat ky de tiep tuc...");
                        Console.ReadKey();
                        break;
                    case 4:
                        Sua();
                        Hien();
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

