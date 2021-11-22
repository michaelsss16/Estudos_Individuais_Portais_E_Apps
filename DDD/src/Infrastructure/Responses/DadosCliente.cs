using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Responses
{
    public class DadosCliente
    {
        public long Id { get; set; }
        public long CPF { set; get; }
        public string Nome { get; set; }
        public Guid Identificador { set; get; }
    }
}
