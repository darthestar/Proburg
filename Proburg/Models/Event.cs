﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Proburg.Models
{
    public class Event
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string LongDescription { get; set; }
        public string Address { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }
        public DateTime Date { get; set; }
        public int AgeLimit { get; set; }
        public decimal Price { get; set; }

        public int? CityID { get; set; }
        public City City { get; set; }

        public virtual ICollection<Attendee> Attendees { get; set; } = new HashSet<Attendee>();
    }
}