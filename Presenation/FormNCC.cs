using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GAS.BusinessLayer.Interface;
using GAS.BusinessLayer;
using GAS.Entites;


namespace GAS.Presenation
{
    public class FormNCC
    {
        private IFNhaCCBLL nhacc = new NhaCCBLL();
        public void Nhap()
        {
            Console.Clear();
            Console.WriteLine("NHAP THONG TIN NHA CUNG CAP");
            NCC ncc = new NCC();
            Console.Write("Nhap ma nha cung cap:"); ncc.mancc= int.Parse(Console.ReadLine());
            Console.Write("Nhap ten nha cung cap:"); ncc.tenncc= Console.ReadLine();
            Console.Write("Nhap dia chi nha cung cap:"); ncc.diachi= (Console.ReadLine());
            Console.Write("Nhap so dien thoai :"); ncc.sdt= (Console.ReadLine());

            nhacc.ThemNhaCC(ncc);
        }
        public void Hien()
        {
            Console.Clear();
            Console.WriteLine("HIEN THI THONG TIN NHA CUNG CAP");
            List<NCC> list = nhacc.XemDSNhaCC();
            foreach (var ncc in list)
                Console.WriteLine(ncc.mancc + "\t" + ncc.tenncc + "\t" + ncc.diachi + "\t" + ncc.sdt);
        }
        public void Sua()
        {
            Console.Clear();
            Console.WriteLine("SUA THONG TIN NHA CUNG CAP");
            List<NCC> list = nhacc.XemDSNhaCC();
            int mancc;
            Console.Write("Nhap ma ncc can sua:");
            mancc= int.Parse(Console.ReadLine());
            int i = 0;
            for (i = 0; i < list.Count; ++i)
                if (list[i].mancc == mancc) break;

            if (i < list.Count)
            {
                NCC ncc = new NCC(list[i]);
                Console.Write("Nhap ten hang moi:");
                string tenncc = Console.ReadLine();
                if (!string.IsNullOrEmpty(tenncc)) ncc.tenncc = tenncc;
                Console.Write("Dia chi moi:");
                string dc = Console.ReadLine();

            }
            else
            {
                Console.WriteLine("Khong ton tai ma  hang nay");
            }
        }
        public void Xoa()
        {
            Console.Clear();
            Console.WriteLine("Xóa THÔNG TIN NHA CUNG CAP");
            List<NCC> list = nhacc.XemDSNhaCC();
            int mancc;
            Console.Write("Nhập mã nha cung cap cần xóa:");
            mancc = int.Parse(Console.ReadLine());
            int i = 0;
            for (i = 0; i < list.Count; ++i)
            {
                if (list[i].mancc == mancc)
                {
                    break;
                }
            }

            if (i < list.Count)
            {
                NCC nv = new NCC(list[i]);
                nhacc.XoaNhaCC(mancc);
            }
            else
            {
                Console.WriteLine("Không tồn tại mã nhan vien này");
            }

        }
        public void Menu()
        {
            do
            {
                Console.Clear();
                Console.WriteLine("\t\t\t\t\t****************************************************");
                Console.WriteLine("\t\t\t\t\t*          QUAN LY THONG TIN NHA CUNG CAP          *");
                Console.WriteLine("\t\t\t\t\t*              1.Nhap nha cung cap                 *");
                Console.WriteLine("\t\t\t\t\t*              2.Sua nha cung cap                  *");
                Console.WriteLine("\t\t\t\t\t*              3.Xoa nha cung cap                  *");
                Console.WriteLine("\t\t\t\t\t*              4.Hien danh sach nha cung cap       *");
                Console.WriteLine("\t\t\t\t\t*              5.Tim kiem                          *");
                Console.WriteLine("\t\t\t\t\t*              6.Back                              *");
                Console.WriteLine("\t\t\t\t\t****************************************************");
                Console.WriteLine("Moi chon chuc nang:");

                int n = int.Parse(Console.ReadLine());
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
                    case 6:
                        Program.Menu();
                        break;
                }
            } while (true);
        }
    }

}


