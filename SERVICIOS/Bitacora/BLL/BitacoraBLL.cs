using SERVICIOS.Bitacora.DAL.Factory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SERVICIOS.Bitacora.BLL
{
    public class BitacoraBLL
    {
		#region Singleton
		private static readonly BitacoraBLL _instance = new BitacoraBLL();

		private BitacoraBLL()
		{
			//Implement here the initialization code
		}

		public static BitacoraBLL Current
		{
			get { return _instance; }
		}
		#endregion

		public void Add(Dominio.Bitacora bitacora)
		{
			try
			{
				FactoryServicios.Current.GetRepositoryBitacora().Add(bitacora);
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
		public static IEnumerable<Dominio.Bitacora> Leer()
		{
			try
			{
				return FactoryServicios.Current.GetRepositoryBitacora().GetAll();
			}
			catch (Exception)
			{
				throw;
			}
		}
	}
}
