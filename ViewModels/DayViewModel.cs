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
                           .GetItemsForDate(date).ToList();

  
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

            var toDelete = CalendarItems
                .OfType<Event>()
                .Where(evt => NotificationService.Instance.ShowMessage(evt))
                .ToList();


            foreach (var evt in toDelete)
            {
                CalendarRepository.DeleteUserEvent(evt);
                CalendarItems.Remove(evt);
            }


            foreach (var holiday in CalendarItems.OfType<Holiday>())
                holiday.Trigger();

            OnPropertyChanged(nameof(HasItems));

            return toDelete.Count;
        }



        public void AddCalendarItem(CalendarItem item)
        {
            CalendarItems.Add(item);
            OnPropertyChanged(nameof(HasItems));   
        }


        public void Refresh() => OnPropertyChanged(nameof(HasItems));
    }
}
