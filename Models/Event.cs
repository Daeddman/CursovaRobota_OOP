using System;
using System.Text.Json.Serialization;
using CursovaRobota.Services;

namespace CursovaRobota.Models
{
    public sealed class Event : CalendarItem
    {
        [JsonPropertyName("id")]
        public Guid Id { get; set; } = Guid.NewGuid();

        public string Title { get; set; }

        public DateTime Date { get; set; }

        public string Description { get; set; }

        public override void Trigger()
        {

            bool deleted = NotificationService.Instance.ShowMessage(this);

            if (deleted)
            {

            }
        }
    }
}
