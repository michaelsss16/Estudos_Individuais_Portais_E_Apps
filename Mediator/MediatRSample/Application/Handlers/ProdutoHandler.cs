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
    public class AlteraProdutoCommandHandler : IRequestHandler<AlteraProdutoCommand, string>
    {
        private readonly IMediator _mediator;
        private readonly IRepository<Produto> _repository;
        public AlteraProdutoCommandHandler(IMediator mediator, IRepository<Produto> repository)
        {
            this._mediator = mediator;
            this._repository = repository;
        }

        public async Task<string> Handle(AlteraProdutoCommand request, CancellationToken cancellationToken)
        {
            var produto = new Produto{ Id = request.Id, Nome = request.Nome, Descricao= request.Descricao, Valor= request.Valor};

            try
            {
                await _repository.Edit(produto);

                await _mediator.Publish(new ProdutoAlteradoNotification { Id = produto.Id, Nome = produto.Nome, Descricao= produto.Descricao, Valor= produto.Valor, IsEfetivado = true });

                return await Task.FromResult("Produto alterado com sucesso");
            }
            catch (Exception ex)
            {
                await _mediator.Publish(new ProdutoAlteradoNotification { Id = produto.Id, Nome = produto.Nome, Descricao = produto.Descricao, Valor = produto.Valor, IsEfetivado = false});
                await _mediator.Publish(new ErroNotification { Excecao = ex.Message, PilhaErro = ex.StackTrace });
                return await Task.FromResult("Ocorreu um erro no momento da alteração");
            }

        }
    }

    public class CadastraProdutoCommandHandler : IRequestHandler<CadastraProdutoCommand, string>
    {
        public int Quantidade = 0; //Adicionada para controle de id
        // Implementação para inversão de controle
        private readonly IMediator _mediator;
        private readonly IRepository<Produto> _repository;
        // Definição de controlador com ioc
        public CadastraProdutoCommandHandler(IMediator mediator, IRepository<Produto> repository)
        {
            this._mediator = mediator;
            this._repository = repository;
        }

        public async Task<string> Handle(CadastraProdutoCommand request, CancellationToken cancellationToken)
        {

            var produto = new Produto{ Id = Quantidade, Nome = request.Nome, Descricao = request.Descricao, Valor = request.Valor};// oBJETO REQUEST PROVENIENTE DE PARÂMETROS DE ENTRADA

            try
            {
                produto = await _repository.Add(produto); // cHAMADA AO MÉTODO ADD DO REPOSITÓRIO DEFINIDO NO CONSTRUTUOR
                await _mediator.Publish(new ProdutoCriadoNotification{ Id = produto.Id, Nome = produto.Nome, Descricao = produto.Descricao, Valor = produto.Valor}); // eNVIO DE NOTIFICAÇÃO SOBRE O PROCESSO REALIZADO  PARA O SISTEMA,
                return await Task.FromResult("Produto criado com sucesso"); // dEFINIÇÃO DE RETORNO DA TASK CONFORME CABEÇALHO DEFINIDO 
            }
            catch (Exception ex)
            {
                await _mediator.Publish(new ProdutoCriadoNotification{ Id = produto.Id, Nome = produto.Nome, Descricao= produto.Descricao, Valor= produto.Valor});
                await _mediator.Publish(new ErroNotification { Excecao = ex.Message, PilhaErro = ex.StackTrace }); // eNVIO DE NOTIFICAÇÃO DE ERRO PARA O CASO DE PROBLEMAS NA ADIÇÃO DA ENTIDADE NO REPOSITÓRIO 
                return await Task.FromResult("Ocorreu um erro no momento da criação");
            }

        }
    }

    public class ExcluiProdutoCommandHandler: IRequestHandler<ExcluiProdutoCommand, string>
    {
        private readonly IMediator _mediator;
        private readonly IRepository<Produto> _repository;
        public ExcluiProdutoCommandHandler(IMediator mediator, IRepository<Produto> repository)
        {
            this._mediator = mediator;
            this._repository = repository;
        }

        public async Task<string> Handle(ExcluiProdutoCommand request, CancellationToken cancellationToken)
        {
            try
            {
                await _repository.Delete(request.Id);

                await _mediator.Publish(new ProdutoExcluidoNotification{ Id = request.Id, IsEfetivado = true });

                return await Task.FromResult("Produto excluido com sucesso");
            }
            catch (Exception ex)
            {
                await _mediator.Publish(new ProdutoExcluidoNotification{ Id = request.Id, IsEfetivado = false });
                await _mediator.Publish(new ErroNotification { Excecao = ex.Message, PilhaErro = ex.StackTrace });
                return await Task.FromResult("Ocorreu um erro no momento da exclusão");
            }

        }
    }


}
