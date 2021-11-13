using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SERVICIOS.Bitacora.Dominio
{
    public class Bitacora
    {
        public int Id { get; set; }
        public DateTime FechaHora { get; set; }
        public string Descripcion { get; set; }
        public string Severidad { get; set; }
        public string Usuario { get; set; }

    }
}
