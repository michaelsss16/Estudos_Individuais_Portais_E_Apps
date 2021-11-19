/*
 * Interface para o repositório de pessoas.
 * Define os métodos que devem ser implementados no repositório e os tipo de retorno.
 * Diferente do projeto original, a task assíncrona de adição de novas entidades possui retorno do tipo "Pessoa". Os outros métodos permanecem inalterados.
 * A implementação não depende de nenhuma classe externa 
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace MediatRSample.Application.Models
{
    public interface IRepository<T>
    {
        Task<IEnumerable<T>> GetAll();

        Task<T> Get(int id);

        Task<T> Add(T item);

        Task Edit(T item);

        Task Delete(int id);
    }

}
