using ProjetoDesenvolvedor.IO.Data.Dtos.Fornecedor;
using ProjetoDesenvolvedor.IO.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoDesenvolvedor.IO.Data.Dtos.Endereco
{
    public class BaseEnderecoDto
    {
        public string Rua { get; set; }

        public int Numero { get; set; }

        public string Cidade { get; set; }

        public EUfEstado Estado { get; set; }
    }
}
