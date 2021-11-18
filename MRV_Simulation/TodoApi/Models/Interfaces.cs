using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TodoApi.Models
{
    public interface ICompras { 
    long Id { set; get; }
        string Nome { set; get; }
    }
    public interface IEmpreendimentos
    {
        long Id { set; get; }
        string Nome { set; get; }
        double Valor { set; get; }
    }
}
