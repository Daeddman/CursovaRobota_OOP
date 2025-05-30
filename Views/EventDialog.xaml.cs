using System;
using System.Windows;
using CursovaRobota.Models;
using CursovaRobota.Services;

namespace CursovaRobota.Views
{
    public partial class EventDialog : Window
    {
        private readonly Event _event;

        public EventDialog(Event evt)
        {
            if (evt == null) throw new ArgumentNullException(nameof(evt));

            InitializeComponent();

            _event = evt;
            DataContext = _event;
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            if (_event != null)
            {
                CalendarRepository.DeleteUserEvent(_event.Id); // ← передаємо Guid
            }

            DialogResult = true;
            Close();
        }

        private void Edit_Click(object sender, RoutedEventArgs e)
        {
            var res = WindowInputDialog.Show(      // той самий базовий діалог
                "Змініть дані події",
                "Редагування події");

            if (string.IsNullOrWhiteSpace(res.Title))
                return;

            /* оновити текст */
            _event.Title = res.Title;
            _event.Description = res.Description;

            /* оновити дату й час */
            _event.Start = _event.Start.Date + res.From;
            _event.End = _event.Start.Date + res.To;

            /* якщо користувач задав повторюваність */
            if (res.Freq != Frequency.None)
            {
                var rev = new RecurringEvent
                {
                    Id = _event.Id,
                    Title = _event.Title,
                    Description = _event.Description,
                    Start = _event.Start,
                    End = _event.End,
                    Rule = new RecurrenceRule
                    {
                        Freq = res.Freq,
                        Interval = res.Interval
                    }
                };
                CalendarRepository.AddOrUpdateUserEvent(rev);
            }
            else
            {
                CalendarRepository.AddOrUpdateUserEvent(_event);
            }

            /* оновити binding */
            DataContext = null;
            DataContext = _event;
        }

    }
}
