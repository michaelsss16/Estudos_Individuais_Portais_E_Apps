using System;
using System.Collections.Generic;

namespace Domain.Entities.Interfaces
{
    public interface IEmpreendimento
    {
        public int Id { set; get; }

        public string Nome { set; get; }

        public double Valor { set; get; }
    }
}
