using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using Proburg.Models;

namespace Proburg.Data
{
    public class EventContext : DbContext
    {
        public EventContext() : base("name=DefaultConnection")
        {

        }

        public DbSet<City> Cities { get; set; }
        public DbSet<Event> Events{get;set;}
        public DbSet<Attendee> Attendees { get; set; }
    }
}