using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Contracts
{
    public interface IRepositoryCliente<Cliente>
    {
        void Add(Cliente cliente);
        void Update(Cliente cliente);
        IEnumerable<Cliente> GetAll();
        IEnumerable<Cliente> GetOne(int id);
    }
}
