using System.Linq;

namespace SportEvent.Core
{
    public interface ISportEventRepository
    {
        //IQueryable<Event> GetActiveEvents();
        IQueryable<Event> GetActiveEvents();
        void Insert(Event @event);
        void Update(Event @event);
        void Delete(string id);
        Event FindEvent(string id);


    }
}
