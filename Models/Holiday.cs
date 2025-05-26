using System;
using System.Text.Json.Serialization;
using System.Windows;
using System.Windows.Media.Animation;
using CursovaRobota.Models;
using CursovaRobota.Views;

namespace CursovaRobota.Models
{
    public class Holiday : CalendarItem
    {
        [JsonPropertyName("id")]
        public Guid Id { get; set; } = Guid.NewGuid();

        public string Title { get; set; }
        public string Description { get; set; }    
        public string AnimationKey { get; set; }

        public override void Trigger()
        {
            if (Application.Current?.MainWindow is FrameworkElement wnd &&
                !string.IsNullOrEmpty(AnimationKey) &&
                wnd.TryFindResource(AnimationKey) is Storyboard sb)
            {
                sb.Begin(wnd);
            }
            var dlg = new HolidayDialog(this)
            {
                Owner = Application.Current.MainWindow
            };
            dlg.ShowDialog();
        }
    }
}