using BLL;
using Dominio;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Controllers
{
    [Route("WebApi/[controller]")]
    [ApiController]
    public class ClienteController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(Cliente cliente)
        {
            ClienteBLL.Current.Add(cliente);
            return Ok();
        }

        [HttpGet]
        public IActionResult Get()
        {
            List<Cliente> listaclientes = new List<Cliente>();
            listaclientes = (List<Cliente>)ClienteBLL.Leer();
            return Ok(listaclientes);

        }

        [HttpGet("{id}")]
        public IActionResult GetOne(int id)
        {
            List<Cliente> listaclientes = new List<Cliente>();
            listaclientes = (List<Cliente>)ClienteBLL.GetOne(id);
            return Ok(listaclientes);
        }
    }
}
