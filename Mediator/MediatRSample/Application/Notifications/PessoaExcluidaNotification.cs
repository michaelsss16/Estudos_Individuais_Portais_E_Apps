using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;

namespace MediatRSample.Application.Notifications
{
    public class PessoaExcluidaNotification : INotification
    {
        public int Id { get; set; }
        public bool IsEfetivado { get; set; }
    }

}
