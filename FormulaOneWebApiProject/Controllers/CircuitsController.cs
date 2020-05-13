using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using FormulaOneDll;

namespace FormulaOneWebApiProject.Controllers
{  
    public class CircuitsController : ApiController
    {
        DbTools db = new DbTools();

        public IEnumerable<Circuit> GetAllRaces()
        {
            return db.Circuits.Values;
        }
        public IHttpActionResult GetRaces(string id)
        {
            var circuits = db.Circuits.Values.FirstOrDefault((d) => d.Id == Convert.ToInt32(id));
            if (circuits == null)
            {
                return NotFound();
            }
            return Ok(circuits);
        }
    }
}
