using System.Windows.Controls;
using System.Windows.Input;
using CursovaRobota.ViewModels;

namespace CursovaRobota.Controls
{
    public partial class CalendarControl : UserControl
    {
        public CalendarControl()
        {
            InitializeComponent();
            DataContext = new CalendarViewModel(); 
        }
        private void DayCell_PreviewMouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            // Скинемо стандартний «натиск» щоб не було двох кліків
            e.Handled = true;

            if (sender is Button btn && btn.DataContext is DayViewModel day)
            {
                var vm = DataContext as CalendarViewModel;
                vm?.AddEventCmd.Execute(day);
            }
        }

    }
}
