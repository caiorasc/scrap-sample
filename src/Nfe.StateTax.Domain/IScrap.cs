using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nfe.StateTax.Domain
{
    interface IScrap
    {
        Task<string> PreScrap();
        //Task<string> Scrap(long cnpj);
        Task<InfoCnpj> Scrap(long cnpj);
    }
}
