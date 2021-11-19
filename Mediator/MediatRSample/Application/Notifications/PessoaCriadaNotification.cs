/*
 * Classe DEFINIDA PARA RETORNAR INFORMAÇÕES SOBRE o  SUCESSO DA OPERAÇÃO DEFINIDA PELO COMMANDhANDLER DE ADIÇÃO DE NOVA ENTIDADE NO REPOSITÓRIO.
 * Depende somente da biblioteca MediatR para sua implementação
 * Definido a partir da interface MediatR INotification
 * Implementa somente os atributos do objeto referente a notificação
 * Nas notificações de alteração de informações e exclusão de pessoa, um atributo adicional de validação é presente, diferente da notificação de adição de novo item
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;

namespace MediatRSample.Application.Notifications
{
    public class PessoaCriadaNotification : INotification
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public int Idade { get; set; }
        public char Sexo { get; set; }
    }
    
}
