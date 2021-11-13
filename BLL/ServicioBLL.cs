using DAL.Factory;
using DOMINIO;
using SERVICIOS.Bitacora.DAL.Factory;
using SERVICIOS.Bitacora.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class ServicioBLL
    {
		#region Singleton
		private static readonly ServicioBLL _instance = new ServicioBLL();

		private ServicioBLL()
		{
			//Implement here the initialization code
		}

		public static ServicioBLL Current
		{
			get { return _instance; }
		}
		#endregion

		Bitacora oBitacora = new Bitacora();
		public void Add(Servicio servicio)
		{
			try
			{
				Factory.Current.GetRepositoryServicio().Add(servicio);
				//Factory.Current.GetRepositoryClienteFireBase().Add(evento); // prueba de FireBase para agregar eventos

				oBitacora.FechaHora = DateTime.Now;
				oBitacora.Descripcion = "Se ha agregado un nuevo servicio";
				oBitacora.Severidad = "MEDIA";
				oBitacora.Usuario = "Nicolas";

				FactoryServicios.Current.GetRepositoryBitacora().Add(oBitacora);
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
		public static IEnumerable<Servicio> Leer()
		{
			try
			{
				return Factory.Current.GetRepositoryServicio().GetAll();
			}
			catch (Exception)
			{
				throw;
			}
		}
		public static IEnumerable<Servicio> GetOne(int id)
		{
			try
			{

				return Factory.Current.GetRepositoryServicio().GetOne(id);
			}
			catch (Exception)
			{

				throw;
			}
		}
	}
}
