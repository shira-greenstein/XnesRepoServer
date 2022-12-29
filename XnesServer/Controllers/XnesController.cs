using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using XnesServer.Models;
using XnesServer.Services;

namespace XnesServer.Controllers
{
     [Route("api/values/XnesController")]
    [ApiController]
    public class XnesController : ControllerBase
    {

        private XnesService _xnesService;

        //public XnesController(XnesService xnesService)
        public XnesController(XnesService xnesService)
        {
            _xnesService = xnesService;
        }

        // POST api/values
        
        [HttpPost]
        [Route("AddCustomer")]
        public ActionResult AddCustomer([FromBody] Customers customer)
        {
            Console.Write(customer);
            try
            {
                _xnesService.AddCustomer(customer);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }



        // GET api/values/5
        [HttpGet("{id}")]
        [Route("GetCustomer")]
        public ActionResult<string> GetCustomer(int id)
        {
            return "value";
        }

        // GET api/values/5
        [HttpGet]
        [Route("GetCities")]
        public ActionResult<string> GetCities(int id)
        {
            return "value";
        }


    }
}
