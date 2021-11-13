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
    public class ServicioController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(Servicio servicio)
        {
            ServicioBLL.Current.Add(servicio);
            return Ok();
        }

        [HttpGet]
        public IActionResult Get()
        {
            List<Servicio> ListaServicios = new List<Servicio>();
            ListaServicios = (List<Servicio>)ServicioBLL.Leer();
            return Ok(ListaServicios);

        }

        [HttpGet("{id}")]
        public IActionResult GetOne(int id)
        {
            List<Servicio> ListaServicios = new List<Servicio>();
            ListaServicios = (List<Servicio>)ServicioBLL.GetOne(id);
            return Ok(ListaServicios);
        }
    }
}
