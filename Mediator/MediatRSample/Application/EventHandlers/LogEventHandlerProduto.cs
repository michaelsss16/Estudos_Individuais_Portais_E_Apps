/**
 * Classe definida para escutar todas as notificações enviadas no projeto e escrever as informações no console do projeto.
 * Na definição, faz referência a todas as notificações implementadas  e faz o tratamento de cada uma delas em seu corpo
 * Depende de todas as classes implementadas e da biblioteca MediatR
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Threading;
using MediatR;
using MediatRSample.Application.Commands;
using MediatRSample.Application.Models;
using MediatRSample.Application.Notifications;

namespace MediatRSample.Application.EventHandlers
{
    public class LogEventHandlerProduto :
                            INotificationHandler<ProdutoCriadoNotification>,
                            INotificationHandler<ProdutoAlteradoNotification>,
                            INotificationHandler<ProdutoExcluidoNotification>,
                            INotificationHandler<ErroNotification>
    {
        public Task Handle(ProdutoCriadoNotification notification, CancellationToken cancellationToken)
        {
            return Task.Run(() =>
            {
                Console.WriteLine($"CRIACAO: '{notification.Id} - {notification.Nome} - {notification.Descricao} - {notification.Valor}'");
            });
        }

        public Task Handle(ProdutoAlteradoNotification notification, CancellationToken cancellationToken)
        {
            return Task.Run(() =>
            {
                Console.WriteLine($"ALTERACAO: '{notification.Id} - {notification.Nome} - {notification.Descricao} - {notification.Valor} - {notification.IsEfetivado}'");
            });
        }

        public Task Handle(ProdutoExcluidoNotification notification , CancellationToken cancellationToken)
        {
            return Task.Run(() =>
            {
                Console.WriteLine($"EXCLUSAO: '{notification.Id} - {notification.IsEfetivado}'");
            });
        }

        public Task Handle(ErroNotification notification, CancellationToken cancellationToken)
        {
            return Task.Run(() =>
            {
                Console.WriteLine($"ERRO: '{notification.Excecao} \n {notification.PilhaErro}'");
            });
        }
    }

}
