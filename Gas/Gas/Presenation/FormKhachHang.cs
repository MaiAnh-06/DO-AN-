using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gas.Entites;
using Gas.BusinessLayer;

namespace GAS.Presenation
{
    class FormKhachHang
    {
        private IFKhachHangBLL khach = new KhachHangBLL();
        public void Nhap()
        {
            Console.Clear();
            Console.WriteLine("");
            Console.WriteLine("\t\t\tNHẬP THÔNG TIN KHÁCH HÀNG ");
             Khachhang hh = new Khachhang();
            Console.Write("\t\tNhập mã khách hàng :"); hh.Makhach = Console.ReadLine();
            Console.Write("\t\tNhập tên khách hàng:"); hh.Tenkhach = Console.ReadLine();
            Console.Write("\t\tNhập quê quán :"); hh.Quequan = Console.ReadLine();
            Console.Write("\t\tNhập số điện thoại :"); hh.Sodienthoai= Console.ReadLine();

            khach.ThemKH(hh);
        }
        public void Hien()
        {
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("\t\t\t\t\t HIỂN THỊ THÔNG TIN KHÁCH HÀNG ");
            Console.WriteLine();
            Console.WriteLine("{0,15}|{1,15}|{2,15}|{3,15}", "Mã Khách Hàng", "Tên K_Hàng ", "Quê Quán ", "Số Điện Thoại");
            List<Khachhang> list = khach.XemDSKhachHang();
            foreach (var hh in list)
                Console.WriteLine("{0,15}|{1,15}|{2,15}|{3,15}", hh.Makhach, hh.Tenkhach, hh.Quequan, hh.Sodienthoai);
        }
        public void Sua()
        {
            Console.Clear();
            Console.WriteLine("\t\t\tSỬA THÔNG TIN KHÁCH HÀNG ");
            List<Khachhang> list = khach.XemDSKhachHang();
            string makhach;
            Console.Write("\t\tNhập mã khách hàng cần sửa :");
            makhach = Console.ReadLine();
            int i = 0;
            for (i = 0; i < list.Count; ++i)
                if (list[i].Makhach == makhach) break;

            if (i < list.Count)
            {
                Khachhang sp = new Khachhang(list[i]);
                Console.Write("\t\tNhập tên khách hàng mới :");
                string tenkhach = Console.ReadLine();
                if (!string.IsNullOrEmpty(tenkhach)) sp.Tenkhach = tenkhach;
                Console.Write("\t\tQuê quán :"); string que = Console.ReadLine();
                if (!string.IsNullOrEmpty(que)) sp.Quequan = que;
                Console.Write("\t\tSố điện thoại:");
                string sdt = Console.ReadLine();
                if (!string.IsNullOrEmpty(sdt)) sp.Sodienthoai = sdt;
                khach.SuaKH(sp);
            }
            else
            {
                Console.WriteLine("Không tồn tại mã hàng này");
            }
        }
        public void Xoa()
        {
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine("\t\tXÓA THÔNG TIN HÀNG HÓA ");
            List<Khachhang> list = khach.XemDSKhachHang();
            string makhach;
            Console.Write("\tNhập mã khách hàng cần xóa:");
            makhach = Console.ReadLine();
            int i = 0;
            for (i = 0; i < list.Count; ++i)
            {
                if (list[i].Makhach== makhach)
                {
                    break;
                }
            }

            if (i < list.Count)
            {
                Khachhang mah = new Khachhang(list[i]);
                khach.XoaKH(makhach);
            }
            else
            {
                Console.WriteLine("Không tồn tại mã hàng  này");
            }

        }
        public void TimKiem()
        {
            Console.Clear();
            Console.WriteLine("\t\tTÌM KIẾM KHÁCH HÀNG ");
            List<Khachhang> list = khach.XemDSKhachHang();

            Console.WriteLine("\tNhập tên khách hàng cần tìm kiếm: "); string mm = Console.ReadLine();
            int i = 0;
            for (i = 0; i < list.Count; i++)
                if (list[i].Tenkhach == mm) break;
            if (i < list.Count)
            {
                List<Khachhang> HH = khach.TimKH(new Khachhang(list[i]));
                foreach (var x in HH)

                    Console.WriteLine(x.Makhach+ "\t" + x.Tenkhach + "\t" + x.Quequan + "\t" + x.Sodienthoai);
            }

            else Console.WriteLine("Thông tin mặt hàng này không tồn tại");
        }
        public void Menu()
        {
            do
            {
                Console.Clear();
                Console.WriteLine("\t\t\t\t\t****************************************************\t\t\t");
                Console.WriteLine("\t\t\t\t\t*          QUẢN LÝ THÔNG TIN KHÁCH HÀNG            *\t\t\t");
                Console.WriteLine("\t\t\t\t\t*             1.Nhập khách hàng                    *\t\t\t");
                Console.WriteLine("\t\t\t\t\t*             2.Sửa khách hàng                     *\t\t\t");
                Console.WriteLine("\t\t\t\t\t*             3.Xóa khách hàng                     *\t\t\t");
                Console.WriteLine("\t\t\t\t\t*             4.Hiện danh sách khách hàng          *\t\t\t");
                Console.WriteLine("\t\t\t\t\t*             5.Tìm kiếm                           *\t\t\t");
                Console.WriteLine("\t\t\t\t\t*             6.Back                               *\t\t\t");
                Console.WriteLine("\t\t\t\t\t****************************************************\t\t\t");
                Console.WriteLine("Chọn chức năng :");

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

