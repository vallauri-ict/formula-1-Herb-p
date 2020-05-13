using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using FormulaOneDll;

namespace FormulaOneWebApiProject.Controllers
{
    public class RacesController : ApiController
    {
        DbTools db = new DbTools();
        public IEnumerable<Race> GetAllRaces()
        {
            return db.Races.Values;
        }
        public IHttpActionResult GetRaces(string id)
        {
            var races = db.Races.Values.FirstOrDefault((d) => d.Id == Convert.ToInt32(id));
            if (races == null)
            {
                return NotFound();
            }
            return Ok(races);
        }
    }
}
