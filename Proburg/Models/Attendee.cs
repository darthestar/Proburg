﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;


namespace Proburg.Models
{
    public class Attendee
    {
        public int ID { get; set; }
        public string Email { get; set; }

        public ICollection<Event> Events { get; set; } = new HashSet<Event>();

    }
}