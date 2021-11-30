using BLL;
using DOMINIO;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Controllers
{
    [Route("WebApi/[controller]")]
    [ApiController]
    public class EventoController : Controller
    {

        [HttpPost]
        public IActionResult Add(Evento evento)
        {
            EventoBLL.Current.Add(evento);
            return Ok();
        }

        [HttpGet]
        public IActionResult Get()
        {
            List<Evento> ListaEventos = new List<Evento>();
            ListaEventos = (List<Evento>)EventoBLL.Leer();
            return Ok(ListaEventos);

        }

        [HttpGet("{id}")]
        public IActionResult GetOne(int id)
        {
            return Ok(); // AGREGAR CODIGO
        }
    }
}
