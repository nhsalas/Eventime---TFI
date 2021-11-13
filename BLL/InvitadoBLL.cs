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
    public class InvitadoBLL
    {
		#region Singleton
		private static readonly InvitadoBLL _instance = new InvitadoBLL();

		private InvitadoBLL()
		{
			//Implement here the initialization code
		}

		public static InvitadoBLL Current
		{
			get { return _instance; }
		}
		#endregion

		Bitacora oBitacora = new Bitacora();
		public void Add(Invitado invitado)
		{
			try
			{
				Factory.Current.GetRepositoryInvitado().Add(invitado);

				oBitacora.FechaHora = DateTime.Now;
				oBitacora.Descripcion = "Se agregó un nuevo invitado";
				oBitacora.Severidad = "ALTA";
				oBitacora.Usuario = "Nicolas";

				FactoryServicios.Current.GetRepositoryBitacora().Add(oBitacora);

			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
		public static IEnumerable<Invitado> Leer()
		{
			try
			{
				return Factory.Current.GetRepositoryInvitado().GetAll();
			}
			catch (Exception)
			{
				throw;
			}
		}

		public static IEnumerable<Invitado> GetOne(int id)
		{
			try
			{

				return Factory.Current.GetRepositoryInvitado().GetOne(id);
			}
			catch (Exception)
			{

				throw;
			}
		}
	}
}
