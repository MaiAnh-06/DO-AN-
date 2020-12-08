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
                Console.WriteLine("\t\t\t\t************************************\t\t\t");
                Console.WriteLine("\t\t\t\t*           QUAN LY BAN GAS        *\t\t\t");
                Console.WriteLine("\t\t\t\t*        1.Quan ly hang hoa        *\t\t\t");
                Console.WriteLine("\t\t\t\t*        2.Quan ly nha cung cap     *\t\t\t");
                Console.WriteLine("\t\t\t\t*        3.Quan ly nhan vien        *\t\t\t");
                Console.WriteLine("\t\t\t\t*        4.Quan ly hoa don ban      *\t\t\t");
                Console.WriteLine("\t\t\t\t*        5.Quan ly hoa don nhap     *\t\t\t");
                Console.WriteLine("\t\t\t\t*        6.Ket thuc                *\t\t\t");
                Console.WriteLine("\t\t\t\t************************************\t\t\t");
                Console.WriteLine("Nhap n");
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
                        FormHDB frm4 = new FormHDB();
                }
            } while (true);
        }

        static void Main(string[] args)
        {
            Menu();
        }
    }
}
