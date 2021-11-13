using DAL.Factory;
using DOMINIO;
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
    public class EventoBLL
    {
		#region Singleton
		private static readonly EventoBLL _instance = new EventoBLL();

		private EventoBLL()
		{
			//Implement here the initialization code
		}

		public static EventoBLL Current
		{
			get { return _instance; }
		}
		#endregion

		Bitacora oBitacora = new Bitacora();
		public void Add(Evento evento)
		{
			try
			{
				Factory.Current.GetRepositoryEvento().Add(evento);
				//Factory.Current.GetRepositoryClienteFireBase().Add(evento); // prueba de FireBase para agregar eventos

				oBitacora.FechaHora = DateTime.Now;
				oBitacora.Descripcion = "Se ha creado un nuevo evento";
				oBitacora.Severidad = "MEDIA";
				oBitacora.Usuario = "Nicolas";

				FactoryServicios.Current.GetRepositoryBitacora().Add(oBitacora);
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
		public static IEnumerable<Evento> Leer()
		{
			try
			{
				return Factory.Current.GetRepositoryEvento().GetAll();
			}
			catch (Exception)
			{
				throw;
			}
		}
	}
}
