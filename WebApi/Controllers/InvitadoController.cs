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
    public class InvitadoController : Controller
    {

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(Invitado invitado)
        {
            InvitadoBLL.Current.Add(invitado);
            return Ok();
        }

        [HttpGet]
        public IActionResult Get()
        {
            List<Invitado> ListaInvitados = new List<Invitado>();
            ListaInvitados = (List<Invitado>)InvitadoBLL.Leer();
            return Ok(ListaInvitados);

        }

        [HttpGet("{id}")]
        public IActionResult GetOne(int id)
        {
            List<Invitado> ListaInvitados = new List<Invitado>();
            ListaInvitados = (List<Invitado>)InvitadoBLL.GetOne(id);
            return Ok(ListaInvitados);
        }
    }
}
