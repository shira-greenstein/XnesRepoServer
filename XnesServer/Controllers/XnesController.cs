using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using XnesServer.Interfaces;
using XnesServer.Models;
using XnesServer.Services;

namespace XnesServer.Controllers
{
     [Route("api/values/XnesController")]
    [ApiController]
    public class XnesController : ControllerBase
    {

        private IXnesService _xnesService;
        //
        //public XnesController(IXnesService xnesService)
        //{
        //    _xnesService = xnesService;
        //}
        public XnesController(XnesContext xnesService)
        {
            Console.Write("");
            _xnesService = new XnesService(xnesService);
        }

        // POST api/values

        [HttpPost]
        [Route("AddCustomer")]
        public ActionResult AddCustomer(object customer)
        {
Customers c= Newtonsoft.Json.JsonConvert.DeserializeObject<Customers>(customer.ToString());
            

            try
            {
               Customers getCustomer= _xnesService.GetCustomer(c.Tz);
                if(getCustomer!=null)
                     return StatusCode(409,"User already exists.");
                _xnesService.AddCustomer(c);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }



        //GET api/values/5
        [HttpGet]
        [Route("GetCustomers")]
        public List<Customers> GetCustomers()
        {
            List<Customers> customrs = _xnesService.GetAllCustomers();
            return customrs;
        }

        ////GET api/values/5
        [HttpGet]
        [Route("GetCities")]
        public List<Cities> GetCities()
        {
            Console.WriteLine("enterrr");
            List<Cities> cities = _xnesService.GetAllCities();
            return cities;
        }
    }
}
