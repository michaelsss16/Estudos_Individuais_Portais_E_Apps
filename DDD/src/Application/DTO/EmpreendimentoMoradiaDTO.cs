using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;

namespace Application.DTO
{
    public class EmpreendimentoMoradiaDTO
    {
        public string Nome { set; get; }

        public double Valor { set; get; }

        public int QuantidadeDeQuartos { set; get; }
    }
}
