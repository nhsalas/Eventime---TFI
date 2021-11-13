using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DOMINIO;

namespace DAL.Contracts
{
    public interface IRepositoryInvitado<Invitado>
    {
        void Add(Invitado invitado);
        void Update(Invitado invitado);
        IEnumerable<Invitado> GetAll();
        IEnumerable<Invitado> GetOne(int id);
    }
}
