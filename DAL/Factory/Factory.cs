using DAL.Contracts;
using Dominio;
using DOMINIO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Factory
{
	public sealed class Factory
	{
		#region Singleton
		private static readonly Factory _instance = new Factory();
		private Factory()
		{
		}
		public static Factory Current
		{
			get { return _instance; }
		}
		#endregion
		public IRepositoryCliente<Cliente> GetRepositoryCliente()
		{

			// string namespacename = ConfigurationManager.AppSettings["RepositorioSQL"] + ".ClienteRepository";
			string namespacename = "DAL.Repositories.SQL.ClienteRepository";

			object instancia = Activator.CreateInstance(Type.GetType(namespacename));

			return (IRepositoryCliente<Cliente>)instancia;

		}

		public IRepositoryCliente<Cliente> GetRepositoryClienteFireBase()
		{

			// string namespacename = ConfigurationManager.AppSettings["RepositorioSQL"] + ".ClienteRepository";
			string namespacename = "DAL.Repositories.FireBase.ClienteRepository";

			object instancia = Activator.CreateInstance(Type.GetType(namespacename));

			return (IRepositoryCliente<Cliente>)instancia;

		}

		public IRepositoryEvento<Evento> GetRepositoryEvento()
        {
			string namespacename = "DAL.Repositories.SQL.EventoRepository";

			object instancia = Activator.CreateInstance(Type.GetType(namespacename));

			return (IRepositoryEvento<Evento>)instancia;
		}

		public IRepositoryInvitado<Invitado> GetRepositoryInvitado()
		{
			string namespacename = "DAL.Repositories.SQL.InvitadoRepository";

			object instancia = Activator.CreateInstance(Type.GetType(namespacename));

			return (IRepositoryInvitado<Invitado>)instancia;
		}

		public IRepositoryServicio<Servicio> GetRepositoryServicio()
		{
			string namespacename = "DAL.Repositories.SQL.ServicioRepository";

			object instancia = Activator.CreateInstance(Type.GetType(namespacename));

			return (IRepositoryServicio<Servicio>)instancia;
		}

	}
}
