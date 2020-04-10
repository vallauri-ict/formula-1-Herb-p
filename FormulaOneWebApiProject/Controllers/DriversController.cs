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
        public IHttpActionResult GetDrivers(string id)
        {
            var driver = db.Drivers.Values.FirstOrDefault((d) => d.ID == Convert.ToInt32(id));
            if (driver == null)
            {
                return NotFound();
            }
            return Ok(driver);
        }
    }
}
