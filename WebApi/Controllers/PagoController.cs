using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using DOMINIO;
using BLL;
using System;
using System.Net;
using System.IO;
using MercadoPago.Config;
using MercadoPago.Client.Preference;
using MercadoPago.Resource.Preference;
using System.Threading.Tasks;
using SERVICIOS;

namespace API.Controllers
{
    [Route("WebApi/[controller]")]
    [ApiController]
    public class PagoController : ControllerBase
    {
        private string UrlPago;
        //[HttpGet]
        //public IActionResult GetAll()
        //{
        //    List<Pago> pagos = new List<Pago>();
        //    pagos = (List<Pago>)PagoBLL.Current.GetAll();
        //    return Ok(pagos);
        //}         
        
        //public void GetInit()
        //{
        //    Servicio servicio = new Servicio();
        //    servicio.descripcion = UrlPago;
        //}

        [HttpGet]
        public void Asd()
        {

        }

        [HttpPost]
        public async Task<ActionResult<string>> GetAllAsync(Servicio servicio)
        {
            MercadoPagoConfig.AccessToken = ApplicationSettings.Current.AccessTokenMP;
            // Crea el objeto de request de la preference
            var request = new PreferenceRequest
            {
                Items = new List<PreferenceItemRequest>
                    {
                        new PreferenceItemRequest
                        {
                            Title = servicio.nombre,
                            Quantity = 1,
                            CurrencyId = "ARS",
                            UnitPrice = servicio.precio,
                        },
                    },
                Shipments = new PreferenceShipmentsRequest
                {
                    Cost = 0,
                    Mode = "not_specified",
                },
                BackUrls = new PreferenceBackUrlsRequest
                {
                    Success = "https://localhost:44348", //concatenarle el numero de pedido
                    Failure = "https://localhost:44348",
                    Pending = "https://localhost:44348",
                },
                AutoReturn = "approved",

            };
            var client = new PreferenceClient();
            Preference preference = await client.CreateAsync(request);

            UrlPago = preference.InitPoint;

            //Pago pago = new Pago();
            //pago.idPago = preference.Id;
            //pago.FechaHora = DateTime.Now;

            //PagoBLL.Current.Add(pago);
            servicio.descripcion = preference.InitPoint;
            return UrlPago;
            
        }

        //[HttpGet("{id}")]
        //public IActionResult Get(Guid id)
        //{
        //    List<Pago> listapagos = new List<Pago>();
        //    listapagos = (List<Pago>)PagoBLL.GetOne(id);
        //    return Ok(listapagos);
        //}


        //[HttpPut]
        //public IActionResult Edit(Pago pago)
        //{
        //    PagoBLL.Current.Update(pago);
        //    return Ok();
        //}

    }
    }

