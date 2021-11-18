using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TodoApi.Models
{
    public class EmpreendimentoMoradia : IEmpreendimentos
    {
        public long Id { set; get; }
        public string Nome { set; get; }
        public double Valor { set; get; }
        public int NumeroDeQuartos { set; get; }
    }
}
