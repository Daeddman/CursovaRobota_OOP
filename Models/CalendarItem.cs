using System;

namespace CursovaRobota.Models
{
    public abstract class CalendarItem
    {
        public DateTime Date { get; set; }   
        public abstract void Trigger();
    }
}
