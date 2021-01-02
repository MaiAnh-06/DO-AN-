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
            Console.WriteLine("NHẬP THÔNG TIN NHÀ CUNG CẤP ");
            NCC ncc = new NCC();
            Console.Write("Nhập mã nhà cung cấp:"); ncc.mancc= int.Parse(Console.ReadLine());
            Console.Write("Nhập tên nhà cung cấp:"); ncc.tenncc= Console.ReadLine();
            Console.Write("Nhập địa chỉ nhà cung cấp:"); ncc.diachi= (Console.ReadLine());
            Console.Write("Nhập số điện thoại  :"); ncc.sdt= (Console.ReadLine());

            nhacc.ThemNhaCC(ncc);
        }
        public void Hien()
        {
            Console.Clear();
            Console.WriteLine("\t\t\tHIỂN THỊ THÔNG TIN NHÀ CUNG CẤP");
            Console.WriteLine();
            Console.WriteLine("{0,10}|{1,25}|{2,20}|{3,15}", "Mã NCC", "TenNCC", "Dia chi", "So dien thoai");
            List<NCC> list = nhacc.XemDSNhaCC();
            foreach (var ncc in list)
                Console.WriteLine("{0,10}|{1,25}|{2,20}|{3,15}", ncc.mancc, ncc.tenncc, ncc.diachi, ncc.sdt);
           


        }
        public void Sua()
        {
            Console.Clear();
            Console.WriteLine("\t\tSỬA THÔNG TIN NHÀ CUNG CẤP");
            List<NCC> list = nhacc.XemDSNhaCC();
            int mancc;
            Console.Write("Nhập mã nhà cung cấp cần sửa:");
            mancc= int.Parse(Console.ReadLine());
            int i = 0;
            for (i = 0; i < list.Count; ++i)
                if (list[i].mancc == mancc) break;

            if (i < list.Count)
            {
                NCC ncc = new NCC(list[i]);
                Console.Write("Nhập tên nhà cung cấp mới :");
                string tenncc = Console.ReadLine();
                if (!string.IsNullOrEmpty(tenncc)) ncc.tenncc = tenncc;
                Console.Write("Địa chỉ mới:");
                string dc = Console.ReadLine();
                if (!string.IsNullOrEmpty(dc)) ncc.diachi = dc;
                Console.Write("Số điện thoại mới:");
                string sodt = Console.ReadLine();
                if (!string.IsNullOrEmpty(sodt)) ncc.sdt = sodt;
                nhacc.SuaNhaCC(ncc);



            }
            else
            {
                Console.WriteLine("Không tồn tại nhà cung cấp này");
            }
        }
        public void Xoa()
        {
            Console.Clear();
            Console.WriteLine("XÓA THÔNG TIN NHÀ CUNG CẤP");
            List<NCC> list = nhacc.XemDSNhaCC();
            int mancc;
            Console.Write("Nhập mã nhà cung cấp cần xóa:");
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
                Console.WriteLine("Không tồn tại mã nhà cung cấp này");
            }

        }
        public void TimKiem()
        {
            Console.Clear();
            Console.WriteLine("TÌM KIẾM NHÀ CUNG CẤP");
            List<NCC> list = nhacc.XemDSNhaCC();

            Console.WriteLine("Nhập tên nhà cung cấp cần tìm kiếm"); string tt = Console.ReadLine();
            int i = 0;
            for (i = 0; i < list.Count; i++)
                if (list[i].tenncc == tt || list[i].diachi == tt || list[i].sdt== tt) break;
            if (i < list.Count)
            {
                List<NCC> nc = nhacc.TimNhaCC(new NCC(list[i]));
                foreach (var x in nc)

                    Console.WriteLine(x.mancc + "\t" + x.tenncc + "\t" + x.diachi + "\t" + x.sdt+ "\t" );
            }

            else Console.WriteLine("Thông tin nhà cung cấp không tồn tại");
        }
        public void Menu()
        {
            do
            {
                Console.Clear();
                Console.WriteLine("\t\t\t\t\t****************************************************");
                Console.WriteLine("\t\t\t\t\t*          QUẢN LÝ THÔNG TIN NHÀ CUNG CẤP          *");
                Console.WriteLine("\t\t\t\t\t*              1.Nhập nhà cung cấp                 *");
                Console.WriteLine("\t\t\t\t\t*              2.Sửa nhà cung cấp                  *");
                Console.WriteLine("\t\t\t\t\t*              3.Xóa nhà cung cấp                  *");
                Console.WriteLine("\t\t\t\t\t*              4.Hiện danh sách nhà cung cấp       *");
                Console.WriteLine("\t\t\t\t\t*              5.Tìm kiếm                          *");
                Console.WriteLine("\t\t\t\t\t*              6.Back                              *");
                Console.WriteLine("\t\t\t\t\t****************************************************");
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


