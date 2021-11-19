/* 
 * Definição de classe estática para armazenar as entidades adicionadas.
 * Definida a partir da interface IRepository, que determina os métodos a serem implementados.
 * Nessa classe que são definidas as operações de manipulação a uma coleção que armazena os dados provenientes das chamadas a API Ou seja, aqui são definidos os métodos utilizados para manipulação de dados por parte do controlador/chamadas para a API.
 * Diferente do projeto original, o método assíncrono de adição possui retorno de objeto do tipo Produto.
 * O mesmo método possui modificação durante a interação com o atributo id do objeto pessoa. Uma variável inteira é utilizada para incrementar o id da entidade adicionada a cada chamada ao método
 * As definições não dependem de nenhuma classe externa ao namespace Application.Models ou a biblioteca MediatR
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MediatRSample.Application.Models
{
    public class ProdutoRepository: IRepository<Produto>
    {
        private int Quantidade = 0;
        private static Dictionary<int, Produto> produtos= new Dictionary<int, Produto>();

        public async Task<IEnumerable<Produto>> GetAll()
        {
            return await Task.Run(() => produtos.Values.ToList());
        }

        public async Task<Produto> Get(int id)
        {
            return await Task.Run(() => produtos.GetValueOrDefault(id));
        }

        public async Task<Produto> Add(Produto produto)
        {
            produto.Id = Quantidade;
            await Task.Run(() => produtos.Add(produto.Id, produto));
            Quantidade++;
            return produto;
        }

        public async Task Edit(Produto produto)
        {
            await Task.Run(() =>
            {
                produtos.Remove(produto.Id);
                produtos.Add(produto.Id, produto);
            });
        }

        public async Task Delete(int id)
        {
            await Task.Run(() => produtos.Remove(id));
        }
    }

}
