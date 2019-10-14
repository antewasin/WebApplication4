using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using WebApplication4.Models;
using WebApplication4.Infrastructure;

namespace WebApplication4.Controllers
{
    [RoutePrefix("api")]
    public class ValuesController : ApiController
    {
        private readonly ClientRequests request = new ClientRequests();

        [HttpGet]
        [Route("convert/{amount}/{codeA}/{codeX}")]
        public IHttpActionResult Get(double amount, string codeA, string codeX)
        {
            try
            {
                if (codeA == "pln") return Ok(request.ConvertPLNToX(amount, codeX));
                if (codeX == "pln") return Ok(request.ConvertXToPLN(amount, codeA));

                return Ok(request.Convert(amount, codeA, codeX));
            }
            catch (NullReferenceException e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet]
        [Route("avaliable-currents")]
        public IHttpActionResult Get()
            => Ok(request.GetCurrentsAndRates().Select(x => x.Code));


        [HttpGet]
        [Route("rates")]
        public IHttpActionResult GetRates()
            => Ok(request.GetCurrentsAndRates());


       



    }
}
