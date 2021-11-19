/* 
 * Definição de classe estática para armazenar as entidades adicionadas.
 * Definida a partir da interface IRepository, que determina os métodos a serem implementados.
 * Nessa classe que são definidas as operações de manipulação a uma coleção que armazena os dados provenientes das chamadas a API
 * Diferente do projeto original, o método assíncrono de adição possui retorno de objeto do tipo pessoa
 * O mesmo método possui modificação durante a interação com o atributo id do objeto pessoa. Uma variável inteira é utilizada para incrementar o id da entidade adicionada a cada chamada ao método
 * As definições não dependem de nenhuma classe externa ao namespace Application.Models ou a biblioteca MediatR
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MediatRSample.Application.Models
{
    public class PessoaRepository : IRepository<Pessoa>
    {
        public int Quantidade = 0;
        private static Dictionary<int, Pessoa> pessoas = new Dictionary<int, Pessoa>();

        public async Task<IEnumerable<Pessoa>> GetAll()
        {
            return await Task.Run(() => pessoas.Values.ToList());
        }

        public async Task<Pessoa> Get(int id)
        {
            return await Task.Run(() => pessoas.GetValueOrDefault(id));
        }

        public async Task<Pessoa> Add(Pessoa pessoa)
        {
            pessoa.Id = Quantidade;
            await Task.Run(() => pessoas.Add(pessoa.Id, pessoa));
            Quantidade++;
            return pessoa;
        }

        public async Task Edit(Pessoa pessoa)
        {
            await Task.Run(() =>
            {
                pessoas.Remove(pessoa.Id);
                pessoas.Add(pessoa.Id, pessoa);
            });
        }

        public async Task Delete(int id)
        {
            await Task.Run(() => pessoas.Remove(id));
        }
    }

}
