﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;

namespace MediatRSample.Application.Commands
{
    public class AlteraPessoaCommand : IRequest<string>
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public int Idade { get; set; }
        public char Sexo { get; set; }
    }

}
