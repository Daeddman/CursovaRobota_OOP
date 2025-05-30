using System;
using System.Windows;
using CursovaRobota.Models;
using CursovaRobota.Services;
using CursovaRobota.Views;

namespace CursovaRobota.Views
{
    /// <summary>Інформаційне вікно свята + дії «Редагувати / Видалити».</summary>
    public partial class HolidayDialog : Window
    {
        private readonly Holiday _holiday;   // оригінальний екземпляр

        public HolidayDialog(Holiday existing = null)
        {
            InitializeComponent();

            _holiday = existing ?? new Holiday
            {
                Id = Guid.NewGuid(),
                Start = DateTime.Today      // рік ігнорується
            };
            DataContext = _holiday;
        }

        /* ─────────  Зберегти (на випадок, якщо діалог відкрито одразу в режимі редагування)  ───────── */
        private void Save_Click(object sender, RoutedEventArgs e)
        {
            CalendarRepository.AddOrUpdateHoliday(_holiday);
            DialogResult = true;
        }

        /* ─────────  Видалити  ───────── */
        private void Delete_Click(object sender, RoutedEventArgs e)
        {

            CalendarRepository.DeleteHoliday(_holiday.Id);
            DialogResult = true;
            Close();
        }

        /* ─────────  Редагувати  ───────── */
        private void Edit_Click(object sender, RoutedEventArgs e)
        {
            // ✔︎ використовуємо EditHoliday, а не загальне Show
            var result = WindowInputDialog.EditHoliday(
                "Змініть дані свята",
                "Редагування свята",
                _holiday.Title,
                _holiday.Description,
                _holiday.AnimationKey,
                _holiday.Rule?.Freq ?? Frequency.Yearly,
                _holiday.Rule?.Interval ?? 1);

            if (!result.Confirmed) return;

            _holiday.Title = result.Title;
            _holiday.Description = result.Description;
            _holiday.AnimationKey = result.AnimKey;

            _holiday.Rule = new RecurrenceRule
            {
                Freq = result.Freq,
                Interval = result.Interval
            };

            CalendarRepository.AddOrUpdateHoliday(_holiday);
            DataContext = _holiday;      // refresh

        }
    }
}
