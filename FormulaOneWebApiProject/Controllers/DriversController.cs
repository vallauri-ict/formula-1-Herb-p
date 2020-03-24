using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using FormulaOneDll;

namespace FormulaOneWebApiProject.Controllers
{
    public class DriversController : ApiController
    {

        /*public IEnumerable<Product> GetAllProducts()
        {
            return products;
        }*/
        DbTools db = new DbTools();

        public IEnumerable<Driver> GetAllDrivers()
        {
            return db.Drivers.Values;
        }
        public IHttpActionResult GetDrivers(int id)
        {
            return NotFound();
        }
    }
}
