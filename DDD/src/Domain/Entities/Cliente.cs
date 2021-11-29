using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities.Interfaces;

namespace Domain.Entities
{
    public class Cliente : ICliente
    {
        public int Id { get; set; }

        public long CPF { set; get; }

        public string Nome { get; set; }

        public Guid Identificador { set; get; }
    }
}
