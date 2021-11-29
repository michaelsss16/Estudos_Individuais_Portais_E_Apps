using System;
using System.Collections.Generic;
using Domain.Entities.Interfaces;

namespace Domain.Entities
{
    public class EmpreendimentoComercial : IEmpreendimento
    {
        public int Id { set; get; }

        public string Nome { set; get; }

        public double Valor { set; get; }

public double Area { set; get; }
    }
}
