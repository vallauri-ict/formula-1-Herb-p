using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using FormulaOneDll;

namespace FormulaOneWebApiProject.Controllers
{
    public class CountriesController : ApiController
    {
        DbTools db = new DbTools();

        public IEnumerable<Country> GetAllCountries()
        {
            return db.Countries.Values;
        }
        public IHttpActionResult GetCountries(string id)
        {
            var country = db.Countries[id];
            if (country == null)
            {
                return NotFound();
            }
            return Ok(country);
        }
    }
}
