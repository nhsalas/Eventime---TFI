using DAL.Factory;
using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SERVICIOS.Bitacora.Dominio;
using SERVICIOS.Bitacora.BLL;
using SERVICIOS.Bitacora.DAL;
using SERVICIOS.Bitacora.DAL.Factory;

namespace BLL
{
    public class ClienteBLL
    {
		#region Singleton
		private static readonly ClienteBLL _instance = new ClienteBLL();

		private ClienteBLL()
		{
			//Implement here the initialization code
		}

		public static ClienteBLL Current
		{
			get { return _instance; }
		}
		#endregion

		Bitacora oBitacora = new Bitacora();
		public void Add(Cliente cliente)
		{
			try
			{
				Factory.Current.GetRepositoryCliente().Add(cliente);
				Factory.Current.GetRepositoryClienteFireBase().Add(cliente); // prueba de FireBase para agregar clientes

				oBitacora.FechaHora = DateTime.Now;
				oBitacora.Descripcion = "Se ha creado un nuevo cliente";
				oBitacora.Severidad = "ALTA";
				oBitacora.Usuario = "Nicolas";

				FactoryServicios.Current.GetRepositoryBitacora().Add(oBitacora); 
				
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
		public static IEnumerable<Cliente> Leer()
		{
			try
			{
				return Factory.Current.GetRepositoryCliente().GetAll();
			}
			catch (Exception)
			{
				throw;
			}
		}

		public static IEnumerable<Cliente> GetOne(int id)
        {
            try
            {
				
				return Factory.Current.GetRepositoryCliente().GetOne(id);
            }
            catch (Exception)
            {

                throw;
            }
        }
	}
}

