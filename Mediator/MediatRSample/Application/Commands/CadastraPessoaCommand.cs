
/*
 * Classe definida para o padrão cqrs, referente aos comandos. Define apenas os atributos necessários para a execução do comando associado.
 * A implementação da lógica e manipulação das informações fica a cargo dos commandHandlers
Depende da interface IRequests, definida pela biblioteca MediatR, a qual depende, para ser utilizada como ligação ao commandHandler. É atribuido, adicionalmente, o tipo de retorno do command.
Depende somente da importação da biblioteca MediatR, para implementar o padrão Mediator.
O mesmo acontece para todas as classes definidas dentro da pasta/diretório (Application.Commands)* 
Verificar que os atributos da classe são as entradas para a chamada da API
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;

namespace MediatRSample.Application.Commands
{
    public class CadastraPessoaCommand : IRequest<string>
    {
        public string Nome { get; set; }
        public int Idade { get; set; }
        public char Sexo { get; set; }
    }

}
