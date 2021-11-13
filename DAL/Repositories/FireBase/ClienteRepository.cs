using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FireSharp.Interfaces;
using FireSharp.Config;
using FireSharp.Response;
using DAL.Contracts;
using Dominio;
using SERVICIOS;

namespace DAL.Repositories.FireBase
{
    internal class ClienteRepository : IRepositoryCliente<Cliente>
    {
        IFirebaseConfig ConexionFireBase = ApplicationSettings.Current.ConexionFireBase;
        public void Add(Cliente cliente)
        {
            cliente.CUIT = 12345;
            cliente.RazonSocial = "Prueba de Firebase 2";
            cliente.Saldo = 100;
            cliente.nombre = "Pepe";
            cliente.apellido = "Argento";

            IFirebaseClient client = new FireSharp.FirebaseClient(ConexionFireBase);
            var setter = client.Set("ClientList/" + cliente.CUIT, cliente);
        }

        public IEnumerable<Cliente> GetAll()
        {
            // IFirebaseClient client = new FireSharp.FirebaseClient(fcon);
            // var setter = client.

            throw new NotImplementedException();
        }

        public IEnumerable<Cliente> GetOne(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Cliente cliente)
        {
            throw new NotImplementedException();
        }
    }
}
