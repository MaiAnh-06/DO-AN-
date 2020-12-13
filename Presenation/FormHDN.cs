using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gas.Entites;
using GAS.BusinessLayer;
using Gas.BusinessLayer.Interface;


namespace GAS.Presenation
{
    public class FormHDN
    {
        private IFHoaDonNhapBLL hoadonnhap= new HoaDonNhapBLL();
        public void Nhap()
        {
            Console.Clear();
            Console.WriteLine("NHAP THONG TIN HOA DON NHAP");
            HoaDonNhap hdn = new HoaDonNhap();
            Console.Write("Nhap ma hoa don nhap:"); hdn.mahdn = int.Parse(Console.ReadLine());
            Console.Write("Nhap ma nha cung cap :"); hdn.mancc = int.Parse(Console.ReadLine());
            Console.Write("Nhap nguoi giao :"); hdn.nvgiao = Console.ReadLine();
            Console.Write("Nhap ma nhan vien nhan  :"); hdn.manvnhan = int.Parse(Console.ReadLine());
            Console.Write("Nhap ngay nhan :"); hdn.ngaynhan = Console.ReadLine();
            Console.Write(" Nhap ma hang  :"); hdn.mahang = int.Parse(Console.ReadLine());
            Console.Write("Nhap so luong :"); hdn.soluong= int.Parse(Console.ReadLine());
            Console.Write(" Gia nhap :"); hdn.gianhap = double.Parse(Console.ReadLine());

            hoadonnhap.ThemHoaDonNhap(hdn);
        }
        public void Hien()
        {
            Console.Clear();
            Console.WriteLine("HIEN THI THONG TIN HOA DON NHAP");
            List<HoaDonNhap> list = hoadonnhap.XemDSHoaDonNhap();
            foreach (var hdn in list)
                Console.WriteLine(hdn.mahdn + "\t" + hdn.mancc + "\t" + hdn.nvgiao + "\t" + hdn.manvnhan + "\t" + hdn.ngaynhan + "\t" + hdn.mahang + "\t" + hdn.soluong + "\t" + hdn.gianhap + "\t" + hdn.thanhtien);
        }
        public void Sua()
        {
            Console.Clear();
            Console.WriteLine("SUA THONG TIN HOA DON Nhap");
            List<HoaDonNhap> list = hoadonnhap.XemDSHoaDonNhap();
            int mahdn;
            Console.Write("Nhap ma hang don can sua :");
            mahdn = int.Parse(Console.ReadLine());
            int i = 0;
            for (i = 0; i < list.Count; ++i)
                if (list[i].mahdn == mahdn) break;

            if (i < list.Count)
            {
                HoaDonNhap mh = new HoaDonNhap(list[i]);
                Console.Write("Nhap ten hang can sua:");
                int mahang = int.Parse(Console.ReadLine());

                Console.Write("So luong nhap ve:");
                int SL = int.Parse(Console.ReadLine());

            }
            else
            {
                Console.WriteLine("Khong ton tai ma hang nay");
            }
        }
        public void Xoa()
        {
            Console.Clear();
            Console.WriteLine("XOA THÔNG TIN HOA DON NHAP");
            List<HoaDonNhap> list = hoadonnhap.XemDSHoaDonNhap();
            int mahdn;
            Console.Write("Nhập mã nhan vien cần xóa:");
            mahdn = int.Parse(Console.ReadLine());
            int i = 0;
            for (i = 0; i < list.Count; ++i)
            {
                if (list[i].mahdn == mahdn)
                {
                    break;
                }
            }

            if (i < list.Count)
            {
                HoaDonNhap mahd = new HoaDonNhap(list[i]);
                hoadonnhap.XoaHoaDonNhap(mahdn);
            }
            else
            {
                Console.WriteLine("Không tồn tại mã nhan vien này");
            }

        }
        public void TimKiem()
        {
            Console.Clear();
            Console.WriteLine("Tim kiem hoa don nhap");
            List<HoaDonNhap> list = hoadonnhap.XemDSHoaDonNhap();

            Console.WriteLine("Nhap thong tin nhan vien can tim kiem"); int tt = int.Parse(Console.ReadLine());
            int i = 0;
            for (i = 0; i < list.Count; i++)
                if (list[i].mahdn == tt || list[i].mancc == tt || list[i].manvnhan == tt || list[i].mahang == tt) break;
            if (i < list.Count)
            {
                List<HoaDonNhap> hdn = hoadonnhap.TimHoaDonNhap(new HoaDonNhap(list[i]));
                foreach (var x in hdn)

                    Console.WriteLine(x.mahdn + "\t" + x.mancc + "\t" + x.nvgiao + "\t" + x.manvnhan + "\t" + x.ngaynhan + "\t\t" + x.mahang + "\t\t" + x.soluong + "\t\t" + x.gianhap + "\t\t" + x.thanhtien);

            }

            else Console.WriteLine("Thong tin hoa don  nay khong ton tai");
        }
        public void Menu()
        {
            do
            {
                Console.Clear();
                Console.WriteLine("+ + + + + + + + + + + + + + + + + + + + + + + +");
                Console.WriteLine("+        QUAN LY THONG TIN HOA DON NHAP       +");
                Console.WriteLine("+         1.Nhap Hoa don                      +");
                Console.WriteLine("+         2.Sua Hoa don                       +");
                Console.WriteLine("+         3.Xoa hoa don                       +");
                Console.WriteLine("+         4.Hien danh sach                    +");
                Console.WriteLine("+         5.Tim kiem                          +");
                Console.WriteLine("+         6.Back                              +");
                Console.WriteLine("+ + + + + + + + + + + + + + + + + + + + + + + +");
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

