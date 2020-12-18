
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GAS.Entites;
namespace GAS.DataAccessLayer
{
    public interface IDHangHoaDAL
    {
        List<HangHoa> GetData();
        void Insert(HangHoa hh);
        void Update(List<HangHoa> list);
    }
}

