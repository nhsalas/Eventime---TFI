using SERVICIOS.Bitacora.DAL.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SERVICIOS.Bitacora.DAL.Factory
{
    public class FactoryServicios
    {
        #region Singleton
        private static readonly FactoryServicios _instance = new FactoryServicios();
        private FactoryServicios()
        {
        }
        public static FactoryServicios Current
        {
            get { return _instance; }
        }
        #endregion

        public IRepositoryBitacora<Bitacora.Dominio.Bitacora> GetRepositoryBitacora()
        {

            // string namespacename = ConfigurationManager.AppSettings["RepositorioSQL"] + ".ClienteRepository";
            string namespacename = "SERVICIOS.Bitacora.DAL.Repositories.SQL.BitacoraRepository";

            object instancia = Activator.CreateInstance(Type.GetType(namespacename));

            return (IRepositoryBitacora<Bitacora.Dominio.Bitacora>)instancia;

        }
    }
}
