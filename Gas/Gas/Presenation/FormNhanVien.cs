using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gas.BusinessLayer.Interface;
using Gas.BusinessLayer;
using Gas.Entites;

namespace GAS.Presenation
{
    public class FormNhanVien
    {
        private IFNhanVienBLL nhanvien = new NhanVienBLL();
        public void Nhap()
        {
            Console.Clear();
            Console.WriteLine("NHẬP THÔNG TIN NHÂN VIÊN");
            NhanVien nv = new NhanVien();
            Console.Write("Nhập mã nhân viên:"); nv.manv = int.Parse(Console.ReadLine());
            Console.Write("Nhập tên nhân viên:"); nv.tennv = Console.ReadLine();
            Console.Write("Nhập ngày sinh  :"); nv.ngaysinh = (Console.ReadLine());
            Console.Write("Nhập giới tính :"); nv.gt = Console.ReadLine();
            Console.Write("Nhập ngày vào làm việc:"); nv.ngayvaolam = Console.ReadLine();

            nhanvien.ThemNhanVien(nv);
        }
        public void Hien()
        {
            Console.Clear();
            Console.WriteLine("\t\t\t\t HIỂN THỊ THÔNG TIN NHÂN VIÊN ");
            Console.WriteLine("");
            Console.WriteLine("{0,15}|{1,25}|{2,20}|{3,10}|{4,15}","Mã Nhân Viên","Tên nhân viên","Ngày sinh","Giới tính","Ngày vào làm việc");
            List<NhanVien> list = nhanvien.XemDSNhanVien();
            foreach (var nv in list)
                Console.WriteLine("{0,15}|{1,25}|{2,20}|{3,10}|{4,15}", nv.manv,nv.tennv , nv.ngaysinh,nv.gt , nv.ngayvaolam);
        }
        public void Sua()
        {
            Console.Clear();
            Console.WriteLine("SỬA THÔNG TIN NHÂN VIÊN  ");
            List<NhanVien> list = nhanvien.XemDSNhanVien();
            int manv;
            Console.Write("Nhập mã nhân viên cần sửa:");
            manv = int.Parse(Console.ReadLine());
            int i = 0;
            for (i = 0; i < list.Count; ++i)
                if (list[i].manv == manv) break;

            if (i < list.Count)
            {
                NhanVien nv = new NhanVien(list[i]);
                Console.Write("Nhap lai tên nhân viên:");
                string ten= Console.ReadLine();
                if (!string.IsNullOrEmpty(ten)) nv.tennv = ten;
                Console.Write("Nhập ngày sinh mới:");
                string ns = Console.ReadLine();
                if (!string.IsNullOrEmpty(ns)) nv.ngaysinh = ns;
                Console.Write("Nhập lại  giới tính:");
                string gtinh = Console.ReadLine();
                if (!string.IsNullOrEmpty(gtinh)) nv.gt= gtinh;
                Console.Write("Nhập lại ngày vào làm việc:");
                string nlv = Console.ReadLine();
                if (!string.IsNullOrEmpty(nlv)) nv.ngayvaolam = nlv;

                nhanvien.SuaNhanVien(nv);
            }
            else
            {
                Console.WriteLine("Khong ton tai ma nhan vien nay");
            }
        }

        public void Xoa()
        {
            Console.Clear();
            Console.WriteLine("XÓA THÔNG TIN NHÂN VIÊN ");
            List<NhanVien> list = nhanvien.XemDSNhanVien();
            int manv;
            Console.Write("Nhập mã nhân viên  cần xóa:");
            manv = int.Parse(Console.ReadLine());
            int i = 0;
            for (i = 0; i < list.Count; ++i)
            {
                if (list[i].manv == manv)
                {
                    break;
                }
            }

            if (i < list.Count)
            {
                NhanVien nv = new NhanVien(list[i]);
                nhanvien.XoaNhanVien(manv);
            }
            else
            {
                Console.WriteLine("Không tồn tại mã nhân viên này");
            }

        }
        public void TimKiem()
        {
            Console.Clear();
            Console.WriteLine("TÌM KIẾM NHÂN VIÊN ");
            List<NhanVien> list = nhanvien.XemDSNhanVien();

            Console.WriteLine("Nhập Tên nhân viên cần tìm kiếm"); string tt = Console.ReadLine();
            int i = 0;
            for (i = 0; i < list.Count; i++)
                if (list[i].tennv == tt || list[i].ngaysinh == tt || list[i].gt == tt || list[i].ngayvaolam == tt) break;
            if (i < list.Count)
            {
                List<NhanVien> nv = nhanvien.TimNhanVien(new NhanVien(list[i]));
                foreach (var x in nv)

                    Console.WriteLine(x.manv + "\t" + x.tennv + "\t" + x.ngaysinh + "\t" + x.gt + "\t" + x.ngayvaolam);
            }

            else Console.WriteLine("Thông tin nhân viên này không tồn tại");
        }
        public void Menu()
        {
            do
            {
                Console.Clear();
                Console.WriteLine("\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t");
                Console.WriteLine("\t\t\t\t|---------------------------------------------------|");
                Console.WriteLine("\t\t\t\t|         QUẢN LÝ THÔNG TIN NHÂN VIÊN               |");
                Console.WriteLine("\t\t\t\t|               1.Nhập nhân viên                    |");
                Console.WriteLine("\t\t\t\t|               2.Sửa nhân viên                     |");
                Console.WriteLine("\t\t\t\t|               3.Xóa nhân viên                     |");
                Console.WriteLine("\t\t\t\t|               4.Hiện danh sách                    |");
                Console.WriteLine("\t\t\t\t|               5.Tìm kiếm                          |");
                Console.WriteLine("\t\t\t\t|               6.Back                              |");
                Console.WriteLine("\t\t\t\t|---------------------------------------------------|");

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

    



