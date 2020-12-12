using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gas.Entites;
using Gas.BusinessLayer;
using Gas.BusinessLayer.Interface;


namespace GAS.Presenation
{
    public class FormHDB
    {
        private IFHoaDonBanBLL hoadonban = new HoaDonBanBLL();
        public void Nhap()
        {
            Console.Clear();
            Console.WriteLine("NHAP THONG TIN HOA DON BAN");
            HoaDonBan hdb = new HoaDonBan();
            Console.Write("Nhap ma hoa don ban:"); hdb.mahdb = int.Parse(Console.ReadLine());
            Console.Write("Nhap ma nhan vien ban :"); hdb.manvban = int.Parse(Console.ReadLine());
            Console.Write("Nhap ngay ban :"); hdb.ngayban = Console.ReadLine();
            Console.Write("Nhap ma hang  :"); hdb.mahang = int.Parse(Console.ReadLine());
            Console.Write("Nhap so luong  :"); hdb.soluong = int.Parse(Console.ReadLine());
            Console.Write(" Nhap gia ban   :"); hdb.giaban = double.Parse(Console.ReadLine());
            Console.Write("Nhap ten khach hang:"); hdb.kh = Console.ReadLine();

            hoadonban.ThemHoaDonBan(hdb);
        }
        public void Hien()
        {
            Console.Clear();
            Console.WriteLine("\t\t\t\t HIEN THI THONG TIN HOA DON BAN");
            List<HoaDonBan> list = hoadonban.XemDSHoaDonBan();
            foreach (var hdb in list)
                Console.WriteLine(hdb.mahdb + "\t\t" + hdb.manvban + "\t\t" + hdb.ngayban + "\t\t" + hdb.mahang + "\t\t" + hdb.soluong + "\t\t" + hdb.giaban + "\t\t" + hdb.kh + "\t\t" + hdb.thanhtien);
        }
        public void Sua()
        {
            Console.Clear();
            Console.WriteLine("SUA THONG TIN HOA DON BAN");
            List<HoaDonBan> list = hoadonban.XemDSHoaDonBan();
            int mahdb;
            Console.Write("Nhap ma hang don can sua :");
            mahdb = int.Parse(Console.ReadLine());
            int i = 0;
            for (i = 0; i < list.Count; ++i)
                if (list[i].mahdb == mahdb) break;

            if (i < list.Count)
            {
                HoaDonBan mh = new HoaDonBan(list[i]);
                Console.Write("Nhap ten hang can sua:");
                int mahang =int.Parse( Console.ReadLine());
               
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
            Console.WriteLine("Xóa THÔNG TIN HOA DON BAN ");
            List<HoaDonBan> list = hoadonban.XemDSHoaDonBan();
            int mahdb;
            Console.Write("Nhập mã hoa don  cần xóa:");
            mahdb= int.Parse(Console.ReadLine());
            int i = 0;
            for (i = 0; i < list.Count; ++i)
            {
                if (list[i].mahdb == mahdb)
                {
                    break;
                }
            }

            if (i < list.Count)
            {
                HoaDonBan mahd = new HoaDonBan(list[i]);
                hoadonban.XoaHoaDonBan(mahdb);
            }
            else
            {
                Console.WriteLine("Không tồn tại mã hoa don này");
            }

        }
        public void TimKiem()
        {
            Console.Clear();
            Console.WriteLine("Tim kiem hoa don ban");
            List<HoaDonBan> list = hoadonban.XemDSHoaDonBan();

            Console.WriteLine("Nhap thong tin hoa don ban can tim kiem"); int tt = int.Parse(Console.ReadLine());
            int i = 0;
            for (i = 0; i < list.Count; i++)
                if (list[i]. mahdb== tt || list[i].mahang == tt || list[i].soluong == tt || list[i].manvban == tt) break;
            if (i < list.Count)
            {
                List<HoaDonBan> hdb= hoadonban.TimHoaDonBan(new HoaDonBan(list[i]));
                foreach (var x in hdb)

                    Console.WriteLine(x.mahdb + "\t" + x.manvban + "\t" + x.ngayban+ "\t" + x.mahang + "\t" + x.soluong+"\t"+x.giaban+"\t"+x.kh+"\t"+x.thanhtien);
            }

            else Console.WriteLine("Thong tin hoa don  nay k ton tai");
        }
        public void Menu()
        {
            do
            {
                Console.Clear();
                Console.WriteLine("__________________________________________________________________");
                Console.WriteLine("|                   QUAN LY THONG TIN HOA DON                    |");
                Console.WriteLine("|                     1.Nhap Hoa don ban                         |");
                Console.WriteLine("|                     2.Sua Hoa don ban                          |");
                Console.WriteLine("|                     3.Xoa hoa don ban                          |");
                Console.WriteLine("|                     4.Hien danh sach hoa don ban               |");
                Console.WriteLine("|                     5.Tim kiem hd ban                          |");
                Console.WriteLine("|                     6.Back                                     |");
                Console.WriteLine("|________________________________________________________________|");

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
                    case 5:
                        TimKiem();
                        Console.WriteLine("Nhap phim bat ky de tiep tuc...");
                        Console.ReadKey();
                        break;

                }
            } while (true);
        }
    }
}
