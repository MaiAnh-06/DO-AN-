using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GAS.Presenation;

namespace GAS
{
    public class Program
    {
        public static void Menu()
        {
            do
            {
                Console.Clear();
                Console.WriteLine("");
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine("\t\t\t\t************************************************************\t\t\t");
                Console.WriteLine("\t\t\t\t*                     QUẢN LÝ BÁN GAS                      *\t\t\t");
                Console.WriteLine("\t\t\t\t*                 1.Quản lý Hàng hóa                       *\t\t\t");
                Console.WriteLine("\t\t\t\t*                 2.Quản lý Nhà cung cấp                   *\t\t\t");
                Console.WriteLine("\t\t\t\t*                 3.Quản lý Nhân viên                      *\t\t\t");
                Console.WriteLine("\t\t\t\t*                 4.Quản lý Hóa đơn Nhập                   *\t\t\t");
                Console.WriteLine("\t\t\t\t*                 5.Quản lý Hóa đơn Bán                    *\t\t\t");
                Console.WriteLine("\t\t\t\t*                 6.Kết Thúc                               *\t\t\t");
                Console.WriteLine("\t\t\t\t************************************************************\t\t\t");
                Console.WriteLine("Chon thong tin:");
                int n = int.Parse(Console.ReadLine());
                switch (n)
                {
                    case 1:
                        FormHangHoa frm = new FormHangHoa();
                        frm.Menu();
                        break;
                    case 2:
                        FormNCC frm2 = new FormNCC();
                        frm2.Menu();
                        break;
                    case 3:
                        FormNhanVien frm3 = new FormNhanVien();
                        frm3.Menu();
                        break;
                    case 4:
                        FormHDN frm4 = new FormHDN();
                        frm4.Menu();
                        break;

                    case 5:
                        FormHDB frm5 = new FormHDB();
                        frm5.Menu();
                        break;
                    case 6:
                        break;
                        
                   
                }
            } while (true);
        }

        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.InputEncoding = Encoding.Unicode;
            Menu();
        }
    }
}
