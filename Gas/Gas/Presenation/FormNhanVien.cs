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
            Console.WriteLine("NHAP THONG TIN NHAN VIEN");
            NhanVien nv = new NhanVien();
            Console.Write("Nhap ma nhan vien:"); nv.manv = int.Parse(Console.ReadLine());
            Console.Write("Nhap ten nhan vien:"); nv.tennv = Console.ReadLine();
            Console.Write("Nhap ngay sinh :"); nv.ngaysinh = (Console.ReadLine());
            Console.Write("Nhap gioi tinh :"); nv.gt = Console.ReadLine();
            Console.Write("Nhap ngay vao lam viec:"); nv.ngayvaolam = Console.ReadLine();

            nhanvien.ThemNhanVien(nv);
        }
        public void Hien()
        {
            Console.Clear();
            Console.WriteLine("\t\t\t\t HIEN THI THONG TIN NHAN VIEN ");
            Console.WriteLine("");
            List<NhanVien> list = nhanvien.XemDSNhanVien();
            foreach (var nv in list)
                Console.WriteLine(nv.manv + "\t\t" + nv.tennv + "\t\t" + nv.ngaysinh + "\t\t" + nv.gt + "\t\t" + nv.ngayvaolam);
        }
        public void Sua()
        {
            Console.Clear();
            Console.WriteLine("SUA THONG TIN KHACH HANG");
            List<NhanVien> list = nhanvien.XemDSNhanVien();
            int manv;
            Console.Write("Nhap ma nhan vien can sua:");
            manv = int.Parse(Console.ReadLine());
            int i = 0;
            for (i = 0; i < list.Count; ++i)
                if (list[i].manv == manv) break;

            if (i < list.Count)
            {
                NhanVien nv = new NhanVien(list[i]);
                Console.Write("Nhap ma nhan vien moi:");
                int mas = int.Parse(Console.ReadLine());
                if (mas > 0) nv.manv = mas;
                Console.Write("Nhap ho ten nhan vien moi:");
                string ten = Console.ReadLine();
                if (!string.IsNullOrEmpty(ten)) nv.tennv = ten;
                Console.Write("Nhap lai ngay vao lam viec:");
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
            Console.WriteLine("Xóa THÔNG TIN NHAN VIEN");
            List<NhanVien> list = nhanvien.XemDSNhanVien();
            int manv;
            Console.Write("Nhập mã nhan vien cần xóa:");
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
                Console.WriteLine("Không tồn tại mã nhan vien này");
            }

        }
        public void TimKiem()
        {
            Console.Clear();
            Console.WriteLine("Tim kiem  nhan vien");
            List<NhanVien> list = nhanvien.XemDSNhanVien();

            Console.WriteLine("Nhap thong tin nhan vien can tim kiem"); string tt = Console.ReadLine();
            int i = 0;
            for (i = 0; i < list.Count; i++)
                if (list[i].tennv == tt || list[i].ngaysinh == tt || list[i].gt == tt || list[i].ngayvaolam == tt) break;
            if (i < list.Count)
            {
                List<NhanVien> nv = nhanvien.TimNhanVien(new NhanVien(list[i]));
                foreach (var x in nv)

                    Console.WriteLine(x.manv + "\t" + x.tennv + "\t" + x.ngaysinh + "\t" + x.gt + "\t" + x.ngayvaolam);
            }

            else Console.WriteLine("Thong tin nhan vien  nay k ton tai");
        }
        public void Menu()
        {
            do
            {
                Console.Clear();
                Console.WriteLine("\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t");
                Console.WriteLine("\t\t\t\t|---------------------------------------------------|");
                Console.WriteLine("\t\t\t\t|         QUAN LY THONG TIN NHAN VIEN               |");
                Console.WriteLine("\t\t\t\t|               1.Nhap nhan vien                    |");
                Console.WriteLine("\t\t\t\t|               2.Sua nhan vien                     |");
                Console.WriteLine("\t\t\t\t|               3.Xoa nhan vien                     |");
                Console.WriteLine("\t\t\t\t|               4.Hien danh sach                    |");
                Console.WriteLine("\t\t\t\t|               5.Tim kiem                          |");
                Console.WriteLine("\t\t\t\t|               6.Back                              |");
                Console.WriteLine("\t\t\t\t|---------------------------------------------------|");

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

    



