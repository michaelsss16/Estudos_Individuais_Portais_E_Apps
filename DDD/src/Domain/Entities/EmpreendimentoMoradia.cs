using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class EmpreendimentoMoradia : IEmpreendimento
    {
        public int Id { set; get; }
        public string Nome { set; get; }
        public double Valor { set; get; }
        public int QuantidadeDeQuartos { set; get; }
    }
}
