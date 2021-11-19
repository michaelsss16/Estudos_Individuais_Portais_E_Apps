using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;

namespace MediatRSample.Application.Commands
{
    public class AlteraProdutoCommand : IRequest<string>
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public double Valor { get; set; }
    }

    public class CadastraProdutoCommand: IRequest<string>
    {
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public double Valor { get; set; }
    }

    public class ExcluiProdutoCommand : IRequest<string> { 
    public int Id { get; set; }
    }
}