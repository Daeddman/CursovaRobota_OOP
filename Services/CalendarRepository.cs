using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;
using CursovaRobota.Models;

namespace CursovaRobota.Services
{
    public static class CalendarRepository
    {
        private static readonly string DataDir = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Data");
        private static readonly string HolidayFile = Path.Combine(DataDir, "holidays.json");
        private static readonly string EventFile = Path.Combine(DataDir, "events.json");

        private static readonly JsonSerializerOptions JsonOptions = new JsonSerializerOptions
        {
            WriteIndented = true,
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            Converters = { new IsoDateConverter() }
        };

        private static readonly List<Holiday> _holidays;
        private static readonly List<Event> _events;

        static CalendarRepository()
        {
            Directory.CreateDirectory(DataDir);
            _holidays = Load<Holiday>(HolidayFile);
            if (_holidays.Count == 0)
            {
                _holidays = new List<Holiday>
                {
                    new Holiday {
                        Id           = Guid.NewGuid(),
                        Title        = "Новий рік",
                        Description  = "Святкування початку нового року з феєрверками та сімейними традиціями",
                        Date         = new DateTime(1, 1, 1),
                        AnimationKey = "newyear_anim"
                    },
                    new Holiday {
                        Id           = Guid.NewGuid(),
                        Title        = "День Святого Валентина",
                        Description  = "Свято закоханих — обмін валентинками і солодощами",
                        Date         = new DateTime(1, 2, 14),
                        AnimationKey = "valentine_anim"
                    },
                    new Holiday {
                        Id           = Guid.NewGuid(),
                        Title        = "Міжнародний жіночий день",
                        Description  = "Привітання жінок і шанування їхніх досягнень",
                        Date         = new DateTime(1, 3, 8),
                        AnimationKey = "flower_anim"
                    },
                    new Holiday {
                        Id           = Guid.NewGuid(),
                        Title        = "День Землі",
                        Description  = "Всесвітня акція на підтримку навколишнього середовища",
                        Date         = new DateTime(1, 4, 22),
                        AnimationKey = "earthday_anim"
                    },
                    new Holiday {
                        Id           = Guid.NewGuid(),
                        Title        = "Halloween",
                        Description  = "Кельтське свято з костюмами та солодощами",
                        Date         = new DateTime(1, 10, 31),
                        AnimationKey = "halloween_anim"
                    },
                    new Holiday {
                        Id           = Guid.NewGuid(),
                        Title        = "Різдво",
                        Description  = "Релігійне свято народження Ісуса Христа та сімейних зустрічей",
                        Date         = new DateTime(1, 12, 25),
                        AnimationKey = "christmas_anim"
                    }
                };
                SaveData(_holidays, HolidayFile);
            }

            _events = Load<Event>(EventFile);
        }

        public static IEnumerable<CalendarItem> GetItemsForDate(DateTime date)
        {
            var holidays = _holidays
                .Where(h => h.Date.Month == date.Month && h.Date.Day == date.Day)
                .Cast<CalendarItem>();

            var events = _events
                .Where(e => e.Date.Date == date.Date)
                .Cast<CalendarItem>();

            return holidays.Concat(events);
        }
        public static void AddUserEvent(Event evt)
        {
            if (evt == null) throw new ArgumentNullException(nameof(evt));
            _events.Add(evt);
            SaveData(_events, EventFile);
        }

        public static void DeleteUserEvent(Event evt)
        {
            if (evt == null) throw new ArgumentNullException(nameof(evt));
            DeleteUserEvent(evt.Id);
        }

        public static void DeleteUserEvent(Guid eventId)
        {
            var index = _events.FindIndex(e => e.Id == eventId);
            if (index >= 0)
            {
                _events.RemoveAt(index);
                SaveData(_events, EventFile);
            }
        }

        private static List<T> Load<T>(string path)
        {
            if (!File.Exists(path))
                return new List<T>();

            try
            {
                var json = File.ReadAllText(path);
                return JsonSerializer.Deserialize<List<T>>(json, JsonOptions) ?? new List<T>();
            }
            catch
            {
                return new List<T>();
            }
        }
        private static void SaveData<T>(List<T> data, string path)
        {
            var json = JsonSerializer.Serialize(data, JsonOptions);
            File.WriteAllText(path, json);
        }
    }
}
