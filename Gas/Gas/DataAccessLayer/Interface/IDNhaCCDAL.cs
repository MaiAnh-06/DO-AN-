using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GAS.Entites;


namespace GAS.DataAccessLayer
{
    public interface IDNhaCCDAL
    {
        List<NCC> GetData();
        void Insert(NCC nc);
        void Update(List<NCC> list);
    }
}

