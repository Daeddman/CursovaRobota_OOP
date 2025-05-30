using System;
using System.Text.Json.Serialization;
using CursovaRobota.Services;

namespace CursovaRobota.Models
{
    /// <summary>Звичайна (одноразова) подія.</summary>
    public class Event : CalendarItem
    {
        public string Title { get; set; }
        public string Description { get; set; }

        public override string DisplayName => Title;

        public override void Trigger()
        {
            
        }
    }
}
