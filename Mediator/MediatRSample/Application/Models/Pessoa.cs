/*
 * Classe que implementa a entidade de uso do projeto. Contém apenas os atributos da classe Pessoa.
 * Denominada classe de domínio.
 * Não são necessárias dependências.
 * */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MediatRSample.Application.Models
{
    public class Pessoa
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public int Idade { get; set; }
        public char Sexo { get; set; }
    }

}