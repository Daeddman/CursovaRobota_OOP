using System.Windows.Controls;
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
    }
}
