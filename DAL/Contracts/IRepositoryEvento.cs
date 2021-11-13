using DOMINIO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Contracts
{
    public interface IRepositoryEvento<Evento>
    {
        void Add(Evento evento);
        void Update(Evento evento);
        IEnumerable<Evento> GetAll();
        IEnumerable<Evento> GetOne(int id);

    }
}
