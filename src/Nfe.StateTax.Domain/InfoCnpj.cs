using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nfe.StateTax.Domain
{
    public class InfoCnpj
    {
        public long NumeroIncricao { get; set; }
        public string SituacaoCadastral { get; set; }
        public string UfOrigem { get; set; }
        public long FederalNumber { get; set; }
        public string NomeFantasia { get; set; }
        public string NomeEmpresarial { get; set; }
    }
}
