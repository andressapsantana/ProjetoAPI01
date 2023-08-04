using ProjetoAPI01.Repository.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoAPI01.Repository.Interfaces
{
    public interface IClienteRepository : IBaseRepository<Cliente>
    {
        Cliente GetByEmail(string email);

    }
}
