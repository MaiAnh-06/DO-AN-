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
            Console.WriteLine("NHẬP THÔNG TIN  HÓA ĐƠN NHẬP ");
            HoaDonNhap hdn = new HoaDonNhap();
            Console.Write("Nhập mã hóa đơn nhập:"); hdn.mahdn = int.Parse(Console.ReadLine());
            Console.Write("Nhập mã nhà cung cấp  :"); hdn.mancc = int.Parse(Console.ReadLine());
            Console.Write("Nhập người giao:"); hdn.nvgiao = Console.ReadLine();
            Console.Write("Nhập mã nhân viên nhận  :"); hdn.manvnhan = int.Parse(Console.ReadLine());
            Console.Write("Nhập ngày nhận :"); hdn.ngaynhan = Console.ReadLine();
            Console.Write("Nhập mã hàng  :"); hdn.mahang = int.Parse(Console.ReadLine());
            Console.Write("Nhập số lượng  :"); hdn.soluong= int.Parse(Console.ReadLine());
            Console.Write(" Giá nhập:"); hdn.gianhap = double.Parse(Console.ReadLine());

            hoadonnhap.ThemHoaDonNhap(hdn);
        }
        public void Hien()
        {
            Console.Clear();
            Console.WriteLine("t\t\t\tHIỂN THỊ THÔNG TIN  HÓA ĐƠN NHẬP");
            Console.WriteLine();
            Console.WriteLine("{0,10}|{1,10}|{2,15}|{3,10}|{4,10}|{5,10}|{6,10}|{7,10}|{8,10}", "Mã HDN", "Mã NCC", "NV giao", "Mã NV nhận", "Ngày nhận", "Mã Hàng", "Số lượng", "Giá Nhập", "Thành tiền");
            List<HoaDonNhap> list = hoadonnhap.XemDSHoaDonNhap();
            foreach (var hdn in list)
                Console.WriteLine("{0,10}|{1,10}|{2,15}|{3,10}|{4,10}|{5,10}|{6,10}|{7,10}|{8,10}", hdn.mahdn , hdn.mancc , hdn.nvgiao ,hdn.manvnhan , hdn.ngaynhan ,hdn.mahang , hdn.soluong, hdn.gianhap , hdn.thanhtien);
        }
        public void Sua()
        {
            Console.Clear();
            Console.WriteLine("SỬA HÓA ĐƠN NHẬP");
            List<HoaDonNhap> list = hoadonnhap.XemDSHoaDonNhap();
            int mahdn;
            Console.Write("Nhập mã hóa đơn nhập cần sửa :");
            mahdn = int.Parse(Console.ReadLine());
            int i = 0;
            for (i = 0; i < list.Count; ++i)
                if (list[i].mahdn == mahdn) break;

            if (i < list.Count)
            {
                HoaDonNhap hd2 = new HoaDonNhap(list[i]);
                Console.Write("Nhập mã nhà cung cấp :");
                int nhacc = int.Parse(Console.ReadLine());
                if (nhacc > 0) hd2.mancc = nhacc;
                Console.Write("Nhập nhân viên giao :");
                string nvg = Console.ReadLine();
                if (!string.IsNullOrEmpty(nvg)) hd2.nvgiao = nvg;
                Console.Write("Nhập mã nhân viên nhận mới  :");
                int nvn= int.Parse(Console.ReadLine());
                if (nvn > 0) hd2.manvnhan = nvn;
                Console.Write("Nhập ngày nhận mới:");
                string nn= Console.ReadLine();
                if (!string.IsNullOrEmpty(nn)) hd2.ngaynhan= nn;
                Console.Write("Nhập mã hàng :");
                int mah= int.Parse(Console.ReadLine());
                if (mah > 0) hd2.mahang = mah;

                Console.Write("Số lượng mới :");
                int SL = int.Parse(Console.ReadLine());
                if (SL > 0) hd2.soluong = SL;
                Console.Write("Nhập giá nhập mới:");
                int gn = int.Parse(Console.ReadLine());
                if (gn > 0) hd2.gianhap = gn;
                hoadonnhap.SuaHoaDonNhap(hd2);

            }
            else
            {
                Console.WriteLine("Khong ton tai ma hang nay");
            }
        }
        public void Xoa()
        {
            Console.Clear();
            Console.WriteLine("XÓA THÔNG TIN HÓA ĐƠN NHẬP");
            List<HoaDonNhap> list = hoadonnhap.XemDSHoaDonNhap();
            int mahdn;
            Console.Write("Nhập mã hóa đơn nhập cần xóa:");
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
                Console.WriteLine("Không tồn tại mã hóa đơn  này");
            }

        }
        public void TimKiem()
        {
            Console.Clear();
            Console.WriteLine("TÌM KIẾM HÓA ĐƠN NHẬP");
            List<HoaDonNhap> list = hoadonnhap.XemDSHoaDonNhap();

            Console.WriteLine("Nhập thông tin hóa đơn nhập cần tìm kiếm:"); int tt = int.Parse(Console.ReadLine());
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
                Console.WriteLine("\t\t\t+ + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + +");
                Console.WriteLine("\t\t\t+                          QUẢN LÝ THÔNG TIN HÓA ĐƠN NHẬP                           +");
                Console.WriteLine("\t\t\t+                               1.Nhập hóa đơn                                      +");
                Console.WriteLine("\t\t\t+                               2.Sửa hóa đơn                                       +");
                Console.WriteLine("\t\t\t+                               3.Xóa hóa đơn                                       +");
                Console.WriteLine("\t\t\t+                               4.Hiện danh sách                                    +");
                Console.WriteLine("\t\t\t+                               5.Tìm kiếm                                          +");
                Console.WriteLine("\t\t\t+                               6.Back                                              +");
                Console.WriteLine("\t\t\t+ + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + +");
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

