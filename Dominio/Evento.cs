using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DOMINIO
{
    public class Evento
    {
        public int EventoId { get; set; }
        public DateTime Fecha { get; set; } = new DateTime(1900, 1, 1);
        public DateTime FechaInicio { get; set; } = new DateTime(2021,11,30);
        public DateTime FechaFinalizacion { get; set; } = new DateTime(2021, 11, 30);
        public string Nombre { get; set; }
        public string Tipo { get; set; }
        public int NroCliente { get; set; }

        public Cliente Cliente { get; set; }
        public List<Entrada> Entradas { get; set; }
        public List<Invitado> Invitados { get; set; }

    }
}
