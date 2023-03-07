using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoProjAppSys.Interface
{
    public interface IProductCheckOut
    {
        void Scan(string sku);
        void TotalPayAmount();
    }
}
