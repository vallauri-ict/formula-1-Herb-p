using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using FormulaOneDll;

namespace FormulaOneWebApiProject.Controllers
{
    public class TeamsController : ApiController
    {
        DbTools db = new DbTools();

        public IEnumerable<Team> GetAllTeams()
        {
            return db.Teams;
        }
        public IHttpActionResult GetTeams(string id)
        {
            var team = db.Teams.FirstOrDefault((t) => t.ID == Convert.ToInt32(id));
            if (team == null)
            {
                return NotFound();
            }
            return Ok(team);
        }
    }
}

