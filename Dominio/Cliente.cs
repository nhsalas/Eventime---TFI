using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Cliente
    {
        public int NroCliente { get; set; }
        public int CUIT { get; set; }
        public string RazonSocial { get; set; }
        public decimal Saldo { get; set; }
        public string nombre { get; set; }
        public string apellido { get; set; }
    }
}
