using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoAPI01.Repository.Entities
{
    public class Cliente
    {
     public Guid IdCliente { get; set; }
     public string Nome { get; set; }
     public string Email { get; set; }
     public DateTime DataCadastro { get; set; }
    }
}
