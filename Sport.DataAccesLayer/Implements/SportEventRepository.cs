using SportEvent.Core;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;

namespace SportEvent.DataAccesLayer.Implements
{
    public class SportEventRepository : ISportEventRepository
    {
        private SportEventContext db = new SportEventContext();

        public enum EventStatus { 
            Open,
            Close
        }
        public IQueryable<Event> GetActiveEvents()
        {
            return db.Events;
        }
        public void Insert(Event @event)
        {
            @event.EventStatus = EventStatus.Open.ToString();
            db.Events.Add(@event);
            db.SaveChanges();
        }

        public void Update(Event @event)
        {
            db.Entry(@event).State = EntityState.Modified;
            db.SaveChanges();
        }

        public Event FindEvent(string id) {
            var dataEvent = db.Events.Where(x => x.Id == id).First();
            return dataEvent;

        }
        public void Delete(String id) {

            var dataEvent = db.Events.Find(id);
            db.Events.Remove(dataEvent);
            db.SaveChangesAsync();
        }

    }
}
