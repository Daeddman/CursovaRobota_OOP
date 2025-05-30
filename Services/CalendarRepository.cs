using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;
using CursovaRobota.Models;
using System.Windows.Controls;

namespace CursovaRobota.Services
{
    public static class CalendarRepository
    {
        /* ─────────  Файли  ───────── */
        private static readonly string DataDir = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Data");
        private static readonly string HolidayFile = Path.Combine(DataDir, "holidays.json");
        private static readonly string EventFile = Path.Combine(DataDir, "events.json");

        /* ─────────  Json  ───────── */
        private static readonly JsonSerializerSettings JsonSettings = new JsonSerializerSettings
        {
            Formatting = Formatting.Indented,
            TypeNameHandling = TypeNameHandling.Auto,
            DateFormatString = "yyyy-MM-ddTHH:mm:ss"
        };

        /* ─────────  Колекції  ───────── */
        private static readonly List<Holiday> _holidays;
        private static readonly List<Event> _events;

        /* ─────────  Статичний CTOR  ───────── */
        static CalendarRepository()
        {
            Directory.CreateDirectory(DataDir);
            _holidays = Load<Holiday>(HolidayFile);
            _events = Load<Event>(EventFile);
        }

        /* ==================================================
         *                     СВЯТА
         * ==================================================*/
        public static IEnumerable<Holiday> GetHolidays() => _holidays;

        public static void AddOrUpdateHoliday(Holiday h)
        {
            if (h == null) return;
            var idx = _holidays.FindIndex(x => x.Id == h.Id);
            if (idx >= 0) _holidays[idx] = h;
            else _holidays.Add(h);
            SaveData(_holidays, HolidayFile);
        }

        public static void DeleteHoliday(Guid id)     // ← був раніше
        {
            var idx = _holidays.FindIndex(h => h.Id == id);
            if (idx >= 0)
            {
                _holidays.RemoveAt(idx);
                SaveData(_holidays, HolidayFile);
            }
        }

        /* ==================================================
         *                     ПОДІЇ
         * ==================================================*/
        public static IEnumerable<CalendarItem> GetItemsForDate(DateTime date)
        {
            // 1) Свята (із урахуванням повторень)
            foreach (var h in _holidays.ToList())    // ← тут .ToList()
            {
                if (h.Rule != null && h.Rule.Freq != Frequency.None)
                {
                    if (h.Rule.Matches(date, h.Start))
                        yield return h;
                }
                else if (h.Start.Month == date.Month && h.Start.Day == date.Day)
                {
                    yield return h;
                }
            }

            // 2) Події (із урахуванням повторень)
            foreach (var e in _events.ToList())      // ← і тут .ToList()
            {
                if (e is IRecurring re && re.Rule.Freq != Frequency.None)
                {
                    if (re.Rule.Matches(date, e.Start))
                        yield return e;
                }
                else if (e.Start.Date == date.Date)
                {
                    yield return e;
                }
            }
        }




        // додайте поруч із AddUserEvent / DeleteUserEvent
        public static void AddOrUpdateUserEvent(Event ev)
        {
            if (ev == null) return;

            var idx = _events.FindIndex(e => e.Id == ev.Id);
            if (idx >= 0) _events[idx] = ev;   // оновити
            else _events.Add(ev);     // або додати

            SaveData(_events, EventFile);
        }


        public static void DeleteUserEvent(Guid id)   // ← лишається
        {
            var idx = _events.FindIndex(e => e.Id == id);
            if (idx >= 0)
            {
                _events.RemoveAt(idx);
                SaveData(_events, EventFile);
            }
        }

        public static IReadOnlyList<CalendarItem> ItemsForMonth(DateTime month)
        {
            DateTime from = new DateTime(month.Year, month.Month, 1);
            DateTime to = from.AddMonths(1).AddDays(-1);

            var expanded = new List<CalendarItem>();

            /* ---- Holidays ---- */
            expanded.AddRange(_holidays.Where(h => h.Start.Month == month.Month));

            /* ---- Events + Recurring ---- */
            foreach (var e in _events)
            {
                if (e is IRecurring r && r.Rule.Freq != Frequency.None)
                {
                    foreach (var occ in r.GetOccurrences(from, to))
                    {
                        expanded.Add(new Event
                        {
                            Id = e.Id,
                            Title = e.Title,
                            Description = e.Description,
                            Start = occ.Date + e.Start.TimeOfDay,
                            End = occ.Date + e.End.TimeOfDay
                        });
                    }
                }
                else if (e.Start.Date >= from && e.Start.Date <= to)
                {
                    expanded.Add(e);
                }
            }
            return expanded;
        }



        /* ==================================================
         *              ЗАГАЛЬНІ   (I/O)
         * ==================================================*/
        private static List<T> Load<T>(string path)
        {
            if (!File.Exists(path)) return new List<T>();

            try
            {
                var json = File.ReadAllText(path);
                return JsonConvert.DeserializeObject<List<T>>(json, JsonSettings) ?? new List<T>();
            }
            catch
            {
                return new List<T>();
            }
        }

        private static void SaveData<T>(List<T> data, string path)
        {
            var json = JsonConvert.SerializeObject(data, JsonSettings);
            File.WriteAllText(path, json);
        }
    }
}
