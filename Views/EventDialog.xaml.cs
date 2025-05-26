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
            CalendarRepository.DeleteUserEvent(_event);

            DialogResult = true;
            Close();
        }

        private void Close_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            Close();
        }
    }
}
