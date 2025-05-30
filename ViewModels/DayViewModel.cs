using System;
using System.Collections.Generic;
using System.Linq;
using CursovaRobota.Models;
using CursovaRobota.Services;

namespace CursovaRobota.ViewModels
{
    public sealed class DayViewModel : ViewModelBase
    {
        private bool _isSelected;

        public DayViewModel(DateTime date, bool isCurrentMonth)
        {
            Date = date;
            IsCurrentMonth = isCurrentMonth;
            CalendarItems = CalendarRepository
                           .GetItemsForDate(date)
                           .ToList();



            OnPropertyChanged(nameof(HasItems));
        }


        // ---------- Властивості ----------
        public DateTime Date { get; }
        public int DayNumber => Date.Day;
        public int Row { get; set; }   
        public int Col { get; set; }

        public bool IsToday => Date.Date == DateTime.Today;
        public bool IsCurrentMonth { get; }
        public bool IsWeekend =>
            Date.DayOfWeek == DayOfWeek.Saturday ||
            Date.DayOfWeek == DayOfWeek.Sunday;

        public List<CalendarItem> CalendarItems { get; private set; }

        public bool HasItems => CalendarItems.Any();   


        public bool IsSelected
        {
            get => _isSelected;
            set { if (_isSelected != value) { _isSelected = value; OnPropertyChanged(); } }
        }

        // ---------- API ----------
        public int TriggerItems()
        {
            int removedCount = 0;

            // 1) Події
            var toDelete = CalendarItems
                .OfType<Event>()
                .Where(evt => NotificationService.Instance.ShowMessage(evt))
                .ToList();

            foreach (var evt in toDelete)
            {
                CalendarRepository.DeleteUserEvent(evt.Id);
                CalendarItems.Remove(evt);
                removedCount++;
            }

            // 2) Свята
            foreach (var holiday in CalendarItems.OfType<Holiday>().ToList())
            {
                // програємо анімацію
                holiday.Trigger();

                // показуємо діалог (без логіки видалення)
                NotificationService.Instance.ShowMessage(holiday);

                // якщо його видалили вручну в діалозі
                bool stillExists = CalendarRepository
                    .GetHolidays()
                    .Any(h => h.Id == holiday.Id);

                if (!stillExists)
                {
                    CalendarRepository.DeleteHoliday(holiday.Id);
                    CalendarItems.Remove(holiday);
                    removedCount++;
                }
            }

            // повідомити UI про зміну dot
            OnPropertyChanged(nameof(HasItems));
            return removedCount;
        }





        public void AddCalendarItem(CalendarItem item)
        {
            CalendarItems.Add(item);
            OnPropertyChanged(nameof(HasItems));   
        }


        public void Refresh() => OnPropertyChanged(nameof(HasItems));
    }
}
