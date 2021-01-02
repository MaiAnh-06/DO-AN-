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
            Console.WriteLine("NHẬP THÔNG TIN HÓA ĐƠN BÁN");
            HoaDonBan hdb = new HoaDonBan();
            Console.Write("Nhập mã hóa đơn bán:"); hdb.mahdb = int.Parse(Console.ReadLine());
            Console.Write("Nhap mã nhân viên bán :"); hdb.manvban = int.Parse(Console.ReadLine());
            Console.Write("Nhập ngày bán :"); hdb.ngayban = Console.ReadLine();
            Console.Write("Nhập mã hàng  :"); hdb.mahang = int.Parse(Console.ReadLine());
            Console.Write("Nhập số lượng  :"); hdb.soluong = int.Parse(Console.ReadLine());
            Console.Write(" Nhập giá bán   :"); hdb.giaban = double.Parse(Console.ReadLine());
            Console.Write("Nhập tên khách hàng:"); hdb.kh = Console.ReadLine();


            hoadonban.ThemHoaDonBan(hdb);
        }
        public void Hien()
        {
            Console.Clear();
            Console.WriteLine("\t\t\t\t HIỂN THỊ THÔNG TIN HÓA ĐƠN BÁN");
            Console.WriteLine();
            Console.WriteLine("{0,10}|{1,10}|{2,10}|{3,10}|{4,10}|{5,10}|{6,10}|{7,10}", "Ma HDB", "Ma NV ban", "Ngay Ban","Mã Hàng ","Số Lượng","Giá Bán","Tên khách" ,"Thành Tiền ");
            List<HoaDonBan> list = hoadonban.XemDSHoaDonBan();
            foreach (var hdb in list)
                Console.WriteLine("{0,10}|{1,10}|{2,10}|{3,10}|{4,10}|{5,10}|{6,10}|{7,10}", hdb.mahdb , hdb.manvban ,hdb.ngayban , hdb.mahang , hdb.soluong , hdb.giaban ,hdb.kh ,hdb.thanhtien);
        }
        public void Sua()
        {
            Console.Clear();
            Console.WriteLine("SỬA THÔNG TIN HÓA ĐƠN BÁN ");
            List<HoaDonBan> list = hoadonban.XemDSHoaDonBan();
            int mahdb;
            Console.Write("Nhập mã hóa đơn bán  cần sửa  :");
            mahdb = int.Parse(Console.ReadLine());
            int i = 0;
            for (i = 0; i < list.Count; ++i)
                if (list[i].mahdb == mahdb) break;

            if (i < list.Count)
            {
                HoaDonBan hd1 = new HoaDonBan(list[i]);
                Console.Write("Nhập mã nhân viên bán mới :");
                int nvb =int.Parse( Console.ReadLine());
                if (nvb > 0) hd1.manvban= nvb;
                Console.Write("\t\tNhập ngày bán  mới :");
                string nb = Console.ReadLine();
                if (!string.IsNullOrEmpty(nb)) hd1.ngayban = nb;
                Console.Write("Nhập mã hàng cần sửa :");
                int mh = int.Parse(Console.ReadLine());
                if (mh > 0) hd1.mahang = mh;
                Console.Write("\t\tSố lượng mới :");
                int SL = int.Parse(Console.ReadLine());
                if (SL > 0) hd1.soluong = SL;
                Console.Write("Nhập giá bán mới:");
                int gb= int.Parse(Console.ReadLine());
                if (gb > 0) hd1.giaban = gb;
                Console.Write("\t\tNhập tên khách  mới :");
                string tk = Console.ReadLine();
                if (!string.IsNullOrEmpty(tk)) hd1.kh = tk;
                hoadonban.SuaHoaDonBan(hd1);


            }
            else
            {
                Console.WriteLine("Khong ton tai ma hang nay");
            }
        }
        public void Xoa()
        {
            Console.Clear();
            Console.WriteLine("XÓA THÔNG TIN HÓA ĐƠN BÁN ");
            List<HoaDonBan> list = hoadonban.XemDSHoaDonBan();
            int mahdb;
            Console.Write("Nhập mã hóa đơn bán cần xóa:");
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
            Console.WriteLine("TÌM KIẾM HÓA ĐƠN BÁN");
            List<HoaDonBan> list = hoadonban.XemDSHoaDonBan();

            Console.WriteLine("Nhập mã hóa đơn bán cần tìm kiếm"); int tt = int.Parse(Console.ReadLine());
            int i = 0;
            for (i = 0; i < list.Count; i++)
                if (list[i]. mahdb== tt || list[i].mahang == tt || list[i].soluong == tt || list[i].manvban == tt) break;
            if (i < list.Count)
            {
                List<HoaDonBan> hdb= hoadonban.TimHoaDonBan(new HoaDonBan(list[i]));
                foreach (var x in hdb)

                    Console.WriteLine(x.mahdb +  x.manvban + x.ngayban+ "\t" + x.mahang + "\t" + x.soluong+"\t"+x.giaban+"\t"+x.kh+"\t"+x.thanhtien);
            }

            else Console.WriteLine("Thông tin hóa đơn bán cần tìm kiếm ko tồn tại");
        }
        public void Menu()
        {
            do
            {
                Console.Clear();
                Console.WriteLine("__________________________________________________________________");
                Console.WriteLine("|                    QUẢN LÝ THÔNG TIN HÓA ĐƠN BÁN               |");
                Console.WriteLine("|                     1.Nhập hóa đơn bán                         |");
                Console.WriteLine("|                     2.Sửa hóa đơn bán                          |");
                Console.WriteLine("|                     3.Xóa hóa đơn bán                          |");
                Console.WriteLine("|                     4.Hiện danh sách hóa đơn bán               |");
                Console.WriteLine("|                     5.Tìm kiếm hóa đơn bán                     |");
                Console.WriteLine("|                     6.Back                                     |");
                Console.WriteLine("|________________________________________________________________|");

                Console.WriteLine("Mời chọn chức năng:");

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
