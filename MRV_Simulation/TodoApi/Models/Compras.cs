using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TodoApi.Models
{
    public class Compras : ICompras
    {
        public long Id{ set; get; }
        public string Nome { set; get; }
    }
}
