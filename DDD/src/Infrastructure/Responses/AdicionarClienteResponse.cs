﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Responses
{
    public class AdicionarClienteResponse
    {
        public string Status { get; set; }
        public DadosCliente Dados { set; get; }
    }
}
