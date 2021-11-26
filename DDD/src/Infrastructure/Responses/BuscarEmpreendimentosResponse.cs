using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Responses
{
    public class BuscarEmpreendimentosResponse
    {
        public string Status { get; set; }

        public IEnumerable<dynamic> Dados { get; set; }
    }
}
