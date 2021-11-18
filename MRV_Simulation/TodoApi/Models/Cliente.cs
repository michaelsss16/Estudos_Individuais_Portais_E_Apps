using System;
namespace TodoApi.Models
{
    public class Cliente
    {
        public long Id { get; set; }
        public long CPF { set; get; }
        public string Nome { get; set; }
        public Guid Identificador { set; get; }
    }
}