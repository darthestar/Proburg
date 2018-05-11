using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using Proburg.Models;
using Proburg.Data;
using System.Data.Entity;

namespace Proburg.Controllers
{

    public class EventsController : ApiController
    {
        public IHttpActionResult Get(string title = null)
        {
            try
            {
                var db = new EventContext();
                var query = db.Events.Include(i => i.City);

                if (!String.IsNullOrEmpty(title))
                {
                    query = query.Where(w => w.Title.Contains(title));
                }

                var results = query.ToList();

                if (results.Count == 0)
                {
                    return NotFound();
                }
                else
                {
                    return Ok(results);
                }

            }
            catch (ArgumentNullException ex)
            {
                return InternalServerError(ex);
            }
        }


        //public IEnumerable<Event> Get()
        //{

        //    using (var db = new EventContext())
        //    {
        //        var query = db.Events.Include(i => i.Attendees).Include(i => i.City);
        //        return query.ToList();
        //    }
        //}
        [HttpGet]
        [Route ("api/events/{eventID}")]
        public IHttpActionResult GetOneEvent(int eventID)
        {
            using (var db = new EventContext())
            {
                var anEvent = db.Events
                    .Include(i=> i.Attendees)
                    .Include(i=> i.City)
                    .SingleOrDefault(s => s.ID == eventID);
                if (anEvent == null)
                {
                    return NotFound();
                }
                else
                {
                    return Ok(anEvent);
                }
            }
        }
    }
}


