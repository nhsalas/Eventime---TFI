using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Contracts
{
    public interface IRepositoryServicio<Servicio>
    {
        void Add(Servicio servicio);
        void Update(Servicio servicio);
        IEnumerable<Servicio> GetAll();
        IEnumerable<Servicio> GetOne(int id);
    }
}
