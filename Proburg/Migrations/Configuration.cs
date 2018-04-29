namespace Proburg.Migrations
{
    using Proburg.Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Proburg.Data.EventContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Proburg.Data.EventContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.

            var cities = new List<City>
            {
                new City { Name = "St. Petersburg"},
                new City { Name = "Tampa"}
            };

            cities.ForEach(c =>
            {
                context.Cities.AddOrUpdate(n => n.Name, c);
            });



            var events = new List<Event>
            {
                new Event{ Title="UI Conference", LongDescription="Best Conference Ever",Address="123 Some Street", State="FL", Zip="33701", AgeLimit=99,Price=100.00m, Date=new DateTime(2018,1,9), CityID= 1 },
                new Event{ Title="Mixologist Night", LongDescription="Best concoctions Ever",Address="321 Some Street", State="FL", Zip="33701", AgeLimit=99,Price=200.00m, Date=new DateTime(2018,4,9), CityID = 1 },

                };

            var attendees = new List<Attendee>
            {
                new Attendee{Email="george@gmail.com"},
                new Attendee{Email="elaine@gmail.com"},
                new Attendee{Email="newman@gmail.com"}
            };

            events.ForEach(e =>
            {
                foreach (var person in attendees)
                {
                    e.Attendees.Add(person);
                }
                context.Events.AddOrUpdate(t => t.Title, e);
            });
            context.SaveChanges();
        }
    }
}

