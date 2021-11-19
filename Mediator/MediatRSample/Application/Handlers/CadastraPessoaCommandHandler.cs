/*
 * Implementa a lógica por trás da chamada de adição de nova entidade para o repositório de pessoas
Na linha 16, tenho a ligação com o command associado, com o tipo de retorno deste.
Depende da biblioteca Mediator, dos commands, notificações e modelos implementados nos outros namespaces
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

namespace MediatRSample.Application.Handlers
{
    // Associação ao command de adição 
    public class CadastraPessoaCommandHandler : IRequestHandler<CadastraPessoaCommand, string>
    {
        public int Quantidade = 0; //Adicionada para controle de id
        // Implementação para inversão de controle
        private readonly IMediator _mediator;
        private readonly IRepository<Pessoa> _repository;
        // Definição de controlador com ioc
        public CadastraPessoaCommandHandler(IMediator mediator, IRepository<Pessoa> repository)
        {
            this._mediator = mediator;
            this._repository = repository;
        }

        public async Task<string> Handle(CadastraPessoaCommand request, CancellationToken cancellationToken)
        {
            
            var pessoa = new Pessoa { Id = Quantidade, Nome = request.Nome, Idade = request.Idade, Sexo = request.Sexo };// oBJETO REQUEST PROVENIENTE DE PARÂMETROS DE ENTRADA
            
            try
            {
                pessoa = await _repository.Add(pessoa); // cHAMADA AO MÉTODO ADD DO REPOSITÓRIO DEFINIDO NO CONSTRUTUOR
                await _mediator.Publish(new PessoaCriadaNotification { Id = pessoa.Id, Nome = pessoa.Nome, Idade = pessoa.Idade, Sexo = pessoa.Sexo }); // eNVIO DE NOTIFICAÇÃO SOBRE O PROCESSO REALIZADO  PARA O SISTEMA,
                return await Task.FromResult("Pessoa criada com sucesso"); // dEFINIÇÃO DE RETORNO DA TASK CONFORME CABEÇALHO DEFINIDO 
            }
            catch (Exception ex)
            {
                await _mediator.Publish(new PessoaCriadaNotification { Id = pessoa.Id, Nome = pessoa.Nome, Idade = pessoa.Idade, Sexo = pessoa.Sexo });
                await _mediator.Publish(new ErroNotification { Excecao = ex.Message, PilhaErro = ex.StackTrace }); // eNVIO DE NOTIFICAÇÃO DE ERRO PARA O CASO DE PROBLEMAS NA ADIÇÃO DA ENTIDADE NO REPOSITÓRIO 
                return await Task.FromResult("Ocorreu um erro no momento da criação");
            }

        }
    }

}
