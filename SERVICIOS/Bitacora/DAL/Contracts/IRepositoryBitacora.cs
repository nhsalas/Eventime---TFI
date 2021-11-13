using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SERVICIOS.Bitacora.DAL.Contracts
{
    public interface IRepositoryBitacora<Bitacora>
    {
        void Add(Bitacora bitacora);
        void Update(Bitacora bitacora);
        IEnumerable<Bitacora> GetAll();
        IEnumerable<Bitacora> GetOne(Guid id);
    }
}
