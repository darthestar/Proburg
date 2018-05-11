using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Proburg.Data;
using Proburg.ViewModels;
using Proburg.Models;




namespace Proburg.Controllers
{
    public class EnrollAttendeeController : ApiController
    {
        [HttpPost]
        [Route("api/events/{eventId}/EnrollAttendee")]
        public IHttpActionResult AddAttendee([FromUri] int eventId, [FromBody]AttendeeViewModel attendee)
        {

            // get the event
            // get the attendee
            // if the attendee does not exist, add to datrabase
            // add to event 
            // save database

            using (var context = new EventContext())
            {
                var AllUsers = context.Attendees.Include(i => i.Events);
                var _event = context.Events.FirstOrDefault(w => w.ID == eventId);
                var _attendee = AllUsers.FirstOrDefault(a => a.Email == attendee.email);
                if (_attendee == null)
                {
                    _attendee = new Attendee
                    {
                        Email = attendee.email
                    };
                    context.Attendees.Add(_attendee);
                    context.SaveChanges();
                }


                _attendee.Events.Add(_event);
                context.SaveChanges();

                return Ok();

            }
        }
    }
}
