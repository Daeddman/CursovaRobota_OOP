using System;

namespace CursovaRobota.Models
{
    public abstract class CalendarItem
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public DateTime Start { get; set; }          
        public DateTime End { get; set; }

        public RecurrenceRule Rule { get; set; }

        public virtual string DisplayName => "Item";

        public abstract void Trigger();               
    }
}
