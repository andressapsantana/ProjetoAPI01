    using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoAPI01.Repository.Interfaces
{
    public interface IBaseRepository <T>

    {
        void Create(T obj);
        void Update(T obj);
        void Delete(T obj);

        List<T> GetAll();
        T GetById(Guid id);

    }
}
