using System.Windows;
using CursovaRobota.Models;

namespace CursovaRobota.Views
{
    public partial class HolidayDialog : Window
    {
        public HolidayDialog(Holiday holiday)
        {
            InitializeComponent();
            DataContext = holiday;
        }

        private void Ok_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}