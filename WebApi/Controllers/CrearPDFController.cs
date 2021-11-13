using Microsoft.AspNetCore.Mvc;
using Rotativa.AspNetCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Controllers
{
    [Route("WebApi/[controller]")]
    [ApiController]
    public class CrearPDFController : Controller
    {
        public IActionResult Index()
        {
            return new ViewAsPdf("Vista_Reportes")
            {

            };
        }
    }
}
