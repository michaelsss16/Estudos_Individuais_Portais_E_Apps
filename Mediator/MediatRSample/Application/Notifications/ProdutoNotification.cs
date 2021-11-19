using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;

namespace MediatRSample.Application.Notifications
{
    public class ProdutoAlteradoNotification : INotification
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descricao{ get; set; }
        public double Valor { get; set; }
        public bool IsEfetivado { get; set; }
    }
    public class ProdutoCriadoNotification: INotification
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public double Valor { get; set; }
    }
    public class ProdutoExcluidoNotification: INotification
    {
        public int Id { get; set; }
        public bool IsEfetivado { get; set; }
    }




}
