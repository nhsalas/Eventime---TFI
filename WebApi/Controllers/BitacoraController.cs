using BLL;
using Microsoft.AspNetCore.Mvc;
using SERVICIOS.Bitacora.BLL;
using SERVICIOS.Bitacora.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Controllers
{
    [Route("WebApi/[controller]")]
    [ApiController]
    public class BitacoraController : Controller
    {

        [HttpPost]
        public IActionResult Add(Bitacora bitacora)
        {
            BitacoraBLL.Current.Add(bitacora);
            return Ok();
        }

        [HttpGet]
        public IActionResult Get()
        {
            List<Bitacora> movimientos = new List<Bitacora>();
            movimientos = (List<Bitacora>)BitacoraBLL.Leer();
            return Ok(movimientos);

        }
    }
}
